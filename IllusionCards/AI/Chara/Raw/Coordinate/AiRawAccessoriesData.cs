namespace IllusionCards.AI.Chara.Raw.Coordinate;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawAccessoriesData
{
	public AiRawAccessoriesData() { }
	public Version version { get; init; } = null!;
	public AccessoryPartsInfo[] parts { get; init; } = null!;
}

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AccessoryPartsInfo
{
	public AccessoryPartsInfo() { }
	public int type { get; init; }
	public int id { get; init; }
	public string parentKey { get; init; } = null!;

	public Vector3[,] addMove { get; init; } = new Vector3[1, 3] { { new(0f, 0f, 0f), new(0f, 0f, 0f), new(1f, 1f, 1f) } };
	public ColorInfo[] colorInfo { get; init; } = null!;
	public int hideCategory { get; init; }
	public int hideTiming { get; init; }
	public bool noShake { get; init; }
	[IgnoreMember]
	public bool partsOfHead { get; init; }
	[MessagePackObject(true)]
	public readonly record struct ColorInfo
	{
		public Color color { get; init; }
		public float glossPower { get; init; }
		public float metallicPower { get; init; }
		public float smoothnessPower { get; init; }
	}
}