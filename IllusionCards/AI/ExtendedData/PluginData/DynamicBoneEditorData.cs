using System.Collections.Immutable;

using MessagePack;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record DynamicBoneEditorData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.deathweasel.bepinex.dynamicboneeditor";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.0.1");
			internal const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
			internal const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/DynamicBoneEditor.Core/DynamicBoneEditor.Controller.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; } = typeof(ImmutableArray<DynamicBoneData>);
		public ImmutableArray<DynamicBoneData> Data { get; init; }
		public DynamicBoneEditorData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		{
			Data = MessagePackSerializer.Deserialize<List<DynamicBoneData>>((byte[])dataDict["AccessoryDynamicBoneData"]).ToImmutableArray();
		}
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
}
