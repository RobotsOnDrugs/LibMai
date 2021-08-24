using System.Xml;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record AIHS2PEData : ExtendedPluginData
	{
		public const string DataKeyAI = DefinitionMetadata.DataKeyAI;
		public const string DataKeyHS2 = DefinitionMetadata.DataKeyHS2;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.joan6694.illusionplugins.poseeditor";
			internal const string DataKeyAI = "aipe";
			internal const string DataKeyHS2 = "hs2pe";
			internal readonly Version PluginVersion = new("2.12.0");
			internal const string RepoURL = "https://bitbucket.org/Joan6694/hsplugins";
			internal const string ClassDefinitionsURL = "https://bitbucket.org/Joan6694/hsplugins/src/master/HSPE/CharaPoseController.cs";
			internal const string? License = null;
		}
		public override Type DataType { get; } = typeof(XmlDocument);
		public XmlDocument Data { get; init; }
		public AIHS2PEData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		{
			string _rawData = (string)dataDict["characterInfo"];
			XmlDocument _xmlDoc = new();
			_xmlDoc.LoadXml(_rawData);
			Data = _xmlDoc;
		}
	}
}
