namespace IllusionCards.AI.ExtendedData.PluginData;

public record AdvancedBoneModData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	private readonly struct DefinitionMetadata
	{
		internal const string PluginGUID = "KKABMX.Core";
		internal const string DataKey = "KKABMPlugin.ABMData";
		internal readonly Version PluginVersion = new("4.4.2");
		internal const string RepoURL = "https://github.com/ManlyMarco/ABMX";
		internal const string ClassDefinitionsURL = "https://github.com/ManlyMarco/ABMX/blob/master/Shared/Core/BoneModifierData.cs";
		internal const string License = "LGPL 3.0";
	}
	public override Type DataType { get; } = typeof(List<BoneModifier>);
	public ImmutableArray<BoneModifier> Data { get; }
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
	public AdvancedBoneModData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		MessagePackSerializerOptions _lz4Option = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block).WithResolver(MathResolver);
		Data = dataDict.TryGetValue((object)"boneData", out object? _rawData)
			? MessagePackSerializer.Deserialize<List<BoneModifier>>((byte[])_rawData, _lz4Option).ToImmutableArray()
			: ImmutableArray<BoneModifier>.Empty;
		//foreach (PropertyInfo property in this.GetType().GetProperties()) { }
	}
}
