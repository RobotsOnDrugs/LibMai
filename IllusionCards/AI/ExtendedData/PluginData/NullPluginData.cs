namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record NullPluginData : ExtendedPluginData
	{
		public string? DataKey { get; init; } = null;
		public new Type? DataType { get; } = null;
		public new int? Version { get; } = null;
		public NullPluginData() => RawData = null;
	}
}
