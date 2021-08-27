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
		public override Type DataType { get; } = typeof(PushUpAIOptions);
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
		public PushUpAIData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		{
			Data = new()
			{
				BraClothData = new()
				{
					Firmness = NullCheckDictionaryEntries(ref dataDict, "FIRMNESS", 0f),
					Lift = NullCheckDictionaryEntries(ref dataDict, "LIFT", 0f),
					PushTogether = NullCheckDictionaryEntries(ref dataDict, "PUSH_TOGETHER", 0f),
					Squeeze = NullCheckDictionaryEntries(ref dataDict, "SQUEEZE", 0f),
					CenterNipples = NullCheckDictionaryEntries(ref dataDict, "CENTER_NIPPLES", 0f),
					FlattenNipples = NullCheckDictionaryEntries(ref dataDict, "FLATTEN_NIPPLES", false),
					EnablePushUp = NullCheckDictionaryEntries(ref dataDict, "ENABLE_PUSHUP", false),
					HideAccessories = NullCheckDictionaryEntries(ref dataDict, "HIDE_ACCESSORIES", false),
					HideNipples = NullCheckDictionaryEntries(ref dataDict, "HIDE_NIPPLES", false),
					Corset = NullCheckDictionaryEntries(ref dataDict, "CORSET", 0f),
					CorsetHalf = NullCheckDictionaryEntries(ref dataDict, "CORSET_HALF", false),
				},
				TopClothData = new()
				{
					Firmness = NullCheckDictionaryEntries(ref dataDict, "TOP_FIRMNESS", 0f),
					Lift = NullCheckDictionaryEntries(ref dataDict, "TOP_LIFT", 0f),
					PushTogether = NullCheckDictionaryEntries(ref dataDict, "TOP_PUSH_TOGETHER", 0f),
					Squeeze = NullCheckDictionaryEntries(ref dataDict, "TOP_SQUEEZE", 0f),
					CenterNipples = NullCheckDictionaryEntries(ref dataDict, "TOP_CENTER_NIPPLES", 0f),
					FlattenNipples = NullCheckDictionaryEntries(ref dataDict, "TOP_FLATTEN_NIPPLES", false),
					EnablePushUp = NullCheckDictionaryEntries(ref dataDict, "TOP_ENABLE_PUSHUP", false),
					HideAccessories = NullCheckDictionaryEntries(ref dataDict, "TOP_HIDE_ACCESSORIES", false),
					HideNipples = NullCheckDictionaryEntries(ref dataDict, "TOP_HIDE_NIPPLES", false),
					Corset = NullCheckDictionaryEntries(ref dataDict, "TOP_CORSET", 0f),
					CorsetHalf = NullCheckDictionaryEntries(ref dataDict, "TOP_CORSET_HALF", false),
				}
			};
		}
	}
}
