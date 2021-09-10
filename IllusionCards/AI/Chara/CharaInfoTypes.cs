namespace IllusionCards.AI.Chara;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct PaintInfo
{
	public int id { get; init; }
	public Color color { get; init; }
	public float glossPower { get; init; }
	public float metallicPower { get; init; }
	public int layoutId { get; init; }
	public Vector4 layout { get; init; }
	public float rotation { get; init; }
}
