namespace IllusionCards.AI.Plugins;

public record KoiSkinOverlayXData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "Clothes Overlay Mod";
		public const string DataKey = "KSOX";
		public static readonly Version PluginVersion = new("6.0.2");
		public const string RepoURL = "https://github.com/ManlyMarco/Illusion-Overlay-Mods";
		public const string ClassDefinitionsURL = "https://github.com/ManlyMarco/Illusion-Overlay-Mods/tree/master/Core_OverlayMods/Skin";
		public const string License = "LGPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Koi Skin Overlay X";
	public override Type DataType => Data.GetType();
	public ImmutableDictionary<TexType, ClothesTexData> Data { get; init; }

	[MessagePackObject]
	public readonly record struct ClothesTexData
	{
		public ClothesTexData() { }
		[Key(0)]
		public byte[] TextureBytes { get => TexturePNG?.ByteData.ToArray() ?? TexBytes; init => TexBytes = value; }

		[Key(1)]
		public bool Override { get; init; }
		[IgnoreMember]
		public PNGByteArray? TexturePNG { get; init; }
		[IgnoreMember]
		public bool IsPNG { get; init; }
		private byte[] TexBytes { get; init; } = null!;
	}
	public enum CoordinateType
	{
		Unknown = 0
	}
	public enum TexType
	{
		Unknown = 0,
		BodyOver = 1,
		FaceOver = 2,
		BodyUnder = 3,
		FaceUnder = 4,
		EyeUnder = 5,
		EyeOver = 6,
		EyeUnderL = 7,
		EyeOverL = 8,
		EyeUnderR = 9,
		EyeOverR = 10
	}
	private const string V2KeyPrefix = "_TextureID_";
	private const string V2ControlKey = "Lookup";
	// Forget CoordinateType because it's always Unknown/0 for AI/HS2 cards
	public KoiSkinOverlayXData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = version switch
		{
			0 or 1 => Version1(dataDict),
			2 => Version2(dataDict),
			_ => throw new InternalCardException($"KoiSkinOverlayXData version {version} is not supported.")
		};
	}
	private static ImmutableDictionary<TexType, ClothesTexData> Version1(Dictionary<object, object> v1data)
	{
		Dictionary<TexType, ClothesTexData> _v1data = new();
		foreach (TexType texType in Enum.GetValues(typeof(TexType)))
		{
			byte[] __v1data;
			if (v1data.TryGetValue(texType.ToString(), out object? _tryval) && (_tryval is not null) && _tryval is byte[] _ && ((byte[])_tryval).Length > 0)
				__v1data = (byte[])_tryval;
			else continue;
			bool _hasPNG = HasPNG(ref __v1data);
			ClothesTexData _texData = new()
			{
				TextureBytes = _hasPNG ? Array.Empty<byte>() : __v1data,
				IsPNG = _hasPNG,
				TexturePNG = _hasPNG ? new() { ByteData = __v1data.ToImmutableArray() } : null
			};
			switch (texType)
			{
				case TexType.EyeOver:
					_v1data.Add(TexType.EyeOverL, _texData);
					_v1data.Add(TexType.EyeOverR, _texData);
					break;
				case TexType.EyeUnder:
					_v1data.Add(TexType.EyeUnderL, _texData);
					_v1data.Add(TexType.EyeUnderR, _texData);
					break;
				default:
					try { _v1data.Add(texType, _texData); }
					catch (ArgumentException) { }
					break;
			}
		}
		return _v1data.ToImmutableDictionary();
	}
	private static ImmutableDictionary<TexType, ClothesTexData> Version2(Dictionary<object, object> v2data)
	{
		if (!(v2data.TryGetValue(V2ControlKey, out object? _tryval) && (_tryval is not null) && _tryval is byte[] _ && ((byte[])_tryval).Length > 0))
			return ImmutableDictionary<TexType, ClothesTexData>.Empty;
		Dictionary<TexType, int> _allOverlayTextures = MessagePackSerializer.Deserialize<Dictionary<CoordinateType, Dictionary<TexType, int>>>((byte[])_tryval)[CoordinateType.Unknown];
		Dictionary<int, ClothesTexData> _texMap = new();
		Dictionary<TexType, ClothesTexData> _v2data = new();
		foreach (KeyValuePair<object, object> rawKvp in v2data.Where(x => ((string)x.Key).StartsWith(V2KeyPrefix)))
		{
			string _idStr = ((string)rawKvp.Key)[V2KeyPrefix.Length..];
			if (!int.TryParse(_idStr, out int id))
				continue;
			byte[]? _rawTexData = (byte[]?)rawKvp.Value;
			if (_rawTexData is null)
				continue;
			bool _hasPNG = HasPNG(ref _rawTexData);
			ClothesTexData _texData = new()
			{
				TextureBytes = _hasPNG ? Array.Empty<byte>() : _rawTexData,
				IsPNG = _hasPNG,
				TexturePNG = _hasPNG ? new() { ByteData = _rawTexData.ToImmutableArray() } : null
			};
			_texMap.Add(id, _texData);
		}
		foreach (KeyValuePair<TexType, int> overlayKvp in _allOverlayTextures)
			_v2data.Add(overlayKvp.Key, _texMap[overlayKvp.Value]);
		return _v2data.ToImmutableDictionary();
	}
	private static bool HasPNG(ref byte[] bytes)
	{
		bool _hasPNG = false;
		if (bytes.Length > 0)
		{
			_hasPNG = true;
			for (int i = 0; i < 5; i++)
			{
				if (bytes[i] != Constants.PNGHeader[i])
					_hasPNG = false;
				i = 5;
			}
		}
		return _hasPNG;
	}
}
