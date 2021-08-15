
using IllusionCards.FakeUnity;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record AdvIKPluginData : ExtendedPluginData
	{
		public new const string PluginGUID = "orange.spork.advikplugin";
		public override Type DataType { get; init; } = typeof(AdvIKPluginOptions);
		public readonly struct AdvIKPluginOptions
		{
			public bool ShoulderRotationEnabled { get; init; }
			public bool IndependentShoulders { get; init; }
			public float ShoulderWeight { get; init; }
			public float ShoulderRightWeight { get; init; }
			public float ShoulderOffset { get; init; }
			public float ShoulderRightOffset { get; init; }
			public float SpineStiffness { get; init; }
			public bool EnableSpineFKHints { get; init; }
			public bool EnableShoulderFKHints { get; init; }
			public bool ReverseShoulderL { get; init; }
			public bool ReverseShoulderR { get; init; }
			public bool EnableToeFKHints { get; init; }
			public bool Enabled { get; init; }
			public float IntakePause { get; init; }
			public float HoldPause { get; init; }
			public float InhalePercentage { get; init; }
			public int BreathsPerMinute { get; init; }
			public bool MagnitudeData { get; init; }
			public Vector3? BreathMagnitude { get; init; }
			public Vector3? UpperChestRelativeScaling { get; init; }
			public Vector3? LowerChestRelativeScaling { get; init; }
			public Vector3? AbdomenRelativeScaling { get; init; }
			public float ShoulderDampeningFactor { get; init; }
			public float MagnitudeFactor { get; init; }
			public IKResizeCentroid ResizeCentroid { get; init; }
			public Dictionary<IKChain, IKResizeChainAdjustment> ChainAdjustments { get; init; }
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
			Data = new AdvIKPluginOptions()
			{
				ShoulderRotationEnabled = (bool)dataDict["ShoulderRotatorEnabled"],
				IndependentShoulders = (bool)dataDict["IndependentShoulders"],
				ShoulderWeight = (float)dataDict["ShoulderWeight"],
				ShoulderRightWeight = (float)dataDict["ShoulderRightWeight"],
				ShoulderOffset = (float)dataDict["ShoulderOffset"],
				ShoulderRightOffset = (float)dataDict["ShoulderRightOffset"],
				SpineStiffness = (float)dataDict["SpineStiffness"],
				EnableSpineFKHints = (bool)dataDict["EnableSpineFKHints"],
				EnableShoulderFKHints = (bool)dataDict["EnableShoulderFKHints"],
				ReverseShoulderL = (bool)dataDict["ReverseShoulderL"],
				ReverseShoulderR = (bool)dataDict["ReverseShoulderR"],
				EnableToeFKHints = (bool)dataDict["EnableToeFKHints"],
				Enabled = (bool)dataDict["BreathingEnabled"],
				IntakePause = (float)dataDict["BreathingIntakePause"],
				HoldPause = (float)dataDict["BreathingHoldPause"],
				InhalePercentage = (float)dataDict["BreathingInhalePercentage"],
				BreathsPerMinute = (int)dataDict["BreathingBPM"],
				MagnitudeData = _magnitudeData,
				BreathMagnitude = _breathingMagnitude,
				UpperChestRelativeScaling = _breathingUpperChestScaling,
				LowerChestRelativeScaling = _breathingLowerChestScaling,
				AbdomenRelativeScaling = _breathingAbdomenScaling,
				ShoulderDampeningFactor = (float)dataDict["BreathingShoulderDampeningFactor"],
				MagnitudeFactor = (float)dataDict["MagnitudeFactor"],
				ResizeCentroid = (IKResizeCentroid)dataDict["ResizeCentroid"],
				ChainAdjustments = MessagePack.MessagePackSerializer.Deserialize<Dictionary<IKChain, IKResizeChainAdjustment>>((byte[])dataDict["ResizeChainAdjustments"])
			};
		}
	}
}
