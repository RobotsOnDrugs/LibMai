namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record PushUpAIData : ExtendedPluginData
	{
		public new const string PluginGUID = "mikke.pushUpAI";
		public override Type DataType { get; init; } = typeof(PushUpAIOptions);
		public readonly struct PushUpAIOptions
		{
			public float FIRMNESS { get; init; }
			public float LIFT { get; init; }
			public float PUSH_TOGETHER { get; init; }
			public float SQUEEZE { get; init; }
			public float CENTER_NIPPLES { get; init; }
			public bool FLATTEN_NIPPLES { get; init; }
			public bool ENABLE_PUSHUP { get; init; }
			public bool HIDE_ACCESSORIES { get; init; }
			public bool HIDE_NIPPLES { get; init; }
			public float CORSET { get; init; }
			public bool CORSET_HALF { get; init; }
			public float TOP_FIRMNESS { get; init; }
			public float TOP_LIFT { get; init; }
			public float TOP_PUSH_TOGETHER { get; init; }
			public float TOP_SQUEEZE { get; init; }
			public float TOP_CENTER_NIPPLES { get; init; }
			public bool TOP_FLATTEN_NIPPLES { get; init; }
			public bool TOP_ENABLE_PUSHUP { get; init; }
			public bool TOP_HIDE_ACCESSORIES { get; init; }
			public bool TOP_HIDE_NIPPLES { get; init; }
			public float TOP_CORSET { get; init; }
			public bool TOP_CORSET_HALF { get; init; }
		}
		public PushUpAIOptions Data { get; init; }
		public PushUpAIData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			Data = new()
			{
				FIRMNESS = (float)dataDict["FIRMNESS"],
				LIFT = (float)dataDict["LIFT"],
				PUSH_TOGETHER = (float)dataDict["PUSH_TOGETHER"],
				SQUEEZE = (float)dataDict["SQUEEZE"],
				CENTER_NIPPLES = (float)dataDict["CENTER_NIPPLES"],
				FLATTEN_NIPPLES = (bool)dataDict["FLATTEN_NIPPLES"],
				ENABLE_PUSHUP = (bool)dataDict["ENABLE_PUSHUP"],
				HIDE_ACCESSORIES = (bool)dataDict["HIDE_ACCESSORIES"],
				HIDE_NIPPLES = (bool)dataDict["HIDE_NIPPLES"],
				CORSET = (float)dataDict["CORSET"],
				CORSET_HALF = (bool)dataDict["CORSET_HALF"],
				TOP_FIRMNESS = (float)dataDict["TOP_FIRMNESS"],
				TOP_LIFT = (float)dataDict["TOP_LIFT"],
				TOP_PUSH_TOGETHER = (float)dataDict["TOP_PUSH_TOGETHER"],
				TOP_SQUEEZE = (float)dataDict["TOP_SQUEEZE"],
				TOP_CENTER_NIPPLES = (float)dataDict["TOP_CENTER_NIPPLES"],
				TOP_FLATTEN_NIPPLES = (bool)dataDict["TOP_FLATTEN_NIPPLES"],
				TOP_ENABLE_PUSHUP = (bool)dataDict["TOP_ENABLE_PUSHUP"],
				TOP_HIDE_ACCESSORIES = (bool)dataDict["TOP_HIDE_ACCESSORIES"],
				TOP_HIDE_NIPPLES = (bool)dataDict["TOP_HIDE_NIPPLES"],
				TOP_CORSET = (float)dataDict["TOP_CORSET"],
				TOP_CORSET_HALF = (bool)dataDict["TOP_CORSET_HALF"]
			};
		}
	}
}
