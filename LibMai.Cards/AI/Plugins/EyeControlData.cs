namespace LibMai.Cards.AI.Plugins;
public record EyeControlData : AiPluginData
{
	public const string DataKey = DefinitionMetadata.DataKey;
	public override string GUID => DefinitionMetadata.PluginGUID;
	public readonly record struct DefinitionMetadata
	{
		public const string PluginGUID = "com.deathweasel.bepinex.eyecontrol";
		public const string DataKey = PluginGUID;
		public static readonly Version PluginVersion = new("1.0.1");
		public const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
		public const string ClassDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/EyeControl.Core/EyeControl.CharaController.cs";
		public const string License = "GPL 3.0";
	}
	public static readonly DefinitionMetadata Metadata = new();
	public override string Name => "Eye Control";
	public override Type DataType => Data.GetType();
	public EyeControlOptions Data { get; init; }

	public readonly record struct EyeControlOptions
	{
		public float EyeOpenMax { get; init; }
		public bool DisableBlinking { get; init; }
	}
	public EyeControlData(int version, in Dictionary<object, object> dataDict) : base(version, dataDict)
	{
		Data = new EyeControlOptions()
		{
			EyeOpenMax = (float)dataDict["EyeOpenMax"],
			DisableBlinking = (bool)dataDict["DisableBlinking"]
		};
	}
}
