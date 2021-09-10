namespace IllusionCards.AI.ExtendedData.PluginData;

public record BepinExSideloaderData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "com.bepis.bepinex.sideloader";
		public const string DataKey = "com.bepis.sideloader.universalautoresolver";
		public const string OldDataKey = "EC.Core.Sideloader.UniversalAutoResolver";
		public static readonly Version PluginVersion = new("16.4");
		public const string RepoURL = "https://github.com/IllusionMods/BepisPlugins";
		public const string ClassDefinitionsURL = "https://github.com/IllusionMods/BepisPlugins/blob/master/src/Core_Sideloader/UniversalAutoResolver/Core.UAR.ResolveInfo.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Sideloader";
	public override Type DataType { get; } = typeof(ImmutableArray<ModInfo>);
	public ImmutableArray<ModInfo> Data { get; init; }

	public BepinExSideloaderData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		ImmutableArray<ModInfo>.Builder _modInfos = ImmutableArray.CreateBuilder<ModInfo>();
		object[] _rawData = (object[])dataDict["info"];
		foreach (byte[] chunk in _rawData)
			_modInfos.Add(MessagePackSerializer.Deserialize<ModInfo>(chunk));
		Data = _modInfos.ToImmutable();
	}
}
