using System.Diagnostics.CodeAnalysis;

using IllusionCards.AI.ExtendedData.PluginData;

using MessagePack;

namespace IllusionCards.AI.Cards
{
	public record AiPluginData
	{
		public const string BlockName = "KKEx";
		public int? Version { get; init; }
		public ExtendedPluginData? PluginDataInfo { get; init; }

		public AiPluginData(string dataKey, AiRawPluginData rawPluginData)
		{
			if (rawPluginData == null) { Version = null; PluginDataInfo = new NullPluginData() { DataKey = dataKey }; return; }
			Version = Convert.ToInt32(rawPluginData.version);
			PluginDataInfo = rawPluginData.data is not null ? ExtendedPluginData.GetExtendedPluginData(dataKey, rawPluginData.data) : new NullPluginData() { DataKey = dataKey };
		}
	}
	[MessagePackObject, SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiRawPluginData
	{
		[Key(0)]
		public byte version { get; init; }
		[Key(1)]
		public Dictionary<object, object> data { get; init; } = null!;
		public AiRawPluginData() { }
	}
}