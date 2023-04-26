namespace LibMai.Cards.AI.Cards;

public record AiCoordinateCard : IllusionCard
{
	public string CoordinateName { get; init; }
	public AiRawCoordinateData Coordinate { get; init; }
	public override CardType CardType => CardType.AICoordinateFemale;
	public AiCoordinateCard(in CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader)
	{
		Version type_version = ParseAiCharaTypeVersion(binaryReader, IllusionConstants.AIClothesIdentifier);
		int language = binaryReader.ReadInt32();
		CoordinateName = ReadString(binaryReader);
		int count = binaryReader.ReadInt32();
		byte[] coordinate_data = binaryReader.ReadBytes(count);
		Coordinate = new(coordinate_data, type_version, language);
	}
}
