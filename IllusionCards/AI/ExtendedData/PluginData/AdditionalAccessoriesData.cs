namespace IllusionCards.AI.ExtendedData.PluginData;

public record AdditionalAccessoriesData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public readonly struct DefinitionMetadata
	{
		public const string PluginGUID = "com.joan6694.illusionplugins.moreaccessories";
		public const string DataKey = "moreAccessories";
		public static readonly Version PluginVersion = new("1.2.2");
		public const string RepoURL = "https://bitbucket.org/Joan6694/hsplugins";
		public const string ClassDefinitionsURL = "https://bitbucket.org/Joan6694/hsplugins/src/master/MoreAccessoriesAI/MoreAccessories.cs";
		public const string? License = null;
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override Type DataType { get; } = typeof(XmlDocument);
	public XmlDocument Data { get; init; }

	public AdditionalAccessoriesData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		string _rawData = NullCheckDictionaryEntries(ref dataDict, "additionalAccessories", "") ?? "";
		XmlDocument _xmlDoc = new();
		_xmlDoc.LoadXml(_rawData);
		Data = _xmlDoc;
	}
}
