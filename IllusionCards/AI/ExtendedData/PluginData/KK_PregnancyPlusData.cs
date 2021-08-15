namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record KK_PregnancyPlusData : ExtendedPluginData
	{
		public new const string PluginGUID = "KK_PregnancyPlus";
		public override Type DataType { get; init; } = typeof(Version);
		public Version Data { get; init; }
		public KK_PregnancyPlusData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			Data = new((string)dataDict["pluginVersion"]);
		}
	}
}
