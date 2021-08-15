namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record KK_InvisibleBodyData : ExtendedPluginData
	{
		public new const string PluginGUID = "KK_InvisibleBody";
		public override Type DataType { get; init; } = typeof(KK_InvisibleBodyOptions);
		public readonly struct KK_InvisibleBodyOptions { public bool Visible { get; init; } }
		public KK_InvisibleBodyOptions Data { get; init; }
		public KK_InvisibleBodyData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			Data = new() { Visible = (bool)dataDict["Visible"] };
		}
	}
}
