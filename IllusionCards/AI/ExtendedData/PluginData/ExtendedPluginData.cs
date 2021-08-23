using System.Diagnostics.CodeAnalysis;

namespace IllusionCards.AI.ExtendedData.PluginData
{
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
			//ReverseTrapData.DataKey => new ReverseTrapData(version, dataDict),
			_ => new UnknownPluginData(version, dataDict)
		};
		public object? RawData { get; init; }
		public int? Version { get; init; }
		public virtual Type DataType { get; } = typeof(object);

		[SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Signature is useful for inherited records")]
		public ExtendedPluginData(int version, Dictionary<object, object> dataDict) { RawData = null; Version = version; }
		public ExtendedPluginData() { RawData = null; }
	}
}
