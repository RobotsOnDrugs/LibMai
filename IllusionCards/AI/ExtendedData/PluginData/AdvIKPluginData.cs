using IllusionCards.FakeUnity;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record AdvIKPluginData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "orange.spork.advikplugin";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.6.3");
			internal const string RepoURL = "https://github.com/OrangeSpork/AdvIKPlugin";
			internal const string ClassDefinitionsURL = "https://github.com/OrangeSpork/AdvIKPlugin/blob/master/AdvIKPlugin/AdvIKCharaController.cs";
			internal const string? License = null;
		}
		public override Type DataType { get; init; } = typeof(AdvIKPluginOptions);
		public readonly struct AdvIKPluginOptions
		{
			public bool? ShoulderRotationEnabled { get; init; }
			public bool? IndependentShoulders { get; init; }
			public float? ShoulderWeight { get; init; }
			public float? ShoulderRightWeight { get; init; }
			public float? ShoulderOffset { get; init; }
			public float? ShoulderRightOffset { get; init; }
			public float? SpineStiffness { get; init; }
			public bool? EnableSpineFKHints { get; init; }
			public bool? EnableShoulderFKHints { get; init; }
			public bool? ReverseShoulderL { get; init; }
			public bool? ReverseShoulderR { get; init; }
			public bool? EnableToeFKHints { get; init; }
			public bool? Enabled { get; init; }
			public float? IntakePause { get; init; }
			public float? HoldPause { get; init; }
			public float? InhalePercentage { get; init; }
			public int? BreathsPerMinute { get; init; }
			public bool? MagnitudeData { get; init; }
			public Vector3? BreathMagnitude { get; init; }
			public Vector3? UpperChestRelativeScaling { get; init; }
			public Vector3? LowerChestRelativeScaling { get; init; }
			public Vector3? AbdomenRelativeScaling { get; init; }
			public float? ShoulderDampeningFactor { get; init; }
			public float? MagnitudeFactor { get; init; }
			public IKResizeCentroid? ResizeCentroid { get; init; }
			public Dictionary<IKChain, IKResizeChainAdjustment>? ChainAdjustments { get; init; }
		}
		public enum IKChain
		{
			BODY = 0,
			LEFT_ARM = 1,
			LEFT_LEG = 2,
			RIGHT_ARM = 3,
			RIGHT_LEG = 4
		}
		public enum IKResizeChainAdjustment
		{
			OFF = 1,
			CHAIN = 2
		}
		public enum IKResizeCentroid
		{
			NONE = 0,
			AUTO = 1,
			FEET_CENTER = 2,
			FEET_LEFT = 3,
			FEET_RIGHT = 4,
			THIGH_CENTER = 5,
			THIGH_LEFT = 6,
			THIGH_RIGHT = 7,
			BODY = 8,
			SHOULDER_CENTER = 9,
			SHOULDER_LEFT = 10,
			SHOULDER_RIGHT = 11,
			HAND_CENTER = 12,
			HAND_LEFT = 13,
			HAND_RIGHT = 14,
			KNEE_CENTER = 15,
			KNEE_LEFT = 16,
			KNEE_RIGHT = 17,
			ELBOW_CENTER = 18,
			ELBOW_LEFT = 19,
			ELBOW_RIGHT = 20
		}
		public AdvIKPluginOptions Data { get; init; }
		public AdvIKPluginData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			bool _magnitudeData = (bool)dataDict["MagnitudeData"];
			Vector3? _breathingMagnitude;
			Vector3? _breathingUpperChestScaling;
			Vector3? _breathingLowerChestScaling;
			Vector3? _breathingAbdomenScaling;
			_breathingMagnitude = (_magnitudeData) ? new Vector3(
				(float)dataDict["BreathingMagnitude.x"],
				(float)dataDict["BreathingMagnitude.y"],
				(float)dataDict["BreathingMagnitude.z"]) : null;
			_breathingUpperChestScaling = (_magnitudeData) ? new Vector3(
			(float)dataDict["BreathingUpperChestScaling.x"],
			(float)dataDict["BreathingUpperChestScaling.y"],
			(float)dataDict["BreathingUpperChestScaling.z"]) : null;
			_breathingLowerChestScaling = (_magnitudeData) ? new Vector3(
				(float)dataDict["BreathingLowerChestScaling.x"],
				(float)dataDict["BreathingLowerChestScaling.y"],
				(float)dataDict["BreathingLowerChestScaling.z"]) : null;
			_breathingAbdomenScaling = (_magnitudeData) ? new Vector3(
			(float)dataDict["BreathingAbdomenScaling.x"],
			(float)dataDict["BreathingAbdomenScaling.y"],
			(float)dataDict["BreathingAbdomenScaling.z"]) : null;
			Dictionary<IKChain, IKResizeChainAdjustment>? _chainAdjustments;
			_chainAdjustments = dataDict.TryGetValue("ResizeChainAdjustments", out object? _tryval) ?
				MessagePack.MessagePackSerializer.Deserialize<Dictionary<IKChain, IKResizeChainAdjustment>>((byte[])_tryval) : null;
			Data = new AdvIKPluginOptions()
			{
				ShoulderRotationEnabled = dataDict.TryGetValue("ShoulderRotatorEnabled", out _tryval) ? (bool)_tryval : null,
				IndependentShoulders = dataDict.TryGetValue("IndependentShoulders", out _tryval) ? (bool)_tryval : null,
				ShoulderWeight = dataDict.TryGetValue("ShoulderWeight", out _tryval) ? (float)_tryval : null,
				ShoulderRightWeight = dataDict.TryGetValue("ShoulderRightWeight", out _tryval) ? (float)_tryval : null,
				ShoulderOffset = dataDict.TryGetValue("ShoulderOffset", out _tryval) ? (float)_tryval : null,
				ShoulderRightOffset = dataDict.TryGetValue("ShoulderRightOffset", out _tryval) ? (float)_tryval : null,
				SpineStiffness = dataDict.TryGetValue("SpineStiffness", out _tryval) ? (float)_tryval : null,
				EnableSpineFKHints = dataDict.TryGetValue("EnableSpineFKHints", out _tryval) ? (bool)_tryval : null,
				EnableShoulderFKHints = dataDict.TryGetValue("EnableShoulderFKHints", out _tryval) ? (bool)_tryval : null,
				ReverseShoulderL = dataDict.TryGetValue("ReverseShoulderL", out _tryval) ? (bool)_tryval : null,
				ReverseShoulderR = dataDict.TryGetValue("ReverseShoulderR", out _tryval) ? (bool)_tryval : null,
				EnableToeFKHints = dataDict.TryGetValue("EnableToeFKHints", out _tryval) ? (bool)_tryval : null,
				Enabled = dataDict.TryGetValue("BreathingEnabled", out _tryval) ? (bool)_tryval : null,
				IntakePause = dataDict.TryGetValue("BreathingIntakePause", out _tryval) ? (float)_tryval : null,
				HoldPause = dataDict.TryGetValue("BreathingHoldPause", out _tryval) ? (float)_tryval : null,
				InhalePercentage = dataDict.TryGetValue("BreathingInhalePercentage", out _tryval) ? (float)_tryval : null,
				BreathsPerMinute = dataDict.TryGetValue("BreathingBPM", out _tryval) ? (int)_tryval : null,
				MagnitudeData = _magnitudeData,
				BreathMagnitude = _breathingMagnitude,
				UpperChestRelativeScaling = _breathingUpperChestScaling,
				LowerChestRelativeScaling = _breathingLowerChestScaling,
				AbdomenRelativeScaling = _breathingAbdomenScaling,
				ShoulderDampeningFactor = dataDict.TryGetValue("BreathingShoulderDampeningFactor", out _tryval) ? (float)_tryval : null,
				MagnitudeFactor = dataDict.TryGetValue("MagnitudeFactor", out _tryval) ? (float)_tryval : null,
				ResizeCentroid = dataDict.TryGetValue("ResizeCentroid", out _tryval) ? (IKResizeCentroid)_tryval : null,
				ChainAdjustments = _chainAdjustments
			};
		}
	}
}
