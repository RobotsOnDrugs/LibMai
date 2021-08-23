
//Not compatible with PushUp plugin.
//Only the Inert and Gravity options work.
//Not compatible with HS2_Jiggle plugin.
//HS2_Jiggle plugin overrides the Inert and Elasticity options.

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record BoobSettingsData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.fairbair.hs2_boobsettings";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.1.0");
			internal const string RepoURL = "https://github.com/FairBear/HS2_BoobSettings";
			internal const string ClassDefinitionsURL = "https://github.com/FairBear/HS2_BoobSettings/blob/master/BoobController.cs";
			internal const string License = "MIT";
		}
		public override Type DataType { get; } = typeof(BoobController);

		internal const string BUTT = "butt_";

		internal const string OVERRIDE_PHYSICS = "overridePhysics";
		internal const string DAMPING = "damping";
		internal const string ELASTICITY = "elasticity";
		internal const string STIFFNESS = "stiffness";
		internal const string INERT = "inert";

		internal const string OVERRIDE_GRAVITY = "overrideGravity";
		internal const string GRAVITY_X = "gravityX";
		internal const string GRAVITY_Y = "gravityY";
		internal const string GRAVITY_Z = "gravityZ";

		public static readonly ImmutableDictionary<string, string> OptionDescriptions = new Dictionary<string, string>()
		{
			{ OVERRIDE_PHYSICS, "Override Breast Physics" },
			{ DAMPING, "Breast Damping" },
			{ ELASTICITY, "Breast Elasticity" },
			{ STIFFNESS, "Breast Stiffness" },
			{ INERT, "Breast Inert" },

			{ OVERRIDE_GRAVITY, "Override Breast Gravity" },
			{ GRAVITY_X, "Breast Gravity X" },
			{ GRAVITY_Y, "Breast Gravity Y" },
			{ GRAVITY_Z, "Breast Gravity Z" },

			{ BUTT + OVERRIDE_PHYSICS, "Override Butt Physics" },
			{ BUTT + DAMPING, "Butt Damping" },
			{ BUTT + ELASTICITY, "Butt Elasticity" },
			{ BUTT + STIFFNESS, "Butt Stiffness" },
			{ BUTT + INERT, "Butt Inert" },

			{ BUTT + OVERRIDE_GRAVITY, "Override Butt Gravity" },
			{ BUTT + GRAVITY_X, "Butt Gravity X" },
			{ BUTT + GRAVITY_Y, "Butt Gravity Y" },
			{ BUTT + GRAVITY_Z, "Butt Gravity Z" }
		}.ToImmutableDictionary();

		public static readonly ImmutableDictionary<string, float> FloatMultipliers = new Dictionary<string, float>()
		{
			{ GRAVITY_X, 100f },
			{ GRAVITY_Y, 100f },
			{ GRAVITY_Z, 100f }
		}.ToImmutableDictionary();

		public static readonly ImmutableDictionary<string, bool> boolDefaults = new Dictionary<string, bool>()
		{
			{ OVERRIDE_PHYSICS, false },
			{ OVERRIDE_GRAVITY, false },

			{ BUTT + OVERRIDE_PHYSICS, false },
			{ BUTT + OVERRIDE_GRAVITY, false }
		}.ToImmutableDictionary();
		public static readonly ImmutableDictionary<string, float> floatDefaults = new Dictionary<string, float>()
		{
			{ DAMPING, 0.14f },
			{ ELASTICITY, 0.17f },
			{ STIFFNESS, 0.5f },
			{ INERT, 0.8f },
			{ GRAVITY_X, 0f },
			{ GRAVITY_Y, -0.0003f },
			{ GRAVITY_Z, 0f },

			{ BUTT + DAMPING, 0.01f },
			{ BUTT + ELASTICITY, 0.1f },
			{ BUTT + STIFFNESS, 0.3f },
			{ BUTT + INERT, 0.9f },
			{ BUTT + GRAVITY_X, 0f },
			{ BUTT + GRAVITY_Y, 0f },
			{ BUTT + GRAVITY_Z, 0f }
		}.ToImmutableDictionary();

		public static readonly ImmutableArray<string> prefixKeys = new string[2]
		{
			string.Empty, // Boob
			BUTT
		}.ToImmutableArray();
		[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Mirrors original variable names")]
		public readonly struct BoobController
		{
			public ImmutableDictionary<string, bool> boolData { get; init; }
			public ImmutableDictionary<string, float> floatData { get; init; }
		}
		public BoobController Data { get; }
		public BoobSettingsData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		{
			ImmutableDictionary<string, bool>.Builder _boolDataBuilder = boolDefaults.ToBuilder();
			ImmutableDictionary<string, float>.Builder _floatDataBuilder = floatDefaults.ToBuilder();
			foreach (var _boolData in boolDefaults)
			{
				if (dataDict.TryGetValue(_boolData.Key, out object? _tryval))
					_boolDataBuilder[_boolData.Key] = (bool)_tryval;
			}
			foreach (var _floatData in floatDefaults)
			{
				if (dataDict.TryGetValue(_floatData.Key, out object? _tryval))
					_floatDataBuilder[_floatData.Key] = (float)_tryval;
			}

			Data = new BoobController()
			{
				boolData = _boolDataBuilder.ToImmutable(),
				floatData = _floatDataBuilder.ToImmutable()
			};
		}
	}
}
