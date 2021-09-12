namespace IllusionCards.AI.ExtendedData.PluginData;

public record AdditionalAccessoryControlsData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "orange.spork.additionalaccessorycontrolsplugin";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.1.8");
		public const string RepoURL = "https://github.com/OrangeSpork/AdditionalAccessoryControls";
		public const string ClassDefinitionsURL = "https://github.com/OrangeSpork/AdditionalAccessoryControls/blob/master/AdditionalAccessoryControls/AdditionalAccessoryControlsController.cs";
		public const string? License = null;
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Additional Accessory Controls";
	public override Type DataType => Data.GetType();
	public AdditionalAccessoryControlsOptions Data { get; init; }

	public readonly record struct AdditionalAccessoryControlsOptions
	{
		public AdditionalAccessorySlotData[] SlotData { get; init; }
		public AdditionalAccessoryCoordinateData CoordinateOverrideData { get; init; }
	}
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
		public string? AdvancedParent { get; init; }
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
		public List<AdditionalAccessoryCoordinateRuleData> SuppressedRules { get; init; } = null!;
		[Key(1)]
		public List<AdditionalAccessoryCoordinateRuleData> OverrideRules { get; init; } = null!;
	}
	[MessagePackObject]
	public record AdditionalAccessoryCoordinateRuleData
	{
		[Key(0)]
		public AdditionalAccessoryVisibilityRules Rule { get; init; }
		[Key(1)]
		public string RuleModifier { get; init; } = null!;
		[Key(2)]
		public AdditionalAccessoryVisibilityRules OverrideRule { get; init; }
		[Key(3)]
		public string OverrideRuleModifier { get; init; } = null!;
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
	public AdditionalAccessoryControlsData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new()
		{
			SlotData = MessagePackSerializer.Deserialize<AdditionalAccessorySlotData[]>((byte[])dataDict["accessoryData"]),
			CoordinateOverrideData = MessagePackSerializer.Deserialize<AdditionalAccessoryCoordinateData>((byte[])dataDict["overrideData"])
		};
	}
}
