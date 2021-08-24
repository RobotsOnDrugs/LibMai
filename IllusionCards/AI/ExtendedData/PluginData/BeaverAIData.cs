using System.Collections.Immutable;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record BeaverAIData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "mikke.BeaverAI";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.2.3");
			internal const string RepoURL = "https://bitbucket.org/mikkemikke/mikkeplugins";
			internal const string ClassDefinitionsURL = "https://bitbucket.org/mikkemikke/mikkeplugins/src/master/BeaverAI/BeaverPlugin.cs";
			internal const string? License = null;
		}
		public override Type DataType { get; } = typeof(BeaverInfo);
		public readonly struct BeaverInfo
		{
			public bool PantiesHiding { get; init; }
			public bool PantyHoseHiding { get; init; }
			public bool BottomHiding { get; init; }
			public ImmutableDictionary<int, float>? BeaverShapes { get; init; }
		}
		public BeaverInfo Data { get; }
		public BeaverAIData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
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
}
