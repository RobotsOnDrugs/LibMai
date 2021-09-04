namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record ReverseTrapData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "ReverseTrap";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.0");
			internal const string RepoURL = "https://github.com/ManlyMarco/IllusionTrapMods";
			internal const string ClassDefinitionsURL = "https://github.com/ManlyMarco/IllusionTrapMods/blob/master/AI_ReverseTrap/ReverseTrapController.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; } = typeof(ReverseTrapOptions);
		public ReverseTrapOptions Data { get; init; }
		public readonly struct ReverseTrapOptions
		{
			public bool ForceMaleAnimations { get; init; }
		}
		public ReverseTrapData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
			=> Data = new() { ForceMaleAnimations = NullCheckDictionaryEntries(ref dataDict, "ForceMaleAnimations", false) ?? false };
	}
}
