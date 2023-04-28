namespace LibMai.Cards.AI.Cards;

public record AiCharaCard : IllusionCard
{
	public AiChara Chara { get; init; }
	public long CharacterDataStartPosition { get; }
	public long CharacterDataEndPosition { get; }
	public override CardType CardType => CardType.AICharaFemale;

	public AiCharaCard(in CardStructure cs, BinaryReader binary_reader) : base(cs, binary_reader)
	{
		CharacterDataStartPosition = binary_reader.BaseStream.Position;
		long end_position;
		try { Chara = new(binary_reader, out end_position); }
		catch (InvalidDataException ex) { throw new InvalidCardException(ex.Message); }
		catch (InternalCardException ex) { throw new UnsupportedCardException(ex.Message); }
		CharacterDataEndPosition = end_position;
		CardFile = CardStructure.CardFile;
	}
}
