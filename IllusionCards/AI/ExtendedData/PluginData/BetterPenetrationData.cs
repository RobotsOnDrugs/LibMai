namespace IllusionCards.AI.ExtendedData.PluginData;

public record BetterPenetrationData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "com.animal42069.studiobetterpenetration";
		public const string DataKey = "BetterPenetrationController";
		public static readonly Version PluginVersion = new("4.3.0.0");
		public const string RepoURL = "https://github.com/Animal42069/BetterPenetration";
		public const string ClassDefinitionsURL = "https://github.com/Animal42069/BetterPenetration/blob/master/Core_BetterPenetration/BetterPenetrationController.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Better Penetration";
	public override Type DataType => Data.GetType();
	public BetterPenetrationOptions Data { get; init; }

	public const float DefaultLengthSquish = 0.6f;
	public const float DefaultGirthSquish = 0.2f;
	public const float DefaultSquishThreshold = 0.2f;
	public const float DefaultColliderLengthScale = 1f;
	public const float DefaultColliderRadiusScale = 1f;
	public const BetterPenetrationOptions.ControllerOptions.AutoTarget DefaultDanAutoTarget = BetterPenetrationOptions.ControllerOptions.AutoTarget.Off;
	public const bool DefaultPushPull = false;
	public const float DefaultMaxPush = 0.05f;
	public const float DefaultMaxPull = 0.05f;
	public const float DefaultPullRate = 18.0f;
	public const float DefaultReturnRate = 0.3f;
	[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Mirrors original variable names")]
	public readonly record struct BetterPenetrationOptions
	{
		public bool enabled { get; init; }
		public DanOptions danOptions { get; init; } = new();
		public CollisionOptions collisionOptions { get; init; } = new();
		public ControllerOptions controllerOptions { get; init; } = new();
		public readonly record struct DanOptions
		{
			public float lengthSquish { get; init; }
			public float girthSquish { get; init; }
			public float squishThreshold { get; init; }
			public float colliderRadiusScale { get; init; }
			public float colliderLengthScale { get; init; }
		}
		public readonly record struct CollisionOptions
		{
			public bool enablePushPull { get; init; }
			public float maxPush { get; init; }
			public float maxPull { get; init; }
			public float pullRate { get; init; }
			public float returnRate { get; init; }
		}
		public readonly record struct ControllerOptions
		{
			public AutoTarget autoTarget { get; init; }
			public enum AutoTarget
			{
				Off,
				Vaginal,
				Anal,
				Oral
			}
		}
	}
	public BetterPenetrationData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new()
		{
			enabled = dataDict.TryGetValue("Enabled", out object? _tryval) && (_tryval is not null) && (bool)_tryval,
			danOptions = new()
			{
				lengthSquish = dataDict.TryGetValue("LengthSquish", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultLengthSquish,
				girthSquish = dataDict.TryGetValue("GirthSquish", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultGirthSquish,
				squishThreshold = dataDict.TryGetValue("SquishThreshold", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultSquishThreshold,
				colliderRadiusScale = dataDict.TryGetValue("ColliderRadiusScale", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultColliderRadiusScale,
				colliderLengthScale = dataDict.TryGetValue("ColliderLengthScale", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultColliderLengthScale,
			},
			collisionOptions = new()
			{
				enablePushPull = dataDict.TryGetValue("EnablePushPull", out _tryval) && (_tryval is not null) && (bool)_tryval,
				maxPush = dataDict.TryGetValue("MaxPush", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultMaxPush,
				maxPull = dataDict.TryGetValue("MaxPull", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultMaxPull,
				pullRate = dataDict.TryGetValue("PullRate", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultPullRate,
				returnRate = dataDict.TryGetValue("ReturnRate", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultReturnRate
			},
			controllerOptions = new()
			{
				autoTarget = dataDict.TryGetValue("DanAutoTarget", out _tryval) && (_tryval is not null) ? (BetterPenetrationOptions.ControllerOptions.AutoTarget)_tryval : DefaultDanAutoTarget
			}
		};
	}
}
