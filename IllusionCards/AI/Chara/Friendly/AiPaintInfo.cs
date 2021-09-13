namespace IllusionCards.AI.Chara.Friendly;

public readonly record struct AiPaintInfo
{
	public int id { get; init; }
	public Color Color { get; init; }
	public float Shine { get; init; }
	public float Texture { get; init; }
	public int layoutId { get; init; }
	public Vector4 Position { get; init; }
	public float Rotation { get; init; }
}