namespace LibMai.Cards.AI.Plugins;

public record NullPluginData : AiPluginData
{
	public override string Name => "";
	public override string GUID => "";
	public string? DataKey { get; init; } = null;
	public new Type? DataType { get; } = null;
	public new int? Version { get; } = null;
	public NullPluginData() => RawData = null;
}
