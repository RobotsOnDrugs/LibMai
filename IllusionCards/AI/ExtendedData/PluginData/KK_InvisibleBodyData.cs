namespace IllusionCards.AI.ExtendedData.PluginData;
public record KK_InvisibleBodyData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public readonly struct DefinitionMetadata
	{
		public const string PluginGUID = "com.deathweasel.bepinex.invisiblebody";
		public const string DataKey = "KK_InvisibleBody";
		public static readonly Version PluginVersion = new("1.4");
		public const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		public const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/InvisibleBody.Core/Core.InvisibleBody.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Invisible Body";
	public override Type DataType { get; } = typeof(KK_InvisibleBodyOptions);
	public KK_InvisibleBodyOptions Data { get; init; }

	public readonly struct KK_InvisibleBodyOptions { public bool Visible { get; init; } }
	public KK_InvisibleBodyData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		=> Data = new() { Visible = (bool)dataDict["Visible"] };
}
