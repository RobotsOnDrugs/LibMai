namespace IllusionCards.AI.ExtendedData.PluginData;

public record ReverseTrapData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public readonly struct DefinitionMetadata
	{
		public const string PluginGUID = "ReverseTrap";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.0");
		public const string RepoURL = "https://github.com/ManlyMarco/IllusionTrapMods";
		public const string ClassDefinitionsURL = "https://github.com/ManlyMarco/IllusionTrapMods/blob/master/AI_ReverseTrap/ReverseTrapController.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Reverse Trap";
	public override Type DataType { get; } = typeof(ReverseTrapOptions);
	public ReverseTrapOptions Data { get; init; }

	public readonly struct ReverseTrapOptions
	{
		public bool ForceMaleAnimations { get; init; }
	}
	public ReverseTrapData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		=> Data = new() { ForceMaleAnimations = NullCheckDictionaryEntries(ref dataDict, "ForceMaleAnimations", false) ?? false };
}
