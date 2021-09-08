namespace IllusionCards.AI.ExtendedData.PluginData;

public abstract record ExtendedPluginData
{
	public static ExtendedPluginData GetExtendedPluginData(string dataKey, int version, Dictionary<object, object> dataDict) => dataKey switch
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
		AIHS2PEData.DataKeyAI => new AIHS2PEData(version, dataDict),
		AIHS2PEData.DataKeyHS2 => new AIHS2PEData(version, dataDict),
		ReverseTrapData.DataKey => new ReverseTrapData(version, dataDict),
		OutfitPainterData.DataKey => new OutfitPainterData(version, dataDict),
		AgentTrainerData.DataKey => new AgentTrainerData(version, dataDict),
		CollidersData.DataKey => new CollidersData(version, dataDict),
		CollidersData.OldDataKey => new CollidersData(version, dataDict),
		_ => new UnknownPluginData(version, dataDict)
	};

	internal static int? NullCheckDictionaryEntries(ref Dictionary<object, object> dataDict, string key, int _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (int)_tryval : null;
	internal static float? NullCheckDictionaryEntries(ref Dictionary<object, object> dataDict, string key, float _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (float)_tryval : null;
	internal static bool? NullCheckDictionaryEntries(ref Dictionary<object, object> dataDict, string key, bool _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (bool)_tryval : null;
	internal static string? NullCheckDictionaryEntries(ref Dictionary<object, object> dataDict, string key, string _) => dataDict.TryGetValue(key, out object? _tryval) && (_tryval is not null) ? (string)_tryval : null;

	public abstract string Name { get; }
	public object? RawData { get; init; }
	public int? Version { get; init; }
	public virtual Type DataType { get; } = typeof(object);
	public sealed override string ToString() => Name;

	public ExtendedPluginData(int version, Dictionary<object, object> _) { RawData = null; Version = version; }
	public ExtendedPluginData() => RawData = null;
}
