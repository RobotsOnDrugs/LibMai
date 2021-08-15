using System.Collections.Immutable;

using MessagePack;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record BepinExSideloaderData : ExtendedPluginData
	{
		public new const string PluginGUID = "com.bepis.sideloader.universalautoresolver";
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
