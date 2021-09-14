namespace IllusionCards.AI.ExtendedData.PluginData;

public record CollidersData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public const string OldDataKey = DefinitionMetadata.OldDataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "com.deathweasel.bepinex.colliders";
		public const string DataKey = PluginGUID;
		public const string OldDataKey = "com.deathweasel.bepinex.studiocolliders";
		public static readonly Version PluginVersion = new("1.2");
		public const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		public const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/Colliders.Core/Core.Colliders.Controller.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Colliders";
	public override Type DataType => Data.GetType();
	public CollidersOptions Data { get; init; }

	public readonly record struct CollidersOptions
	{
		public bool BreastCollidersEnabled { get; init; }
		public bool SkirtCollidersEnabled { get; init; }
		public bool FloorColliderEnabled { get; init; }
	}
	public CollidersData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new()
		{
			BreastCollidersEnabled = dataDict.TryGetValue("BreastCollidersEnabled", out object? _tryval) && (_tryval is not null) && (bool)_tryval,
			SkirtCollidersEnabled = dataDict.TryGetValue("SkirtCollidersEnabled", out _tryval) && (_tryval is not null) && (bool)_tryval,
			FloorColliderEnabled = dataDict.TryGetValue("FloorColliderEnabled", out _tryval) && (_tryval is not null) && (bool)_tryval
		};
	}
}
