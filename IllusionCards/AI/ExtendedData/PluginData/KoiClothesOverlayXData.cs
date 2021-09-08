namespace IllusionCards.AI.ExtendedData.PluginData;

public record KoiClothesOverlayXData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public readonly struct DefinitionMetadata
	{
		public const string PluginGUID = "Clothes Overlay Mod";
		public const string DataKey = "KCOX";
		public static readonly Version PluginVersion = new("6.0.2");
		public const string RepoURL = "https://github.com/ManlyMarco/Illusion-Overlay-Mods";
		public const string ClassDefinitionsURL = "https://github.com/ManlyMarco/Illusion-Overlay-Mods/blob/master/Core_OverlayMods/Clothes/KoiClothesOverlayController.cs";
		public const string License = "LGPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Koi Clothes Overlay X";
	public override Type DataType { get; } = typeof(ImmutableDictionary<string, ClothesTexData>);
	public ImmutableDictionary<string, ClothesTexData> Data { get; }

	[MessagePackObject]
	public readonly struct ClothesTexData
	{
		[Key(0)]
		public byte[] TextureBytes { get; init; }

		[Key(1)]
		public bool Override { get; init; }
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
	// Forget CoordinateType because it's always Unknown/0 for AI/HS2 cards
	public KoiClothesOverlayXData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Dictionary<string, ClothesTexData> _overlayData = dataDict.TryGetValue("Overlays", out object? _tryval) && (_tryval is not null) ?
			MessagePackSerializer.Deserialize<Dictionary<CoordinateType, Dictionary<string, ClothesTexData>>>((byte[])_tryval).TryGetValue(CoordinateType.Unknown, out Dictionary<string, ClothesTexData>? _tryval2) && (_tryval2 is not null) ?
				_tryval2 : new()
			: new();
		Data = _overlayData.ToImmutableDictionary();
	}
}
