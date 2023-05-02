namespace LibMai.Cards.Illusion;

/// <summary>
/// Represents the structure of an AI/HS2 card, including its type and data offset information.
/// </summary>
/// <param name="PngStartOffset">The offset of the PNG data. For valid cards from file, including those without PNG data, this should be 0.</param>
/// <param name="DataStartOffset">The offset of the card data. This is typically immediately after the PNG data.</param>
/// <param name="PostHeaderOffset">The offset of the card data that immediately follows the block header data.</param>
/// <param name="CardFile">File information for the card. If you are reading from something other than a file, set this to null.</param>
/// <param name="CardType">The type of the card.</param>
public readonly record struct AiCardStructure(long PngStartOffset, long DataStartOffset, long PostHeaderOffset, FileInfo? CardFile, CardType CardType)
{
	internal static AiCardStructure AiCardStructureInternal(BinaryReader binary_reader, in FileInfo? card_file)
	{
		Stream stream = binary_reader.BaseStream;
		byte[] header = binary_reader.ReadBytes(Constants.PNGHeader.Length);
		if (!header.SequenceEqual(Constants.PNGHeader))
			throw new InvalidCardException("No PNG header was found at the beginning of the file.");
		if (!Helpers.TryFindSequence(stream, Constants.PNGFooter, out long png_end_offset))
			throw new InvalidCardException("No PNG footer was found.");
		long data_start_offset = png_end_offset + Constants.PNGFooter.Length;
		if (stream.Length <= data_start_offset) { throw new InvalidCardException("This is a normal PNG file with no extra data."); }
		
		_ = stream.Seek(data_start_offset, SeekOrigin.Begin);
		CardType card_type = PHParse(ReadString(binary_reader, false));
		if (card_type is not CardType.Unknown)
			return new(0, data_start_offset, stream.Position, card_file, card_type);

		_ = stream.Seek(data_start_offset, SeekOrigin.Begin);
		card_type = SceneParse(binary_reader);
		if (card_type is not CardType.Unknown)
			return new(0, data_start_offset, stream.Position, card_file, card_type);

		_ = stream.Seek(data_start_offset, SeekOrigin.Begin);
		if (binary_reader.ReadInt32() != 100) throw new InvalidCardException("Could not determine card type.");
		string card_id = ReadString(binary_reader, false);
		card_type = GetCharaCardType(card_id);
		if (card_type is CardType.Unknown)
			throw new InvalidCardException($"Looks like an AI or KK card, but could not determine card type from this identifier: {card_id}");
		return new(0, data_start_offset, stream.Position, card_file, card_type);
	}

	/// <summary>
	/// Parses a card's data header to determine if it is a scene card.
	/// </summary>
	/// <param name="binary_reader">An open BinaryReader for the card data. The stream must be at the beginning of the card data after the PNG data.</param>
	/// <exception cref="InvalidCardException">The card data is not valid.</exception>
	/// <returns>The scene card type or CardType.Unknown if it is not scene card data.</returns>
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
