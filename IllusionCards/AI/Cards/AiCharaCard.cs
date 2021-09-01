﻿using IllusionCards.AI.Chara;
using IllusionCards.Cards;
using IllusionCards.Util;

namespace IllusionCards.AI.Cards
{
	public record AiCharaCard : AiCharaTypeCard
	{
		public AiChara Chara { get; init; }
		public override CardType CardType { get; } = CardType.AIChara;

		public AiCharaCard(CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader, Constants.AICharaIdentifier)
		{
			try { Chara = new(binaryReader); }
			catch (InvalidDataException ex) { throw new InvalidCardException(ex.Message); }
			catch (InternalCardException ex) { throw new UnsupportedCardException(ex.Message); }
			CardFile = CardStructure.CardFile;
		}
	}
}