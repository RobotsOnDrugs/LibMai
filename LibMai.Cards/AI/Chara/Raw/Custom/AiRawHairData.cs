namespace LibMai.Cards.AI.Chara.Raw.Custom;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawHairData
{
	public AiRawHairData() { }
	public Version version { get; init; } = null!;
	public bool sameSetting { get; init; }
	public bool autoSetting { get; init; }
	public bool ctrlTogether { get; init; }
	public HairPartsInfo[] parts { get; init; } = null!;
	public int kind { get; init; }
	public int shaderType { get; init; }
	[MessagePackObject(true)]
	public readonly record struct HairPartsInfo
	{
		public HairPartsInfo() { }
		public int id { get; init; }
		public Color baseColor { get; init; }
		public Color topColor { get; init; }
		public Color underColor { get; init; }
		public Color specular { get; init; }
		public float metallic { get; init; }
		public float smoothness { get; init; }
		public ColorInfo[] acsColorInfo { get; init; } = null!;
		public int bundleId { get; init; }
		public Dictionary<int, BundleInfo> dictBundle { get; init; } = null!;
		public int meshType { get; init; }
		public Color meshColor { get; init; }
		public Vector4 meshLayout { get; init; }
		[MessagePackObject(true)]
		public readonly record struct BundleInfo
		{
			public Vector3 moveRate { get; init; }
			public Vector3 rotRate { get; init; }
			public bool noShake { get; init; }
		}
		[MessagePackObject(true)]
		public readonly record struct ColorInfo
		{
			public Color color { get; init; }
		}
	}
}