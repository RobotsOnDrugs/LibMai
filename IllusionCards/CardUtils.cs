using System.IO;
using IllusionCards.Cards;

namespace IllusionCards
{
	public static class CardUtils
	{
		public static IllusionCard GetIllusionCardFromFile(FileInfo cardFile)
		{
			CardStructure cs = new(cardFile);
			return IllusionCard.NewCard(cs);
		}
	}
}