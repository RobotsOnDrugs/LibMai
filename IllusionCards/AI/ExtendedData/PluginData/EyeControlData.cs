namespace IllusionCards.AI.ExtendedData.PluginData;
public record EyeControlData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	private readonly struct DefinitionMetadata
	{
		internal const string PluginGUID = "com.deathweasel.bepinex.eyecontrol";
		internal const string DataKey = PluginGUID;
		internal readonly Version PluginVersion = new("1.0.1");
		internal const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		internal const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/EyeControl.Core/EyeControl.CharaController.cs";
		internal const string License = "GPL 3.0";
	}
	public override Type DataType { get; } = typeof(MaterialEditorOptions);
	public readonly struct MaterialEditorOptions
	{
		public float EyeOpenMax { get; init; }
		public bool DisableBlinking { get; init; }
	}
	public MaterialEditorOptions Data { get; }
	public EyeControlData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new MaterialEditorOptions()
		{
			EyeOpenMax = (float)dataDict["EyeOpenMax"],
			DisableBlinking = (bool)dataDict["DisableBlinking"]
		};
	}
}
