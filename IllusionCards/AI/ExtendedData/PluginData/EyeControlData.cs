namespace IllusionCards.AI.ExtendedData.PluginData;
public record EyeControlData : ExtendedPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public readonly struct DefinitionMetadata
	{
		public const string PluginGUID = "com.deathweasel.bepinex.eyecontrol";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.0.1");
		public const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		public const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/EyeControl.Core/EyeControl.CharaController.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override Type DataType { get; } = typeof(MaterialEditorOptions);
	public MaterialEditorOptions Data { get; }

	public readonly struct MaterialEditorOptions
	{
		public float EyeOpenMax { get; init; }
		public bool DisableBlinking { get; init; }
	}
	public EyeControlData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new MaterialEditorOptions()
		{
			EyeOpenMax = (float)dataDict["EyeOpenMax"],
			DisableBlinking = (bool)dataDict["DisableBlinking"]
		};
	}
}
