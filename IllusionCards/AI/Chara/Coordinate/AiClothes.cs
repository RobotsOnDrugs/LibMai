namespace IllusionCards.AI.Chara;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiClothes
{
	public Version version { get => _version; init => _version = value; }
	private Version _version { get; init; } = null!;
	public ClothesPartsInfo[] parts { get; init; } = null!;
	//internal void ComplementWithVersion() { _version = AiCharaCardDefinitions.AiClothesVersion; }
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly record struct ClothesPartsInfo
	{
		public int id { get; init; }
		public ColorInfo[] colorInfo { get; init; } = null!;
		public float breakRate { get; init; }
		public bool[] hideOpt { get; init; } = null!;
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public readonly record struct ColorInfo
		{
			public Color baseColor { get; init; }
			public int pattern { get; init; }
			public Vector4 layout { get; init; }
			public float rotation { get; init; }
			public Color patternColor { get; init; }
			public float glossPower { get; init; }
			public float metallicPower { get; init; }
		}
	}
}
