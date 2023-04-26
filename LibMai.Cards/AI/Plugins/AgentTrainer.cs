namespace LibMai.Cards.AI.Plugins;

public record AgentTrainerData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "com.fairbair.agenttrainer";
		public const string DataKey = "AgentTrainer.StatsController";
		public static readonly Version PluginVersion = new("1.2.0");
		public const string RepoURL = "https://github.com/FairBear/AgentTrainer";
		public const string ClassDefinitionsURL = "https://github.com/FairBear/AgentTrainer/blob/master/StatsController.cs";
		public const string? License = null;
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Agent Trainer";
	public override Type DataType => Data.GetType();
	public AgentTrainerOptions Data { get; init; }

	// The integer indices of these have meaning for "AgentActors" in the game, but it seems to be very specific to AI
	public readonly record struct AgentTrainerOptions
	{
		public ImmutableDictionary<int, float> LockedStats { get; init; }
		public ImmutableDictionary<int, float> LockedDesires { get; init; }
		public ImmutableDictionary<int, int> LockedFlavors { get; init; }
	}
	public AgentTrainerData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		MessagePackSerializerOptions _lz4Option = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);
		Data = new AgentTrainerOptions()
		{
			LockedStats = dataDict.TryGetValue((object)"lockedStats", out object? _rawData) && _rawData is not null ?
				MessagePackSerializer.Deserialize<ImmutableDictionary<int, float>>((byte[])_rawData, _lz4Option) : ImmutableDictionary<int, float>.Empty,
			LockedDesires = dataDict.TryGetValue((object)"lockedDesires", out _rawData) && _rawData is not null ?
				MessagePackSerializer.Deserialize<ImmutableDictionary<int, float>>((byte[])_rawData, _lz4Option) : ImmutableDictionary<int, float>.Empty,
			LockedFlavors = dataDict.TryGetValue((object)"lockedFlavors", out _rawData) && _rawData is not null ?
				MessagePackSerializer.Deserialize<ImmutableDictionary<int, int>>((byte[])_rawData, _lz4Option) : ImmutableDictionary<int, int>.Empty
		};
	}
}
