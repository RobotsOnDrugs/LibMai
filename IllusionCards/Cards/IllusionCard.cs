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
		_ = binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
		PngData = ImmutableArray.Create(binaryReader.ReadBytes((int)DataStartOffset));
		_ = binaryReader.BaseStream.Seek(DataStartOffset, SeekOrigin.Begin);
	}

	public class WrongCardTypeException : InvalidOperationException { }

	public static IllusionCard NewCard(FileInfo cardFile)
	{
		using FileStream _fstream = new(cardFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
		return NewCard(_fstream, cardFile);
	}

	[SuppressMessage("ReSharper", "SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault")]
	private static IllusionCard NewCard(Stream stream, FileInfo? cardFile)
	{
		using BinaryReader binary_reader = new(stream, Encoding.UTF8);
		CardStructure cs;
		try { cs = new(binary_reader, cardFile); }
		catch (UnsupportedCardException ex) { throw new UnsupportedCardException(ex.Message, ex, cardFile?.FullName); }
		string friendly_name = IllusionConstants.CardTypeNames[cs.CardType];
		return cs.CardType switch
		{
			CardType.AICharaUnknown => new AI.Cards.AiCharaCard(cs, binary_reader),
			CardType.AICoordinateUnknown => new AI.Cards.AiCoordinateCard(cs, binary_reader),
			CardType.AIScene => new AI.Cards.AiSceneCard(cs, binary_reader),
			//CardType.KKChara => new KKCharaCard(cs),
			//CardType.KKPartyChara => new KKPartyCharaCard(cs),
			//CardType.KKPartySPChara => new KKPartySPCharaCard(cs),
			//CardType.KKScene => new KKSceneCard(cs),
			//CardType.PHFemaleChara => new PHFemaleCharaCard(cs),
			//CardType.PHFemaleClothes => new PHFemaleClothingCard(cs),
			//CardType.PHMaleChara => new PHMaleCharaCard(cs),
			//CardType.PHScene => new PHSceneCard(cs),
			//CardType.ECChara => new ECCharaCard(cs),
			_ => throw new UnsupportedCardException($"{friendly_name} cards are currently not supported.", cardFile?.FullName ?? "")
		};
	}

	internal static string ReadString(BinaryReader binary_reader, bool no_reset = true)
	{
		// BinaryReader.ReadString() is prone to overflows in its character buffer :(
		long offset = binary_reader.BaseStream.Position;
		try
		{
			string s = Encoding.UTF8.GetString(binary_reader.ReadBytes(binary_reader.Read7BitEncodedInt()));
			if (!no_reset) _ = binary_reader.BaseStream.Seek(offset, SeekOrigin.Begin);
			return s;
		}
		catch (Exception ex) { throw new InvalidCardException("Could not parse card.", ex); }
	}
}
