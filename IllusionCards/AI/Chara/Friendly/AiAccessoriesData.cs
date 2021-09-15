namespace IllusionCards.AI.Chara.Friendly;

public readonly record struct AiAccessoriesData
{
	public Version Version { get; init; }
	public ImmutableArray<AiAccessoryData> Accessories { get; init; }
}

public readonly record struct AiAccessoryData
{
	public AiAccessoryType AccessoryType { get; init; }
	public int ID {  get; init; }
	public string Name {  get; init; }
}

public enum AiAccessoryType
{ }