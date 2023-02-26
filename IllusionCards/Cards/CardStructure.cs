namespace IllusionCards.Cards;

public readonly record struct CardStructure
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	internal const long PngStartOffset = 0;
	internal long DataStartOffset { get; init; }
	internal FileInfo? CardFile { get; init; }
	internal CardType CardType { get; init; }
	internal BinaryReader BinaryReader { get; init; }
	private static CardType? TrySceneParse(BinaryReader binaryReader)
	{
		// Studio scene files for AI, KK, and PH all start with a version number.
		if (Version.TryParse(ReadString(binaryReader), out Version? _))
		{
			Stream _stream = binaryReader.BaseStream;
			long? _pos = Helpers.FindSequence(_stream, IllusionConstants.MarkerOpener) ?? throw new InvalidCardException("This card contains no card identifiers.");
			_ = _stream.Seek((long)_pos, SeekOrigin.Begin);
			long? _pos2 = Helpers.FindSequence(_stream, IllusionConstants.MarkerCloser) ?? throw new InvalidCardException("This card contains no card identifiers.");
			while (_pos is not null && _pos2 is not null)
			{
				_ = _stream.Seek((long)_pos, SeekOrigin.Begin);
				byte[] _potentialMarkerBytes = binaryReader.ReadBytes((int)_pos2 - (int)_pos + IllusionConstants.MarkerCloser.Length);
				string _potentialMarker = Encoding.UTF8.GetString(_potentialMarkerBytes);
				if (_potentialMarker == IllusionConstants.StudioNEOV2Identifier)
					return CardType.AIScene;
				if (_potentialMarker == IllusionConstants.PHStudioIdentifier)
					return CardType.PHScene;
				if (_potentialMarker == IllusionConstants.KStudioIdentifier)
					return CardType.KKScene;
				_pos = Helpers.FindSequence(_stream, IllusionConstants.MarkerOpener);
				if (_pos is null)
					break;
				_ = _stream.Seek((long)_pos, SeekOrigin.Begin);
				_pos2 = Helpers.FindSequence(_stream, IllusionConstants.MarkerCloser);
			}
			return CardType.Unknown;
		}
		return null;
	}
	private static CardType? TryPHParse(in string identifier)
	{
		// PH non-scene cards start with the identifier.
		switch (identifier)
		{
			case IllusionConstants.PHFemaleCharaIdentifier:
				return CardType.PHFemaleChara;
			case IllusionConstants.PHFemaleClothesIdentifier:
				return CardType.PHFemaleClothes;
			case IllusionConstants.PHMaleCharaIdentifier:
				return CardType.PHMaleChara;
			default:
				break;
		}
		return null;
	}

	private static CardType? GetCardType(in string identifier)
	{
		return identifier switch
		{
			IllusionConstants.AICharaIdentifier => CardType.AIChara,
			IllusionConstants.AIClothesIdentifier => CardType.AICoordinate,
			IllusionConstants.KKCharaIdentifier => CardType.KKChara,
			IllusionConstants.KKPartyCharaIdentifier => CardType.KKPartyChara,
			IllusionConstants.KKPartySPCharaIdentifier => CardType.KKPartySPChara,
			IllusionConstants.ECCharaIdentifier => CardType.ECChara,
			_ => null,
		};
	}
	internal CardStructure(BinaryReader binaryReader, in FileInfo? cardFile)
	{
		BinaryReader = binaryReader;
		Stream _stream = BinaryReader.BaseStream;
		CardFile = cardFile;
		byte[] _header = BinaryReader.ReadBytes(Constants.PNGHeader.Length);
		if (!_header.SequenceEqual(Constants.PNGHeader)) { throw new InvalidCardException("No PNG header was found at the beginning of the file."); }
		long _pngEndOffset = Helpers.FindSequence(_stream, Constants.PNGFooter) ?? throw new InvalidCardException("No PNG footer was found.");
		DataStartOffset = _pngEndOffset + Constants.PNGFooter.Length;
		if (_stream.Length <= DataStartOffset) { throw new InvalidCardException("This is a normal PNG file with no extra data."); }
		_ = _stream.Seek(DataStartOffset, SeekOrigin.Begin);
		Logger.Debug("Data offset for {CardName:l}: {DataStartOffset}", cardFile?.FullName ?? "Unknown card", DataStartOffset);
		CardType? _cardType = TrySceneParse(BinaryReader);
		_ = _stream.Seek(DataStartOffset, SeekOrigin.Begin);
		if (_cardType is not null)
		{
			if (_cardType is CardType.Unknown)
				throw new UnsupportedCardException("Unknown scene card.");
			CardType = (CardType)_cardType;
			return;
		}
		_cardType = TryPHParse(ReadString(BinaryReader, false));
		if (_cardType is not null) { CardType = (CardType)_cardType; return; }
		if (BinaryReader.ReadInt32() == 100)
		{
			string _gameId = ReadString(BinaryReader, false);
			CardType = GetCardType(_gameId) ?? throw new InvalidCardException($"Looks like an AI or KK card, but could not determine card type from this identifier: {_gameId}");
			return;
		}
		throw new InvalidCardException("Could not determine card type.");
	}
}
