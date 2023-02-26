namespace IllusionCards.Cards;

public abstract record IllusionCard
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public const long PngStartOffset = 0;
	public long DataStartOffset { get; init; }
	public ImmutableArray<byte> PngData { get; init; }
	public FileInfo? CardFile { get; init; }
	public virtual CardType CardType { get; init; } = CardType.Unknown;
	internal CardStructure CardStructure { get; init; }

	internal IllusionCard(in CardStructure cs, BinaryReader binaryReader)
	{
		CardStructure = cs;
		CardFile = CardStructure.CardFile;
		CardType = CardStructure.CardType;
		DataStartOffset = cs.DataStartOffset;
		binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
		PngData = ImmutableArray.Create<byte>(binaryReader.ReadBytes((int)DataStartOffset));
		binaryReader.BaseStream.Seek(DataStartOffset, SeekOrigin.Begin);
	}

	public class WrongCardTypeException : InvalidOperationException { }

	public static IllusionCard NewCard(FileInfo cardFile)
	{
		using FileStream _fstream = new(cardFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
		return NewCard(_fstream, cardFile);
	}

	private static IllusionCard NewCard(Stream stream, FileInfo? cardFile)
	{
		using BinaryReader _breader = new(stream, Encoding.UTF8);
		CardStructure cs;
		try { cs = new(_breader, cardFile); }
		catch (UnsupportedCardException ex) { throw new UnsupportedCardException(ex.Message, ex, cardFile?.FullName); }
		string _friendlyName = IllusionConstants.CardTypeNames[cs.CardType];
		return cs.CardType switch
		{
			CardType.AIChara => new AI.Cards.AiCharaCard(cs, _breader),
			CardType.AICoordinate => new AI.Cards.AiCoordinateCard(cs, _breader),
			CardType.AIScene => new AI.Cards.AiSceneCard(cs, _breader),
			//CardType.KKChara => new KKCharaCard(cs),
			//CardType.KKPartyChara => new KKPartyCharaCard(cs),
			//CardType.KKPartySPChara => new KKPartySPCharaCard(cs),
			//CardType.KKScene => new KKSceneCard(cs),
			//CardType.PHFemaleChara => new PHFemaleCharaCard(cs),
			//CardType.PHFemaleClothes => new PHFemaleClothingCard(cs),
			//CardType.PHMaleChara => new PHMaleCharaCard(cs),
			//CardType.PHScene => new PHSceneCard(cs),
			//CardType.ECChara => new ECCharaCard(cs),
			_ => throw new UnsupportedCardException($"{_friendlyName} cards are currently not supported.", cardFile?.FullName ?? "")
		};
	}

	internal static string ReadString(BinaryReader binaryReader, bool noReset = true)
	{
		// BinaryReader.ReadString() is prone to overflows in its character buffer :(
		long offset = binaryReader.BaseStream.Position;
		try
		{
			string _string = Encoding.UTF8.GetString(binaryReader.ReadBytes(binaryReader.Read7BitEncodedInt()));
			if (!noReset) binaryReader.BaseStream.Seek((long)offset, SeekOrigin.Begin);
			return _string;
		}
		catch (Exception ex) { throw new InvalidCardException("Could not parse card.", ex); }
	}
}
