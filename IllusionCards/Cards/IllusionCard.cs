using System;

namespace IllusionCards.Cards
{
	public abstract class IllusionCard
	{
		CardStructure CardStructure;
		internal IllusionCard(CardStructure cs)
		{
			CardStructure = cs;
		}

		public class WrongCardTypeException : InvalidOperationException { }

		public static IllusionCard NewCard(CardStructure cs)
		{
			string _friendlyName = Constants.CardTypeNames[cs.CardType];
			switch (cs.CardType)
			{
				case CardType.AIChara:
					return new AiCharaCard(cs);
				case CardType.AICoordinate:
					//return new AiCoordinateCard(cs);
					break;
				case CardType.AIScene:
					break;
				case CardType.KKChara:
					break;
				case CardType.KKPartyChara:
					break;
				case CardType.KKPartySPChara:
					break;
				case CardType.KKScene:
					break;
				case CardType.PHFemaleChara:
					break;
				case CardType.PHFemaleClothes:
					break;
				case CardType.PHScene:
					break;
				case CardType.ECChara:
					break;
				default:
					throw new Exception($"How did we end up here? ({cs.CardType})");
			}
			throw new UnsupportedCardException(cs.CardFile.Name, $"{_friendlyName} cards are not supported yet.");
		}
	}
}
