namespace IllusionCards.AI.ExtendedData.PluginData
{
	public abstract record ExtendedPluginData
	{
		public static ExtendedPluginData GetExtendedPluginData(string dataKey, Dictionary<object, object> dataDict) => dataKey switch
		{
			BepinExSideloaderData.DataKey => new BepinExSideloaderData(dataDict),
			AdditionalAccessoriesData.DataKey => new AdditionalAccessoriesData(dataDict),
			UncensorSelectorData.DataKey => new UncensorSelectorData(dataDict),
			EyeControlData.DataKey => new EyeControlData(dataDict),
			DynamicBoneEditorData.DataKey => new DynamicBoneEditorData(dataDict),
			KK_InvisibleBodyData.DataKey => new KK_InvisibleBodyData(dataDict),
			KK_PregnancyPlusData.DataKey => new KK_PregnancyPlusData(dataDict),
			PushUpAIData.DataKey => new PushUpAIData(dataDict),
			AdditionalAccessoryControlsData.DataKey => new AdditionalAccessoryControlsData(dataDict),
			AdvIKPluginData.DataKey => new AdvIKPluginData(dataDict),
			AdvancedBoneModData.DataKey => new AdvancedBoneModData(dataDict),
			_ => new UnknownPluginData(dataDict)
		};
		public object? RawData { get; init; }
		public virtual Type DataType { get; init; } = typeof(object);
		public ExtendedPluginData(Dictionary<object, object> dataDict) { RawData = dataDict; }
		public ExtendedPluginData() { RawData = null; }
	}
}
