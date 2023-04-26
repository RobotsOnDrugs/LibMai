namespace LibMai.Cards.AI.Plugins;

public record AdvancedBoneModData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "KKABMX.Core";
		public const string DataKey = "KKABMPlugin.ABMData";
		public static readonly Version PluginVersion = new("4.4.2");
		public const string RepoURL = "https://github.com/ManlyMarco/ABMX";
		public const string ClassDefinitionsURL = "https://github.com/ManlyMarco/ABMX/blob/master/Shared/Core/BoneModifierData.cs";
		public const string License = "LGPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Advanced Bone Modifier eXtended";
	public override Type DataType => Data.GetType();
	public ImmutableArray<BoneModifier> Data { get; init; }

	[MessagePackObject]
	public record BoneModifierData
	{
		[Key(0)]
		public Vector3 ScaleModifier { get; init; }
		[Key(1)]
		public float LengthModifier { get; init; }
		[Key(2)]
		public Vector3 PositionModifier { get; init; }
		[Key(3)]
		public Vector3 RotationModifier { get; init; }
	}
	[MessagePackObject]
	public record BoneModifier
	{
		/// <summary>
		/// Name of the targeted bone
		/// </summary>
		[Key(0)]
		public string BoneName { get; init; } = null!;

		/// <summary>
		/// Actual modifier values, split for different coordinates if required
		/// </summary>
		[Key(1)]
		// Needs a public set to make serializing work
		public BoneModifierData[] CoordinateModifiers { get; init; } = null!;
	}
	public AdvancedBoneModData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		MessagePackSerializerOptions _lz4Option = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block).WithResolver(MathResolver);
		Data = dataDict.TryGetValue((object)"boneData", out object? _rawData)
			? MessagePackSerializer.Deserialize<List<BoneModifier>>((byte[])_rawData, _lz4Option).ToImmutableArray()
			: ImmutableArray<BoneModifier>.Empty;
		//foreach (PropertyInfo property in this.GetType().GetProperties()) { }
	}
}
