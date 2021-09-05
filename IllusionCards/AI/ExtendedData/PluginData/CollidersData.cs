namespace IllusionCards.AI.ExtendedData.PluginData;

public record CollidersData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public const string OldDataKey = DefinitionMetadata.OldDataKey;
	private readonly struct DefinitionMetadata
	{
		internal const string PluginGUID = "com.deathweasel.bepinex.colliders";
		internal const string DataKey = PluginGUID;
		internal const string OldDataKey = "com.deathweasel.bepinex.studiocolliders";
		internal readonly Version PluginVersion = new("1.2");
		internal const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		internal const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/Colliders.Core/Core.Colliders.Controller.cs";
		internal const string License = "GPL 3.0";
	}
	public override Type DataType { get; } = typeof(CollidersOptions);
	public CollidersOptions Data { get; init; }
	public readonly struct CollidersOptions
	{
		public bool BreastCollidersEnabled { get; init; }
		public bool SkirtCollidersEnabled { get; init; }
		public bool FloorColliderEnabled { get; init; }
	}
	public CollidersData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new()
		{
			BreastCollidersEnabled = dataDict.TryGetValue("BreastCollidersEnabled", out object? _tryval) && (_tryval is not null) && (bool)_tryval,
			SkirtCollidersEnabled = dataDict.TryGetValue("SkirtCollidersEnabled", out _tryval) && (_tryval is not null) && (bool)_tryval,
			FloorColliderEnabled = dataDict.TryGetValue("FloorColliderEnabled", out _tryval) && (_tryval is not null) && (bool)_tryval
		};
	}
}
