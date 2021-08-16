
using MessagePack;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record AdditionalAccessoryControlsData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "orange.spork.additionalaccessorycontrolsplugin";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.1.8");
			internal const string RepoURL = "https://github.com/OrangeSpork/AdditionalAccessoryControls";
			internal const string ClassDefinitionsURL = "https://github.com/OrangeSpork/AdditionalAccessoryControls/blob/master/AdditionalAccessoryControls/AdditionalAccessoryControlsController.cs";
			internal const string? License = null;
		}
		public override Type DataType { get; init; } = typeof(AdditionalAccessoryControlsOptions);
		public readonly struct AdditionalAccessoryControlsOptions
		{
			public AdditionalAccessorySlotData[] SlotData { get; init; }
			public AdditionalAccessoryCoordinateData CoordinateOverrideData { get; init; }
		}
		public AdditionalAccessoryControlsOptions Data { get; init; }
		[MessagePackObject]
		public record AdditionalAccessorySlotData
		{
			[Key(0)]
			public bool IsEmpty { get; init; }
			[Key(1)]
			public int SlotNumber { get; init; }
			[Key(2)]
			public int OriginalSlotNumber { get; init; }
			[Key(3)]
			public bool CharacterAccessory { get; init; }
			[Key(4)]
			public string AccessoryName { get; init; } = null!;
			[Key(5)]
			public bool AutoMatchBackHairColor { get; init; }
			[Key(6)]
			public List<AdditionalAccessoryVisibilityRuleData> VisibilityRules { get; init; } = null!;
			[Key(7)]
			public string AdvancedParent { get; init; } = null!;
			[MessagePackObject]
			public record AdditionalAccessoryVisibilityRuleData
			{
				[Key(0)]
				public AdditionalAccessoryVisibilityRules Rule { get; init; }
				[Key(1)]
				public string Modifier { get; init; } = null!;
			}
			public enum AdditionalAccessoryVisibilityRules
			{
				NONE = 0,

				// General Rules
				STARTUP = 1,
				H_START = 2,
				H_END = 3,
				STUDIO_LOAD = 4,

				// Slot Rules
				TOP = 10,
				BOT = 11,
				INNER_TOP = 12,
				INNER_BOT = 13,
				PANTYHOSE = 14,
				GLOVE = 15,
				SOCK = 16,
				SHOE = 17,

				// Other Accessory Rules
				ACCESSORY_LINK = 20,
				ACCESSORY_INVERSE_LINK = 21,

				// Special
				HAIR = 30,
				NOSE = 31,
				EAR = 32,
				HAND = 33,
				FOOT = 34,
				EYELASH = 35
			}
		}
		[MessagePackObject]
		public record AdditionalAccessoryCoordinateData
		{
			[Key(0)]
			public List<AdditionalAccessoryCoordinateRuleData> SuppressedRules { get; set; } = null!;
			[Key(1)]
			public List<AdditionalAccessoryCoordinateRuleData> OverrideRules { get; set; } = null!;
		}
		[MessagePackObject]
		public record AdditionalAccessoryCoordinateRuleData
		{
			[Key(0)]
			public AdditionalAccessoryVisibilityRules Rule { get; set; }
			[Key(1)]
			public string RuleModifier { get; set; } = null!;
			[Key(2)]
			public AdditionalAccessoryVisibilityRules OverrideRule { get; set; }
			[Key(3)]
			public string OverrideRuleModifier { get; set; } = null!;
		}
		public enum AdditionalAccessoryVisibilityRules
		{
			NONE = 0,

			// General Rules
			STARTUP = 1,
			H_START = 2,
			H_END = 3,
			STUDIO_LOAD = 4,

			// Slot Rules
			TOP = 10,
			BOT = 11,
			INNER_TOP = 12,
			INNER_BOT = 13,
			PANTYHOSE = 14,
			GLOVE = 15,
			SOCK = 16,
			SHOE = 17,

			// Other Accessory Rules
			ACCESSORY_LINK = 20,
			ACCESSORY_INVERSE_LINK = 21,

			// Special
			HAIR = 30,
			NOSE = 31,
			EAR = 32,
			HAND = 33,
			FOOT = 34,
			EYELASH = 35
		}
		public AdditionalAccessoryControlsData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			Data = new()
			{
				SlotData = MessagePackSerializer.Deserialize<AdditionalAccessorySlotData[]>((byte[])dataDict["accessoryData"]),
				CoordinateOverrideData = MessagePackSerializer.Deserialize<AdditionalAccessoryCoordinateData>((byte[])dataDict["overrideData"])
			};
		}
	}
}
