namespace IllusionCards.AI.Chara;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawCustomData
{
	public AiRawFaceData face { get; init; }
	public AiRawBodyData body { get; init; }
	public AiRawHairData hair { get; init; }

	[MessagePackObject(true)]
	public readonly record struct AiRawFaceData
	{
		public Version version { get; init; } = null!;
		public float[] shapeValueFace { get; init; } = null!;
		public int headId { get; init; }
		public int skinId { get; init; }
		public int detailId { get; init; }
		public float detailPower { get; init; }
		public int eyebrowId { get; init; }
		public Color eyebrowColor { get; init; }
		public Vector4 eyebrowLayout { get; init; }
		public float eyebrowTilt { get; init; }
		public EyesInfo[] pupil { get; init; } = null!;

		public bool pupilSameSetting { get; init; }
		public float pupilY { get; init; }
		public int hlId { get; init; }
		public Color hlColor { get; init; }
		public Vector4 hlLayout { get; init; }
		public float hlTilt { get; init; }
		public float whiteShadowScale { get; init; }
		public int eyelashesId { get; init; }
		public Color eyelashesColor { get; init; }
		public int moleId { get; init; }
		public Color moleColor { get; init; }
		public Vector4 moleLayout { get; init; }
		public MakeupInfo makeup { get; init; }
		public int beardId { get; init; }
		public Color beardColor { get; init; }
		[MessagePackObject(true)]
		public readonly record struct EyesInfo
		{
			public Color whiteColor { get; init; }
			public int pupilId { get; init; }
			public Color pupilColor { get; init; }
			public float pupilW { get; init; }
			public float pupilH { get; init; }
			public float pupilEmission { get; init; }
			public int blackId { get; init; }
			public Color blackColor { get; init; }
			public float blackW { get; init; }
			public float blackH { get; init; }
		}
		[MessagePackObject(true)]
		public readonly record struct MakeupInfo
		{
			public int eyeshadowId { get; init; }
			public Color eyeshadowColor { get; init; }
			public float eyeshadowGloss { get; init; }
			public int cheekId { get; init; }
			public Color cheekColor { get; init; }
			public float cheekGloss { get; init; }
			public int lipId { get; init; }
			public Color lipColor { get; init; }
			public float lipGloss { get; init; }
			[Key("paintInfo")]
			[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Required for MessagePack initialization")]
			private AiRawPaintInfo[] _paintInfo { init => paintInfo = value.ToImmutableArray(); }
			public ImmutableArray<AiRawPaintInfo> paintInfo { get; init; }
		}
	}
	[MessagePackObject(true)]
	public readonly record struct AiRawBodyData
	{
		public Version version { get; init; } = null!;
		[Key("shapeValueBody")]
		[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Required for MessagePack initialization")]
		private float[] _shapeValueBody { init => shapeValueBody = value.ToImmutableArray(); }
		public ImmutableArray<float> shapeValueBody { get; init; }
		public float bustSoftness { get; init; }
		public float bustWeight { get; init; }
		public int skinId { get; init; }
		public int detailId { get; init; }
		public float detailPower { get; init; }
		public Color skinColor { get; init; }
		public float skinGlossPower { get; init; }
		public float skinMetallicPower { get; init; }
		public int sunburnId { get; init; }
		public Color sunburnColor { get; init; }
		[Key("paintInfo")]
		[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Required for MessagePack initialization")]
		private AiRawPaintInfo[] _paintInfo { init => paintInfo = value.ToImmutableArray(); }
		public ImmutableArray<AiRawPaintInfo> paintInfo { get; init; }
		public int nipId { get; init; }
		public Color nipColor { get; init; }
		public float nipGlossPower { get; init; }
		public float areolaSize { get; init; }
		public int underhairId { get; init; }
		public Color underhairColor { get; init; }
		public Color nailColor { get; init; }
		public float nailGlossPower { get; init; }
	}
	[MessagePackObject(true)]
	public readonly record struct AiRawHairData
	{
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

	[MessagePackObject(true)]
	public readonly record struct AiRawPaintInfo
	{
		public int id { get; init; }
		public Color color { get; init; }
		public float glossPower { get; init; }
		public float metallicPower { get; init; }
		public int layoutId { get; init; }
		public Vector4 layout { get; init; }
		public float rotation { get; init; }
	}

	[IgnoreMember]
	internal bool IsInitialized { get; init; } = false;

	// In case it's important:
	// BustSizeKind is determined by body.shapeValueBody[1] - 0 if =< 0.33f, 2 if >= 0.66f, 1 if in between
	// HeightKind is determined by body.shapeValueBody[0] - 0 if =< 0.33f, 2 if >= 0.66f, 1 if in between
	public AiRawCustomData(byte[] customData)
	{
		MessagePackSerializer.DefaultOptions = WithMathTypes;
		byte[][] _dataChunks = Helpers.GetDataChunks(customData, 3);
		face = MessagePackSerializer.Deserialize<AiRawFaceData>(_dataChunks[0]);
		body = MessagePackSerializer.Deserialize<AiRawBodyData>(_dataChunks[1]);
		hair = MessagePackSerializer.Deserialize<AiRawHairData>(_dataChunks[2]);
		if (face.version < AiFaceVersion) { throw new InternalCardException("Face data for this card is too old."); }
		if (body.version < AiBodyVersion) { throw new InternalCardException("Body data for this card is too old."); }
		if (hair.version < AiHairVersion) { throw new InternalCardException("Hair data for this card is too old."); }
		IsInitialized = true;
	}
}
