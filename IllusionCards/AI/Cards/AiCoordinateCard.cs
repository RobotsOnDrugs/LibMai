using IllusionCards.AI.Chara;
using IllusionCards.Cards;
using IllusionCards.Util;


namespace IllusionCards.AI.Cards
{
	public record AiCoordinateCard : AiCharaTypeCard
	{
		public string CoordinateName { get; init; }
		public AiCoordinate Coordinate { get; init; }
		public override CardType CardType { get; } = CardType.AICoordinate;
		public AiCoordinateCard(CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader, Constants.AIClothesIdentifier)
		{
			CoordinateName = ReadStringAndReset(binaryReader, noReset: true);
			int _count = binaryReader.ReadInt32();
			byte[] _coordinateData = binaryReader.ReadBytes(_count);
			Coordinate = new(_coordinateData);
			//throw new UnsupportedCardException("AI/HS2 coordinate card support still in progress");
		}
	}
}