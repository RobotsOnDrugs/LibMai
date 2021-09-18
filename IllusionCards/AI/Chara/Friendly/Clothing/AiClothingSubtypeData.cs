namespace IllusionCards.AI.Chara.Friendly.Clothing;

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
	public Vector4 Layout { get; init; }
	public float Rotation { get; init; }
	public float Shine { get; init; }
	public float Texture { get; init; }
}