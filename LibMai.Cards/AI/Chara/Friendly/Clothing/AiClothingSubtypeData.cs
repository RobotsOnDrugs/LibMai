namespace LibMai.Cards.AI.Chara.Friendly.Clothing;

public readonly record struct AiClothingSettingsData
{
	public int ID { get; init; }
	public string Name { get; init; }
	public ImmutableArray<AiClothingColorInfo> ColorInfos { get; init; }
}

public readonly record struct AiClothingColorInfo
{
	public Color Color { get; init; }
	public int PatternID { get; init; }
	public string PatternName { get; init; }
	public Color PatternColor { get; init; }
	public float PatternWidth { get; init; }
	public float PatternHeight { get; init; }
	public float PatternPositionX { get; init; }
	public float PatternPositionY { get; init; }
	public float PatternRotation { get; init; }
	public float Shine { get; init; }
	public float Texture { get; init; }
}