namespace IllusionCards.AI.Plugins;

public record ReverseTrapData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
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
	public override Type DataType => Data.GetType();
	public ReverseTrapOptions Data { get; init; }

	public readonly record struct ReverseTrapOptions
	{
		public bool ForceMaleAnimations { get; init; }
	}
	public ReverseTrapData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
		=> Data = new() { ForceMaleAnimations = NullCheckDictionaryEntries(dataDict, "ForceMaleAnimations", false) ?? false };
}
