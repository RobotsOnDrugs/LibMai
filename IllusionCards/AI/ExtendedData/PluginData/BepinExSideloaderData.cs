using System.Collections.Immutable;

using MessagePack;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record BepinExSideloaderData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.bepis.bepinex.sideloader";
			internal const string DataKey = "com.bepis.sideloader.universalautoresolver";
			internal const string OldDataKey = "EC.Core.Sideloader.UniversalAutoResolver";
			internal readonly Version PluginVersion = new("16.4");
			internal const string RepoURL = "https://github.com/IllusionMods/BepisPlugins";
			internal const string ClassDefinitionsURL = "https://github.com/IllusionMods/BepisPlugins/blob/5dee8c824e17414b68e36aeae00b8c609ea0c49b/src/Core_Sideloader/UniversalAutoResolver/Core.UAR.ResolveInfo.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; init; } = typeof(Dictionary<string, object[]>);
		private List<ModInfo> ModInfos { get; init; }
		public ImmutableList<ModInfo> Data { get; init; }
		public BepinExSideloaderData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			ModInfos = new();
			object[] _rawData = (object[])dataDict["info"];
			DeserializeData(_rawData);
			Data = ModInfos.ToImmutableList();
		}
		internal void DeserializeData(object[] rawModData)
		{
			foreach (byte[] chunk in rawModData)
				ModInfos.Add(MessagePackSerializer.Deserialize<ModInfo>(chunk));
		}
	}
}
