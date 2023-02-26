namespace IllusionCards.AI.Cards;

public record AiCoordinateCard : IllusionCard
{
	public string CoordinateName { get; init; }
	public AiRawCoordinateData Coordinate { get; init; }
	public override CardType CardType => CardType.AICoordinate;
	public AiCoordinateCard(in CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader)
	{
		ParseAiCharaTypeData(binaryReader, IllusionConstants.AIClothesIdentifier, out Version _version, out int _language);
		CoordinateName = ReadString(binaryReader);
		int _count = binaryReader.ReadInt32();
		byte[] _coordinateData = binaryReader.ReadBytes(_count);
		Coordinate = new(_coordinateData, _version, _language);
	}
}
