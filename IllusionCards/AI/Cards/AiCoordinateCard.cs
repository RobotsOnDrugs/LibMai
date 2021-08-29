using IllusionCards.Cards;

namespace IllusionCards.AI.Cards
{
	internal record AiCoordinateCard : IllusionCard
	{
		public AiCoordinateCard(CardStructure cs) : base(cs)
		{
			throw new UnsupportedCardException(CardStructure.CardFile.FullName, "AI/HS2 coordinate card support still in progress");
		}
	}
}