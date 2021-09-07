namespace IllusionCards.AI.ExtendedData.PluginData;

public record DynamicBoneEditorData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public readonly struct DefinitionMetadata
	{
		public const string PluginGUID = "com.deathweasel.bepinex.dynamicboneeditor";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.0.1");
		public const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		public const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/DynamicBoneEditor.Core/DynamicBoneEditor.Controller.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override Type DataType { get; } = typeof(ImmutableArray<DynamicBoneData>);
	public ImmutableArray<DynamicBoneData> Data { get; init; }

	public DynamicBoneEditorData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		=> Data = MessagePackSerializer.Deserialize<List<DynamicBoneData>>((byte[])dataDict["AccessoryDynamicBoneData"]).ToImmutableArray();
}
[MessagePackObject]
public record DynamicBoneData
{
	[Key(nameof(CoordinateIndex))]
	public int CoordinateIndex;
	[Key(nameof(Slot))]
	public int Slot;
	[Key(nameof(BoneName))]
	public string BoneName = null!;

	[Key(nameof(FreezeAxis))]
	public DynamicBone.FreezeAxis? FreezeAxis = null;
	[Key(nameof(Weight))]
	public float? Weight = null;
	[Key(nameof(Damping))]
	public float? Damping = null;
	[Key(nameof(Elasticity))]
	public float? Elasticity = null;
	[Key(nameof(Stiffness))]
	public float? Stiffness = null;
	[Key(nameof(Inertia))]
	public float? Inertia = null;
	[Key(nameof(Radius))]
	public float? Radius = null;

	[Key(nameof(FreezeAxisOriginal))]
	public DynamicBone.FreezeAxis? FreezeAxisOriginal;
	[Key(nameof(WeightOriginal))]
	public float? WeightOriginal;
	[Key(nameof(DampingOriginal))]
	public float? DampingOriginal;
	[Key(nameof(ElasticityOriginal))]
	public float? ElasticityOriginal;
	[Key(nameof(StiffnessOriginal))]
	public float? StiffnessOriginal;
	[Key(nameof(InertiaOriginal))]
	public float? InertiaOriginal;
	[Key(nameof(RadiusOriginal))]
	public float? RadiusOriginal;
}
public readonly struct DynamicBone { public enum FreezeAxis { None, X, Y, Z } }
