namespace IllusionCards.AI.Plugins;

public record PushUpAIData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "mikke.pushUpAI";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("2.1.1");
		public const string RepoURL = "https://bitbucket.org/mikkemikke/mikkeplugins/src/master/PushUpAI/";
		public const string ClassDefinitionsURL = "https://bitbucket.org/mikkemikke/mikkeplugins/src/master/PushUpAI/PushUpController.cs";
		public const string? License = null;
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "PushUp AI";
	public override Type DataType => Data.GetType();
	public PushUpAIOptions Data { get; init; }

	public readonly record struct PushUpAIOptions
	{
		public ClothData BraClothData { get; init; }
		public ClothData TopClothData { get; init; }
		public readonly record struct ClothData
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
	public PushUpAIData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new()
		{
			BraClothData = new()
			{
				Firmness = NullCheckDictionaryEntries(dataDict, "FIRMNESS", 0f),
				Lift = NullCheckDictionaryEntries(dataDict, "LIFT", 0f),
				PushTogether = NullCheckDictionaryEntries(dataDict, "PUSH_TOGETHER", 0f),
				Squeeze = NullCheckDictionaryEntries(dataDict, "SQUEEZE", 0f),
				CenterNipples = NullCheckDictionaryEntries(dataDict, "CENTER_NIPPLES", 0f),
				FlattenNipples = NullCheckDictionaryEntries(dataDict, "FLATTEN_NIPPLES", false),
				EnablePushUp = NullCheckDictionaryEntries(dataDict, "ENABLE_PUSHUP", false),
				HideAccessories = NullCheckDictionaryEntries(dataDict, "HIDE_ACCESSORIES", false),
				HideNipples = NullCheckDictionaryEntries(dataDict, "HIDE_NIPPLES", false),
				Corset = NullCheckDictionaryEntries(dataDict, "CORSET", 0f),
				CorsetHalf = NullCheckDictionaryEntries(dataDict, "CORSET_HALF", false),
			},
			TopClothData = new()
			{
				Firmness = NullCheckDictionaryEntries(dataDict, "TOP_FIRMNESS", 0f),
				Lift = NullCheckDictionaryEntries(dataDict, "TOP_LIFT", 0f),
				PushTogether = NullCheckDictionaryEntries(dataDict, "TOP_PUSH_TOGETHER", 0f),
				Squeeze = NullCheckDictionaryEntries(dataDict, "TOP_SQUEEZE", 0f),
				CenterNipples = NullCheckDictionaryEntries(dataDict, "TOP_CENTER_NIPPLES", 0f),
				FlattenNipples = NullCheckDictionaryEntries(dataDict, "TOP_FLATTEN_NIPPLES", false),
				EnablePushUp = NullCheckDictionaryEntries(dataDict, "TOP_ENABLE_PUSHUP", false),
				HideAccessories = NullCheckDictionaryEntries(dataDict, "TOP_HIDE_ACCESSORIES", false),
				HideNipples = NullCheckDictionaryEntries(dataDict, "TOP_HIDE_NIPPLES", false),
				Corset = NullCheckDictionaryEntries(dataDict, "TOP_CORSET", 0f),
				CorsetHalf = NullCheckDictionaryEntries(dataDict, "TOP_CORSET_HALF", false),
			}
		};
	}
}
