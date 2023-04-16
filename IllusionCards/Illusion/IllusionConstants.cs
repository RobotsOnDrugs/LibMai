namespace IllusionCards.Illusion;

public readonly record struct IllusionConstants
{
	public static readonly ImmutableArray<byte> MarkerOpener = "【"u8.ToImmutableArray();
	public static readonly ImmutableArray<byte> MarkerCloser = "】"u8.ToImmutableArray();

	public const string AiCustomBlockName = "Custom";
	public const string AiCoordinateBlockName = "Coordinate";
	public const string AiParameterBlockName = "Parameter";
	public const string AiParameter2BlockName = "Parameter2";
	public const string AiGameInfoBlockName = "GameInfo";
	public const string AiGameInfo2BlockName = "GameInfo2";
	public const string AiStatusBlockName = "Status";
	public const string AiPluginDataBlockName = "KKEx";

	public const string AICharaIdentifier = "【AIS_Chara】";
	public const string AIClothesIdentifier = "【AIS_Clothes】";
	public const string StudioNEOV2Identifier = "【StudioNEOV2】";

	public const string KKCharaIdentifier = "【KoiKatuChara】";
	public const string KKPartyCharaIdentifier = "【KoiKatuCharaS】";
	public const string KKPartySPCharaIdentifier = "【KoiKatuCharaSP】";
	public const string KStudioIdentifier = "【KStudio】";

	public const string ECCharaIdentifier = "【EroMakeChara】";

	public const string PHFemaleCharaIdentifier = "【PlayHome_Female】";
	public const string PHMaleCharaIdentifier = "【PlayHome_Male】";
	public const string PHFemaleClothesIdentifier = "【PlayHome_FemaleCoordinate】";
	public const string PHStudioIdentifier = "【PHStudio】";

	public static readonly ImmutableDictionary<CardType, string> CardTypeNames = new Dictionary<CardType, string>()
	{
		[CardType.None] = "Invalid card",
		[CardType.Unknown] = "Unknown card type",
		[CardType.AICharaUnknown] = "AI Shoujo/Honey Select 2 character (unknown gender)",
		[CardType.AICoordinateUnknown] = "AI Shoujo/Honey Select 2 outfit (unknown gender)",
		[CardType.AICharaFemale] = "AI Shoujo/Honey Select 2 female Character",
		[CardType.AICharaMale] = "AI Shoujo/Honey Select 2 male character",
		[CardType.AICoordinateFemale] = "AI Shoujo/Honey Select 2 female outfit",
		[CardType.AICoordinateMale] = "AI Shoujo/Honey Select 2 male outfit",
		[CardType.AIScene] = "Studio NEO v2 scene",
		[CardType.KKChara] = "Koikatsu character",
		[CardType.KKPartyChara] = "Koikatsu Party character",
		[CardType.KKPartySPChara] = "Koikatsu Party SP character",
		[CardType.KKScene] = "Koikatsu Chara Studio scene",
		[CardType.PHCharaFemale] = "PlayHome female character",
		[CardType.PHCharaMale] = "PlayHome male character",
		[CardType.PHClothesFemale] = "PlayHome female clothes",
		[CardType.PHScene] = "PlayHome Studio scene",
		[CardType.ECChara] = "Emotion Creators character"
	}.ToImmutableDictionary();
}
