using System.Collections.Immutable;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record UncensorSelectorData : ExtendedPluginData
	{
		public new const string PluginGUID = "com.deathweasel.bepinex.uncensorselector";
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
