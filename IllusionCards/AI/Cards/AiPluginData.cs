using System.Diagnostics.CodeAnalysis;

using IllusionCards.AI.ExtendedData.PluginData;

using MessagePack;

namespace IllusionCards.AI.Cards
{
	public record AiPluginData
	{
		public const string BlockName = "KKEx";
		public int Version { get; init; }
		public ExtendedPluginData PluginDataInfo { get; init; }

		public AiPluginData(string pluginGUID, AiRawPluginData rawPluginData)
		{
			Version = Convert.ToInt32(rawPluginData.version);
			PluginDataInfo = ExtendedPluginData.GetExtendedPluginData(pluginGUID, rawPluginData.data);
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