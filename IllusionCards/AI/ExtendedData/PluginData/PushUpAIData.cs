namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record PushUpAIData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "mikke.pushUpAI";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("2.1.1");
			internal const string RepoURL = "https://bitbucket.org/mikkemikke/mikkeplugins/src/master/PushUpAI/";
			internal const string ClassDefinitionsURL = "https://bitbucket.org/mikkemikke/mikkeplugins/src/master/PushUpAI/PushUpController.cs";
			internal const string? License = null;
		}
		public override Type DataType { get; init; } = typeof(PushUpAIOptions);
		public readonly struct PushUpAIOptions
		{
			public ClothData BraClothData { get; init; }
			public ClothData TopClothData { get; init; }
			public readonly struct ClothData
			{
				public float? Firmness { get; init; }
				public float? Lift { get; init; }
				public float? PushTogether { get; init; }
				public float? Squeeze { get; init; }
				public bool? FlattenNipples { get; init; }
				public bool? HideNipples { get; init; }
				public bool? EnablePushUp { get; init; }
				public float? CenterNipples { get; init; }
				public bool? HideAccessories { get; init; }
				public float? Corset { get; init; }
				public bool? CorsetHalf { get; init; }
			}
		}
		public PushUpAIOptions Data { get; init; }
		public PushUpAIData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			Data = new()
			{
				BraClothData = new()
				{
					Firmness = dataDict.TryGetValue("FIRMNESS", out object? _tryval) ? (float)_tryval : null,
					Lift = dataDict.TryGetValue("LIFT", out _tryval) ? (float)_tryval : null,
					PushTogether = dataDict.TryGetValue("PUSH_TOGETHER", out _tryval) ? (float)_tryval : null,
					Squeeze = dataDict.TryGetValue("SQUEEZE", out _tryval) ? (float)_tryval : null,
					CenterNipples = dataDict.TryGetValue("CENTER_NIPPLES", out _tryval) ? (float)_tryval : null,
					FlattenNipples = dataDict.TryGetValue("FLATTEN_NIPPLES", out _tryval) ? (bool)_tryval : null,
					EnablePushUp = dataDict.TryGetValue("ENABLE_PUSHUP", out _tryval) ? (bool)_tryval : null,
					HideAccessories = dataDict.TryGetValue("HIDE_ACCESSORIES", out _tryval) ? (bool)_tryval : null,
					HideNipples = dataDict.TryGetValue("HIDE_NIPPLES", out _tryval) ? (bool)_tryval : null,
					Corset = dataDict.TryGetValue("CORSET", out _tryval) ? (float)_tryval : null,
					CorsetHalf = dataDict.TryGetValue("CORSET_HALF", out _tryval) ? (bool)_tryval : null
				},
				TopClothData = new()
				{
					Firmness = dataDict.TryGetValue("TOP_FIRMNESS", out _tryval) ? (float)_tryval : null,
					Lift = dataDict.TryGetValue("TOP_LIFT", out _tryval) ? (float)_tryval : null,
					PushTogether = dataDict.TryGetValue("TOP_PUSH_TOGETHER", out _tryval) ? (float)_tryval : null,
					Squeeze = dataDict.TryGetValue("TOP_SQUEEZE", out _tryval) ? (float)_tryval : null,
					CenterNipples = dataDict.TryGetValue("TOP_CENTER_NIPPLES", out _tryval) ? (float)_tryval : null,
					FlattenNipples = dataDict.TryGetValue("TOP_FLATTEN_NIPPLES", out _tryval) ? (bool)_tryval : null,
					EnablePushUp = dataDict.TryGetValue("TOP_ENABLE_PUSHUP", out _tryval) ? (bool)_tryval : null,
					HideAccessories = dataDict.TryGetValue("TOP_HIDE_ACCESSORIES", out _tryval) ? (bool)_tryval : null,
					HideNipples = dataDict.TryGetValue("TOP_HIDE_NIPPLES", out _tryval) ? (bool)_tryval : null,
					Corset = dataDict.TryGetValue("TOP_CORSET", out _tryval) ? (float)_tryval : null,
					CorsetHalf = dataDict.TryGetValue("TOP_CORSET_HALF", out _tryval) ? (bool)_tryval : null
				}
			};
		}
	}
}
