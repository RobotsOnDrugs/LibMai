namespace IllusionCards.AI.ExtendedData.PluginData;

public record UncensorSelectorData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "com.deathweasel.bepinex.uncensorselector";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("3.11.2");
		public const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		public const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/UncensorSelector.Core/Core.UncensorSelector.Controller.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Uncensor Selector";
	public override Type DataType => Data.GetType();
	public UncensorOptions Data { get; init; }

	public readonly record struct UncensorOptions
	{
		public string? BodyGUID { get; init; }
		public string? PenisGUID { get; init; }
		public string? BallsGUID { get; init; }
		public bool DisplayPenis { get; init; }
		public bool DisplayBalls { get; init; }
		public ImmutableDictionary<string, object>? Unrecognized { get; init; }
	}
	public UncensorSelectorData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		ImmutableDictionary<string, object>.Builder? _unrecognized = null;
		string? _BodyGUID = null;
		string? _PenisGUID = null;
		string? _BallsGUID = null;
		bool? _DisplayPenis = null;
		bool? _DisplayBalls = null;
		foreach (KeyValuePair<object, object> uncensorOption in dataDict)
		{
			switch (uncensorOption.Key)
			{
				case "BodyGUID":
					_BodyGUID = (string?)uncensorOption.Value;
					break;
				case "PenisGUID":
					_PenisGUID = (string?)uncensorOption.Value;
					break;
				case "BallsGUID":
					_BallsGUID = (string?)uncensorOption.Value;
					break;
				case "DisplayPenis":
					_DisplayPenis = (bool)uncensorOption.Value;
					break;
				case "DisplayBalls":
					_DisplayBalls = (bool)uncensorOption.Value;
					break;
				default:
					_unrecognized ??= ImmutableDictionary.CreateBuilder<string, object>();
					_unrecognized.Add((string)uncensorOption.Key, uncensorOption.Value);
					break;
			}
		}
		Data = new()
		{
			BodyGUID = _BodyGUID,
			PenisGUID = _PenisGUID,
			BallsGUID = _BallsGUID,
			DisplayPenis = _DisplayPenis ?? throw new InvalidOperationException(),
			DisplayBalls = _DisplayBalls ?? throw new InvalidOperationException(),
			Unrecognized = _unrecognized?.ToImmutable()
		};
	}
}
