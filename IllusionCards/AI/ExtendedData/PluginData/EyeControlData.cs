namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record EyeControlData : ExtendedPluginData
	{
		public new const string PluginGUID = "com.deathweasel.bepinex.eyecontrol";
		public override Type DataType { get; init; } = typeof(EyeControlOptions);
		public readonly struct EyeControlOptions
		{
			public float EyeOpenMax { get; init; }
			public bool DisableBlinking { get; init; }
		}
		public EyeControlOptions Data { get; init; }
		public EyeControlData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			Data = new EyeControlOptions()
			{
				EyeOpenMax = (float)dataDict["EyeOpenMax"],
				DisableBlinking = (bool)dataDict["DisableBlinking"]
			};
		}
	}
}
