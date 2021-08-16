using System.Collections.Immutable;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record UncensorSelectorData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.deathweasel.bepinex.uncensorselector";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("3.11.2");
			internal const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
			internal const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/UncensorSelector.Core/Core.UncensorSelector.Controller.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; init; } = typeof(UncensorOptions);
		public readonly struct UncensorOptions
		{
			public string? BodyGUID { get; init; }
			public string? PenisGUID { get; init; }
			public string? BallsGUID { get; init; }
			public bool DisplayPenis { get; init; }
			public bool DisplayBalls { get; init; }
			public ImmutableList<object>? Unrecognized { get; init; }
		}
		public UncensorOptions Data { get; init; }
		public UncensorSelectorData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			List<object>? _unrecognized = null;
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
					case "_BallsGUID":
						_BallsGUID = (string?)uncensorOption.Value;
						break;
					case "DisplayPenis":
						_DisplayPenis = (bool)uncensorOption.Value;
						break;
					case "DisplayBalls":
						_DisplayBalls = (bool)uncensorOption.Value;
						break;
					default:
						_unrecognized ??= new();
						_unrecognized.Add(uncensorOption.Value);
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
				Unrecognized = _unrecognized?.ToImmutableList()
			};
		}
	}
}
