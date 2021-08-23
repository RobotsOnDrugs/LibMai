using System.Diagnostics.CodeAnalysis;

using IllusionCards.AI.ExtendedData.PluginData;

using MessagePack;

namespace IllusionCards.AI.Cards
{
	public readonly struct AiPluginData
	{
		public ExtendedPluginData? PluginDataInfo { get; init; }
		public int Version { get; init; }
		[IgnoreMember]
		public string DataKey { get; init; }

		public AiPluginData(string dataKey, AiRawPluginData rawPluginData)
		{
			DataKey = dataKey;
			Version = Convert.ToInt32(rawPluginData.version);
			PluginDataInfo = rawPluginData.data is not null ? ExtendedPluginData.GetExtendedPluginData(dataKey, Version, rawPluginData.data) : new NullPluginData() { DataKey = dataKey };
		}
	}
	[MessagePackObject, SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly struct AiRawPluginData
	{
		[Key(0)]
		public byte version { get; init; }
		[Key(1)]
		public Dictionary<object, object> data { get; init; } = null!;
	}
}