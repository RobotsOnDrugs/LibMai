namespace IllusionCards.AI.ExtendedData.PluginData;

public record AdvIKPluginData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public readonly struct DefinitionMetadata
	{
		public const string PluginGUID = "orange.spork.advikplugin";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.6.3");
		public const string RepoURL = "https://github.com/OrangeSpork/AdvIKPlugin";
		public const string ClassDefinitionsURL = "https://github.com/OrangeSpork/AdvIKPlugin/blob/master/AdvIKPlugin/AdvIKCharaController.cs";
		public const string? License = null;
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "AdvIKPlugin";
	public override Type DataType { get; } = typeof(AdvIKPluginOptions);
	public AdvIKPluginOptions Data { get; init; }

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
		public bool MagnitudeData { get; init; }
		public Vector3? BreathMagnitude { get; init; }
		public Vector3? UpperChestRelativeScaling { get; init; }
		public Vector3? LowerChestRelativeScaling { get; init; }
		public Vector3? AbdomenRelativeScaling { get; init; }
		public float? ShoulderDampeningFactor { get; init; }
		public float? MagnitudeFactor { get; init; }
		public IKResizeCentroid? ResizeCentroid { get; init; }
		public ImmutableDictionary<IKChain, IKResizeChainAdjustment>? ChainAdjustments { get; init; }
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

	[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "MessagePack deserialization makes it obvious")]
	public AdvIKPluginData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		bool _magnitudeData = NullCheckDictionaryEntries(ref dataDict, "MagnitudeData", false) ?? false;
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
		var _chainAdjustments = dataDict.TryGetValue("ResizeChainAdjustments", out object? _tryval) && (_tryval is not null) ?
			MessagePack.MessagePackSerializer.Deserialize<ImmutableDictionary<IKChain, IKResizeChainAdjustment>>((byte[])_tryval) : null;
		Data = new AdvIKPluginOptions()
		{
			ShoulderRotationEnabled = NullCheckDictionaryEntries(ref dataDict, "ShoulderRotatorEnabled", false),
			IndependentShoulders = NullCheckDictionaryEntries(ref dataDict, "IndependentShoulders", false),
			ShoulderWeight = NullCheckDictionaryEntries(ref dataDict, "ShoulderWeight", 0f),
			ShoulderRightWeight = NullCheckDictionaryEntries(ref dataDict, "ShoulderRightWeight", 0f),
			ShoulderOffset = NullCheckDictionaryEntries(ref dataDict, "ShoulderOffset", 0f),
			ShoulderRightOffset = NullCheckDictionaryEntries(ref dataDict, "ShoulderRightOffset", 0f),
			SpineStiffness = NullCheckDictionaryEntries(ref dataDict, "SpineStiffness", 0f),
			EnableSpineFKHints = NullCheckDictionaryEntries(ref dataDict, "EnableSpineFKHints", false),
			EnableShoulderFKHints = NullCheckDictionaryEntries(ref dataDict, "EnableShoulderFKHints", false),
			ReverseShoulderL = NullCheckDictionaryEntries(ref dataDict, "ReverseShoulderL", false),
			ReverseShoulderR = NullCheckDictionaryEntries(ref dataDict, "ReverseShoulderR", false),
			EnableToeFKHints = NullCheckDictionaryEntries(ref dataDict, "EnableToeFKHints", false),
			Enabled = NullCheckDictionaryEntries(ref dataDict, "BreathingEnabled", false),
			IntakePause = NullCheckDictionaryEntries(ref dataDict, "BreathingIntakePause", 0f),
			HoldPause = NullCheckDictionaryEntries(ref dataDict, "BreathingHoldPause", 0f),
			InhalePercentage = NullCheckDictionaryEntries(ref dataDict, "BreathingInhalePercentage", 0f),
			BreathsPerMinute = NullCheckDictionaryEntries(ref dataDict, "BreathingBPM", 0),
			MagnitudeData = _magnitudeData,
			BreathMagnitude = _breathingMagnitude,
			UpperChestRelativeScaling = _breathingUpperChestScaling,
			LowerChestRelativeScaling = _breathingLowerChestScaling,
			AbdomenRelativeScaling = _breathingAbdomenScaling,
			ShoulderDampeningFactor = NullCheckDictionaryEntries(ref dataDict, "BreathingShoulderDampeningFactor", 0f),
			MagnitudeFactor = NullCheckDictionaryEntries(ref dataDict, "MagnitudeFactor", 0f),
			ResizeCentroid = dataDict.TryGetValue("ResizeCentroid", out _tryval) && (_tryval is not null) ? (IKResizeCentroid)_tryval : null,
			ChainAdjustments = _chainAdjustments
		};
	}
}
