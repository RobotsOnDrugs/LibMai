using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record OutfitPainterData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "orange.spork.outfitpainter";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.0.0");
			internal const string RepoURL = "https://github.com/OrangeSpork/OutfitPainter";
			internal const string DefinitionsURL = "https://github.com/OrangeSpork/OutfitPainter/blob/master/OutfitPainter/OutfitPainterCharacterController.cs";
			internal const string License = "LGPL 3.0";
		}
		public override Type DataType { get; } = typeof(OutfitPainterOptions);
		public OutfitPainterOptions Data { get; }
		[MessagePackObject]
		public readonly struct OutfitPainterOptions
		{
			[Key(0)]
			[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
			private List<OutfitPainterChannel> ChannelsList { init => Channels = value.ToImmutableArray(); }
			[IgnoreMember]
			public ImmutableArray<OutfitPainterChannel> Channels { get; init; }
		}

		[MessagePackObject]
		public readonly struct OutfitPainterChannel
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
		public readonly struct OutfitPainterChannelAssignment
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
}
