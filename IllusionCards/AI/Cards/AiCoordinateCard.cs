using IllusionCards.AI.Chara;
using IllusionCards.Cards;
using IllusionCards.Util;

using static IllusionCards.AI.Cards.AiCharaTypeCard;

namespace IllusionCards.AI.Cards
{
	public record AiCoordinateCard : AiCharaTypeCard
	{
		public string CoordinateName { get; init; }
		public AiCoordinate AiCoordinate { get; init; }
		public override CardType CardType { get; } = CardType.AICoordinate;
		public AiCoordinateCard(CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader, Constants.AIClothesIdentifier)
		{
			if (CardStructure.CardType != CardType) throw new InternalCardException("AiCoordinate cards must be of type AIClothes.");
			if (LoadVersion > AiCharaCardDefinitions.AiClothesVersion)
				throw new InternalCardException($"Load version {LoadVersion} was greater than the expected version {AiCharaCardDefinitions.AiClothesVersion}");
			CoordinateName = ReadStringAndReset(binaryReader, noReset: true);
			int _count = binaryReader.ReadInt32();
			byte[] _coordinateData = binaryReader.ReadBytes(_count);
			AiCoordinate = new(_coordinateData);
			//throw new UnsupportedCardException("AI/HS2 coordinate card support still in progress");
		}
	}
}