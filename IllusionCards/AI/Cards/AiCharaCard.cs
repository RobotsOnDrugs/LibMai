using IllusionCards.AI.Chara;
using IllusionCards.Cards;
using IllusionCards.Util;

using static IllusionCards.AI.Cards.AiCharaTypeCard;

namespace IllusionCards.AI.Cards
{
	public record AiCharaCard : AiCharaTypeCard
	{
		public AiChara Chara { get; init; }
		public override CardType CardType { get; } = CardType.AIChara;

		public AiCharaCard(CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader, Constants.AICharaIdentifier)
		{
			if (CardStructure.CardType != CardType) throw new InternalCardException("AiChara cards must be of type AIChara.");
			if (LoadVersion > AiCharaCardDefinitions.AiChaVersion)
				throw new InternalCardException($"Load version {LoadVersion} was greater than the expected version {AiCharaCardDefinitions.AiChaVersion}");
			try { Chara = AiChara.ParseAiCharaData(binaryReader); }
			catch (InvalidDataException ex) { throw new InvalidCardException(ex.Message); }
			catch (InternalCardException ex) { throw new UnsupportedCardException(ex.Message); }
			CardFile = CardStructure.CardFile;
		}
	}
}