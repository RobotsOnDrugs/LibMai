namespace IllusionCards.Cards;

public readonly record struct CardStructure
{
	public const long PngStartOffset = 0;
	public long DataStartOffset { get; } = 0;
	public long PostHeaderOffset { get; } = 0;
	public FileInfo? CardFile { get; } = null;
	public CardType CardType { get; } = CardType.Unknown;

	internal CardStructure(BinaryReader binary_reader, in FileInfo? card_file)
	{
		using Stream stream = binary_reader.BaseStream;
		CardFile = card_file;
		byte[] header = binary_reader.ReadBytes(Constants.PNGHeader.Length);
		if (!header.SequenceEqual(Constants.PNGHeader))
			throw new InvalidCardException("No PNG header was found at the beginning of the file.");
		if (!Helpers.TryFindSequence(stream, Constants.PNGFooter, out long png_end_offset))
			throw new InvalidCardException("No PNG footer was found.");
		DataStartOffset = png_end_offset + Constants.PNGFooter.Length;
		if (stream.Length <= DataStartOffset) { throw new InvalidCardException("This is a normal PNG file with no extra data."); }
		
		_ = stream.Seek(DataStartOffset, SeekOrigin.Begin);
		CardType card_type = PHParse(ReadString(binary_reader, false));
		if (card_type is not CardType.Unknown)
		{
			CardType = card_type;
			PostHeaderOffset = stream.Position;
			return;
		}

		_ = stream.Seek(DataStartOffset, SeekOrigin.Begin);
		card_type = SceneParse(binary_reader);
		if (card_type is not CardType.Unknown)
		{
			CardType = card_type;
			PostHeaderOffset = stream.Position;
			return;
		}

		_ = stream.Seek(DataStartOffset, SeekOrigin.Begin);
		if (binary_reader.ReadInt32() != 100) throw new InvalidCardException("Could not determine card type.");
		string card_id = ReadString(binary_reader, false);
		card_type = GetCharaCardType(card_id);
		CardType = card_type == CardType.Unknown ? throw new InvalidCardException($"Looks like an AI or KK card, but could not determine card type from this identifier: {card_id}") : card_type;
		PostHeaderOffset = stream.Position;
	}

	/// <summary>
	/// Parses a card's data header to determine if it is a scene card.
	/// </summary>
	/// <param name="binary_reader">An open BinaryReader for the card data. The stream must be at the beginning of the card data after the PNG data.</param>
	/// <param name="card_type">The scene card type or CardType.Unknown if it is not scene card data.</param>
	/// <exception cref="InvalidCardException">The card data is not valid.</exception>
	/// <returns>True if it is a valid known scene card, false otherwise.</returns>
	private static CardType SceneParse(BinaryReader binary_reader)
	{
		// Studio scene files for AI, KK, and PH all start with a version number.
		if (!Version.TryParse(ReadString(binary_reader), out Version? _))
			return CardType.Unknown;
		Stream stream = binary_reader.BaseStream;
		while (Helpers.TryFindSequence(stream, IllusionConstants.MarkerOpener, out long pos))
		{
			_ = stream.Seek(pos - 1, SeekOrigin.Begin);
#pragma warning disable CS8509 // This is meant to fall through and not return if there are no matches
			return ReadString(binary_reader) switch
			{
				IllusionConstants.StudioNEOV2Identifier => CardType.AIScene,
				IllusionConstants.PHStudioIdentifier => CardType.PHScene,
				IllusionConstants.KStudioIdentifier => CardType.KKScene
			};
#pragma warning restore CS8509
		}
		if (Helpers.TryFindSequence(stream, IllusionConstants.MarkerCloser, out long _))
			throw new InvalidCardException("The card data has no valid identifier");
		return CardType.Unknown;
	}
	private static CardType PHParse(in string identifier) =>
		// PH non-scene cards start with the identifier.
		identifier switch
		{
			IllusionConstants.PHFemaleCharaIdentifier => CardType.PHCharaFemale,
			IllusionConstants.PHFemaleClothesIdentifier => CardType.PHClothesFemale,
			IllusionConstants.PHMaleCharaIdentifier => CardType.PHCharaMale,
			_ => CardType.Unknown,
		};

	private static CardType GetCharaCardType(in string identifier) =>
		identifier switch
		{
			IllusionConstants.AICharaIdentifier => CardType.AICharaUnknown,
			IllusionConstants.AIClothesIdentifier => CardType.AICoordinateUnknown,
			IllusionConstants.KKCharaIdentifier => CardType.KKChara,
			IllusionConstants.KKPartyCharaIdentifier => CardType.KKPartyChara,
			IllusionConstants.KKPartySPCharaIdentifier => CardType.KKPartySPChara,
			IllusionConstants.ECCharaIdentifier => CardType.ECChara,
			_ => CardType.Unknown,
		};
}
