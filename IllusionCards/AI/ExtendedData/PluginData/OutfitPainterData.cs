namespace IllusionCards.AI.ExtendedData.PluginData;

public record OutfitPainterData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "orange.spork.outfitpainter";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.0.0");
		public const string RepoURL = "https://github.com/OrangeSpork/OutfitPainter";
		public const string DefinitionsURL = "https://github.com/OrangeSpork/OutfitPainter/blob/master/OutfitPainter/OutfitPainterCharacterController.cs";
		public const string License = "LGPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Outfit Painter";
	public override Type DataType => Data.GetType();
	public OutfitPainterOptions Data { get; }

	[MessagePackObject]
	public readonly record struct OutfitPainterOptions
	{
		[Key(0)]
		[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
		private List<OutfitPainterChannel> ChannelsList { init => Channels = value.ToImmutableArray(); }
		[IgnoreMember]
		public ImmutableArray<OutfitPainterChannel> Channels { get; init; }
	}

	[MessagePackObject]
	public readonly record struct OutfitPainterChannel
	{
		[Key(0)]
		public int ChannelId { get; init; }

		[Key(1)]
		public string ChannelDescription { get; init; } = null!;

		[Key(2)]
		public Color ChannelColor { get; init; }

		[Key(3)]
		public float ChannelGloss { get; init; }

		[Key(4)]
		public float ChannelMetallic { get; init; }

		[Key(5)]
		[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
		private List<OutfitPainterChannelAssignment> AssignmentsList { init => Assignments = value.ToImmutableArray(); }
		[IgnoreMember]
		public ImmutableArray<OutfitPainterChannelAssignment> Assignments { get; init; } = ImmutableArray<OutfitPainterChannelAssignment>.Empty;
	}
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly record struct OutfitPainterChannelAssignment
	{
		[Key(0)]
		public OutfitPainterSlot slot { get; init; }

		[Key(1)]
		public int slotNumber { get; init; }

		[Key(2)]
		public int colorNumber { get; init; }

		[Key(3)]
		public bool patternColor { get; init; }
	}
	public enum OutfitPainterSlot
	{
		TOP = 0,
		BOT = 1,
		INNER_TOP = 2,
		INNER_BOT = 3,
		PANTYHOSE = 5,
		GLOVE = 4,
		SOCK = 6,
		SHOE = 7,
		ACCESSORY = 8

	}

	public OutfitPainterData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = dataDict.TryGetValue((object)"OutfitPainterData", out object? _tryval) && (_tryval is not null)
			? MessagePackSerializer.Deserialize<OutfitPainterOptions>((byte[])_tryval)
			: new();
	}
}
