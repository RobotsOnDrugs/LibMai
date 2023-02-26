namespace IllusionCards.AI.Plugins;

public record UnknownPluginData : AiPluginData
{
	public override string Name => $"<Unknown Plugin: {DataKey}>";
	public override string GUID => "";
	public string DataKey { get; init; } = "";
	public override Type DataType => typeof(object);
	public UnknownPluginData(int version, Dictionary<object, object> dataDict) : base(version, dataDict) => RawData = dataDict;
}
