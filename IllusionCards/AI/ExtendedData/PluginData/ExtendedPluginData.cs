namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record ExtendedPluginData
	{
		public static ExtendedPluginData GetExtendedPluginData(string pluginGUID, Dictionary<object, object> dataDict) => pluginGUID switch
		{
			BepinExSideloaderData.PluginGUID => new BepinExSideloaderData(dataDict),
			AdditionalAccessoriesData.PluginGUID => new AdditionalAccessoriesData(dataDict),
			UncensorSelectorData.PluginGUID => new UncensorSelectorData(dataDict),
			EyeControlData.PluginGUID => new EyeControlData(dataDict),
			DynamicBoneEditorData.PluginGUID => new DynamicBoneEditorData(dataDict),
			KK_InvisibleBodyData.PluginGUID => new KK_InvisibleBodyData(dataDict),
			KK_PregnancyPlusData.PluginGUID => new KK_PregnancyPlusData(dataDict),
			PushUpAIData.PluginGUID => new PushUpAIData(dataDict),
			AdditionalAccessoryControlsData.PluginGUID => new AdditionalAccessoryControlsData(dataDict),
			AdvIKPluginData.PluginGUID => new AdvIKPluginData(dataDict),
			_ => new ExtendedPluginData(dataDict)
		};
		public const object? PluginGUID = null;
		public object RawData { get; init; }
		public virtual Type DataType { get; init; } = typeof(object);
		public ExtendedPluginData(Dictionary<object, object> dataDict) { RawData = dataDict; }
	}
}
