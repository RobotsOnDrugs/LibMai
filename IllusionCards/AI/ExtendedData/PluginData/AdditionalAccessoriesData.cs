using System.Xml;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record AdditionalAccessoriesData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.joan6694.illusionplugins.moreaccessories";
			internal const string DataKey = "moreAccessories";
			internal readonly Version PluginVersion = new("1.2.2");
			internal const string RepoURL = "https://bitbucket.org/Joan6694/hsplugins/src/master/MoreAccessoriesAI/";
			internal const string ClassDefinitionsURL = "https://bitbucket.org/Joan6694/hsplugins/src/master/MoreAccessoriesAI/MoreAccessories.cs";
			internal const string? License = null;
		}
		public override Type DataType { get; init; } = typeof(XmlDocument);
		public XmlDocument Data { get; init; }
		public AdditionalAccessoriesData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			string _rawData = (string)dataDict["additionalAccessories"];
			XmlDocument _xmlDoc = new();
			_xmlDoc.LoadXml(_rawData);
			Data = _xmlDoc;
		}
	}
}
