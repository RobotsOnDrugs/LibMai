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
		public override Type DataType { get; } = typeof(Dictionary<string, object[]>);
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
}
