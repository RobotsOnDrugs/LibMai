namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record AdditionalAccessoriesData : ExtendedPluginData
	{
		public new const string PluginGUID = "moreAccessories";
		public override Type DataType { get; init; } = typeof(Version);
		public Version Data { get; init; }
		public AdditionalAccessoriesData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			string _rawData = (string)dataDict["additionalAccessories"];
			string _versionString = _rawData.ToString().Split(" ")[1].Split("=")[1].Replace("\"", "");
			Data = new Version(_versionString);
		}
	}
}
