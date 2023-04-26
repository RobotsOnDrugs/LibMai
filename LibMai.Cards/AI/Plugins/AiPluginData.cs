namespace LibMai.Cards.AI.Plugins;

public abstract record AiPluginData
{
	public static AiPluginData GetExtendedPluginData(string dataKey, AiRawPluginData rawPluginData)
	{
		int version = Convert.ToInt32(rawPluginData.version);
		Dictionary<object, object>? dataDict = rawPluginData.data;
		return dataDict is null ? new NullPluginData() { DataKey = dataKey } : dataKey switch
		{
			BepinExSideloaderData.DataKey => new BepinExSideloaderData(version, dataDict),
			AdditionalAccessoriesData.DataKey => new AdditionalAccessoriesData(version, dataDict),
			UncensorSelectorData.DataKey => new UncensorSelectorData(version, dataDict),
			EyeControlData.DataKey => new EyeControlData(version, dataDict),
			DynamicBoneEditorData.DataKey => new DynamicBoneEditorData(version, dataDict),
			KK_InvisibleBodyData.DataKey => new KK_InvisibleBodyData(version, dataDict),
			KK_PregnancyPlusData.DataKey => new KK_PregnancyPlusData(version, dataDict),
			PushUpAIData.DataKey => new PushUpAIData(version, dataDict),
			AdditionalAccessoryControlsData.DataKey => new AdditionalAccessoryControlsData(version, dataDict),
			AdvIKPluginData.DataKey => new AdvIKPluginData(version, dataDict),
			AdvancedBoneModData.DataKey => new AdvancedBoneModData(version, dataDict),
			BeaverAIData.DataKey => new BeaverAIData(version, dataDict),
			BoobSettingsData.DataKey => new BoobSettingsData(version, dataDict),
			MaterialEditorData.DataKey => new MaterialEditorData(version, dataDict),
			KoiClothesOverlayXData.DataKey => new KoiClothesOverlayXData(version, dataDict),
			KoiSkinOverlayXData.DataKey => new KoiSkinOverlayXData(version, dataDict),
			BetterPenetrationData.DataKey => new BetterPenetrationData(version, dataDict),
			AIHS2PEData.DataKeyAI or AIHS2PEData.DataKeyHS2 => new AIHS2PEData(version, dataDict),
			ReverseTrapData.DataKey => new ReverseTrapData(version, dataDict),
			OutfitPainterData.DataKey => new OutfitPainterData(version, dataDict),
			AgentTrainerData.DataKey => new AgentTrainerData(version, dataDict),
			CollidersData.DataKey => new CollidersData(version, dataDict),
			CollidersData.OldDataKey => new CollidersData(version, dataDict),
			_ => new UnknownPluginData(version, dataDict) { DataKey = dataKey }
		};
	}

	internal static int? NullCheckDictionaryEntries(in Dictionary<object, object> dataDict, string key, int _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (int)_tryval : null;
	internal static float? NullCheckDictionaryEntries(in Dictionary<object, object> dataDict, string key, float _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (float)_tryval : null;
	internal static bool? NullCheckDictionaryEntries(in Dictionary<object, object> dataDict, string key, bool _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (bool)_tryval : null;
	internal static string? NullCheckDictionaryEntries(in Dictionary<object, object> dataDict, string key, string _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (string)_tryval : null;

	public abstract string Name { get; }
	public object? RawData { get; init; }
	public abstract string GUID { get; }
	public int Version { get; init; }
	public virtual Type DataType => typeof(object);
	public sealed override string ToString() => Name;

	internal AiPluginData(int version, in Dictionary<object, object> _) { RawData = null; Version = version; }
	internal AiPluginData() => RawData = null;
}

[MessagePackObject, SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawPluginData
{
	[Key(0)]
	public byte version { get; init; }
	[Key(1)]
	public Dictionary<object, object>? data { get; init; }
}