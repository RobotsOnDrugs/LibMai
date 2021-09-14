namespace IllusionCards.AI.ExtendedData.PluginData;

public record BeaverAIData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "mikke.BeaverAI";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.2.3");
		public const string RepoURL = "https://bitbucket.org/mikkemikke/mikkeplugins";
		public const string ClassDefinitionsURL = "https://bitbucket.org/mikkemikke/mikkeplugins/src/master/BeaverAI/BeaverPlugin.cs";
		public const string? License = null;
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "BeaverAI";
	public override Type DataType => Data.GetType();
	public BeaverInfo Data { get; }

	public readonly record struct BeaverInfo
	{
		public bool PantiesHiding { get; init; }
		public bool PantyHoseHiding { get; init; }
		public bool BottomHiding { get; init; }
		public ImmutableDictionary<int, float>? BeaverShapes { get; init; }
	}
	public BeaverAIData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Dictionary<object, object>? _shapesRaw = new();
		_shapesRaw = dataDict.TryGetValue("K_SHAPES", out object? _tryval) ? (Dictionary<object, object>)_tryval : null;
		ImmutableDictionary<int, float>? _shapesData = _shapesRaw?.ToImmutableDictionary(pair => (int)pair.Key, pair => (float)pair.Value);
		Data = new BeaverInfo()
		{
			PantiesHiding = dataDict.TryGetValue("K_PANTIES", out _tryval) && (bool)_tryval,
			PantyHoseHiding = dataDict.TryGetValue("K_PANTYHOSE", out _tryval) && (bool)_tryval,
			BottomHiding = dataDict.TryGetValue("K_BOTTOM", out _tryval) && (bool)_tryval,
			BeaverShapes = _shapesData
		};
	}
}
