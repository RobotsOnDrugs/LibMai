namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record KK_InvisibleBodyData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.deathweasel.bepinex.invisiblebody";
			internal const string DataKey = "KK_InvisibleBody";
			internal readonly Version PluginVersion = new("1.4");
			internal const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
			internal const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/InvisibleBody.Core/Core.InvisibleBody.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; } = typeof(KK_InvisibleBodyOptions);
		public readonly struct KK_InvisibleBodyOptions { public bool Visible { get; init; } }
		public KK_InvisibleBodyOptions Data { get; init; }
		public KK_InvisibleBodyData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
			=> Data = new() { Visible = (bool)dataDict["Visible"] };
	}
}
