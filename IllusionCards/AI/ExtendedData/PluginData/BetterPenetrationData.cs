using System.Diagnostics.CodeAnalysis;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record BetterPenetrationData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.animal42069.studiobetterpenetration";
			internal const string DataKey = "BetterPenetrationController";
			internal readonly Version PluginVersion = new("2.2.1.0");
			internal const string RepoURL = "https://github.com/Animal42069/BetterPenetration";
			internal const string ClassDefinitionsURL = "https://github.com/Animal42069/BetterPenetration/blob/master/Core_BetterPenetration/BetterPenetrationController.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; } = typeof(BetterPenetrationOptions); public const float DefaultLengthSquish = 0.6f;
		public const float DefaultGirthSquish = 0.2f;
		public const float DefaultSquishThreshold = 0.2f;
		public const float DefaultColliderLengthScale = 1f;
		public const float DefaultColliderRadiusScale = 1f;
		public const DanOptions.AutoTarget DefaultDanAutoTarget = DanOptions.AutoTarget.Off;
		[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Mirrors original variable names")]
		public readonly struct DanOptions
		{
			public float danLengthSquish { get; init; }
			public float danGirthSquish { get; init; }
			public float squishThreshold { get; init; }
			public float danRadiusScale { get; init; }
			public float danLengthScale { get; init; }
			public enum AutoTarget
			{
				Off,
				Vaginal,
				Anal,
				Oral
			}

			public AutoTarget danAutoTarget { get; init; }
		}
		[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Mirrors original variable names")]
		public readonly struct BetterPenetrationOptions
		{
			public bool enabled { get; init; } = false;
			public float lengthSquish { get; init; } = DefaultLengthSquish;
			public float girthSquish { get; init; } = DefaultGirthSquish;
			public float squishThreshold { get; init; } = DefaultSquishThreshold;
			public float colliderRadiusScale { get; init; } = DefaultColliderRadiusScale;
			public float colliderLengthScale { get; init; } = DefaultColliderLengthScale;
			public DanOptions.AutoTarget autoTarget { get; init; } = DefaultDanAutoTarget;
		}
		public BetterPenetrationOptions Data { get; init; }
		public BetterPenetrationData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		{
			Data = new()
			{
				enabled = dataDict.TryGetValue("Enabled", out object? _tryval) && (_tryval is not null) && (bool)_tryval,
				lengthSquish = dataDict.TryGetValue("LengthSquish", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultLengthSquish,
				girthSquish = dataDict.TryGetValue("GirthSquish", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultGirthSquish,
				squishThreshold = dataDict.TryGetValue("SquishThreshold", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultSquishThreshold,
				colliderRadiusScale = dataDict.TryGetValue("ColliderRadiusScale", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultColliderRadiusScale,
				colliderLengthScale = dataDict.TryGetValue("ColliderLengthScale", out _tryval) && (_tryval is not null) ? (float)_tryval : DefaultColliderLengthScale,
				autoTarget = dataDict.TryGetValue("DanAutoTarget", out _tryval) && (_tryval is not null) ? (DanOptions.AutoTarget)_tryval : DefaultDanAutoTarget
			};
		}
	}
}
