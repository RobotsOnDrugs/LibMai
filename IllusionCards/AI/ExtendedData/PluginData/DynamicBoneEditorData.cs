using MessagePack;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record DynamicBoneEditorData : ExtendedPluginData
	{
		public new const string PluginGUID = "com.deathweasel.bepinex.dynamicboneeditor";
		public override Type DataType { get; init; } = typeof(byte[]);
		public List<DynamicBoneData> Data { get; init; }
		public DynamicBoneEditorData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			Data = MessagePackSerializer.Deserialize<List<DynamicBoneData>>((byte[])dataDict["AccessoryDynamicBoneData"]);
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
	public record DynamicBone { public enum FreezeAxis { None, X, Y, Z } }
}
