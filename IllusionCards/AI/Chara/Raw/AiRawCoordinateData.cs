namespace IllusionCards.AI.Chara;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawCoordinateData
{
	public Version LoadVersion { get; init; }
	public int Language { get; init; }
	public AiRawClothesData clothes { get; init; }
	public AiRawAccessoryData accessory { get; init; }

	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly record struct AiRawClothesData
	{
		public Version version { get; init; } = null!;
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

	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly record struct AiRawAccessoryData
	{
		public Version version { get; init; } = null!;
		public AccessoryPartsInfo[] parts { get; init; } = null!;
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public readonly record struct AccessoryPartsInfo
		{
			public int type { get; init; }
			public int id { get; init; }
			public string parentKey { get; init; } = null!;

			public Vector3[,] addmove { get; init; } = new Vector3[,] { };
			public ColorInfo[] colorInfo { get; init; } = null!;
			public int hideCategory { get; init; }
			public int hideTiming { get; init; }
			public bool noShake { get; init; }
			[IgnoreMember]
			public bool partsOfHead { get; init; }
			[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
			public readonly record struct ColorInfo
			{
				public Color color { get; init; }
				public float glossPower { get; init; }
				public float metallicPower { get; init; }
				public float smoothnessPower { get; init; }
			}
		}
	}

	[IgnoreMember]
	internal bool IsInitialized { get; init; } = false;
	public AiRawCoordinateData(byte[] coordinateData, Version loadVersion, int language)
	{
		MessagePackSerializer.DefaultOptions = WithMathTypes;
		byte[][] _dataChunks = Helpers.GetDataChunks(coordinateData, 2);
		clothes = MessagePackSerializer.Deserialize<AiRawClothesData>(_dataChunks[0]);
		accessory = MessagePackSerializer.Deserialize<AiRawAccessoryData>(_dataChunks[1]);
		if (clothes.version < AiClothesVersion) { throw new InternalCardException("Clothes data for this card is too old."); }
		if (accessory.version < AiAccessoryVersion) { throw new InternalCardException("Accessory data for this card is too old."); }
		IsInitialized = true;
		LoadVersion = loadVersion;
		Language = language;
	}
}
