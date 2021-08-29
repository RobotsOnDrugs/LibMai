using IllusionCards.AI.Chara;
using IllusionCards.Cards;

namespace IllusionCards.AI.Cards
{
	public record AiCharaCard : IllusionCard
	{
		public AiChara Chara { get; init; }

		public AiCharaCard(CardStructure cs) : base(cs)
		{
			try { Chara = AiChara.ParseAiCharaData(CardStructure.CardBinaryReader); }
			catch (InvalidDataException ex) { throw new InvalidCardException(CardStructure.CardFile.FullName, ex.Message); }
			catch (InternalCardException ex) { throw new UnsupportedCardException(CardStructure.CardFile.FullName, ex.Message); }
			finally { CardStructure.CleanupStreams(); }
		}
	}
}