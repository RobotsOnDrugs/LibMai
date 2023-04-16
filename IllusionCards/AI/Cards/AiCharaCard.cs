namespace IllusionCards.AI.Cards;

public record AiCharaCard : IllusionCard
{
	public AiChara Chara { get; init; }
	public long CharacterDataEndPosition { get; }
	public override CardType CardType => CardType.AICharaFemale;

	public AiCharaCard(in CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader)
	{
		long end_position;
		try { Chara = new(binaryReader, out end_position); }
		catch (InvalidDataException ex) { throw new InvalidCardException(ex.Message); }
		catch (InternalCardException ex) { throw new UnsupportedCardException(ex.Message); }
		CharacterDataEndPosition = end_position;
		CardFile = CardStructure.CardFile;
	}
}
