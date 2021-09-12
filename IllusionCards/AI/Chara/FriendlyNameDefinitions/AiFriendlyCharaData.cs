namespace IllusionCards.AI.Chara;

public readonly record struct AiFaceData
{
	public FaceTypeData FaceType { get; init; }
	public OverallData Overall { get; init; }
	public JawData Jaw { get; init; }
	public CheeksData Cheeks { get; init; }
	public EyebrowsData Eyebrows { get; init; }
	public EyeData Eye { get; init; }
	public NoseData Nose { get; init; }
	public MouthData Mouth { get; init; }
	public EarsData Ears { get; init; }
	public MolesData Moles { get; init; }
	public bool SetBothLeftAndRightEyes { get; init; }
	public EyeInfo LeftEye { get; init; }
	public EyeInfo RightEye { get => SetBothLeftAndRightEyes ? LeftEye : RightEye_ ?? throw new NullReferenceException(); }
	internal EyeInfo? RightEye_ { get; init; }
	public IrisData IrisSettings { get; init; }
	public EyeHighlightsData EyeHighlights { get; init; }
	public EyebrowTypeData EyebrowType { get; init; }
	public EyelashTypeData EyelashType { get; init; }
	public EyeshadowData Eyeshadow { get; init; }
	public BlushData Blush { get; init; } // It's called "Cheeks" for both the structure and the makeup, so this is "Blush" to avoid a naming conflict
	public LipstickData Lipstick { get; init; } // "Lipstick" to avoid confusion with structure
	public AiPaintInfo Paint1 { get; init; }
	public AiPaintInfo Paint2 { get; init; }
	public readonly record struct FaceTypeData
	{
		public string Contour { get; init; }
		public string Skin { get; init; }
		public string Wrinkles { get; init; }
	}
	public readonly record struct OverallData
	{
		public float HeadWidth { get; init; }
		public float UpperDepth { get; init; }
		public float UpperHeight { get; init; }
		public float LowerDepth { get; init; }
		public float LowerWidth { get; init; }
	}
	public readonly record struct JawData
	{
		public float JawWidth { get; init; }
		public float JawHeight { get; init; }
		public float JawDepth { get; init; }
		public float JawAngle { get; init; }
		public float NeckDroop { get; init; }
		public float ChinSize { get; init; }
		public float ChinHeight { get; init; }
		public float ChinDepth { get; init; }
	}
	public readonly record struct CheeksData
	{
		public float LowerHeight { get; init; }
		public float LowerDepth { get; init; }
		public float LowerWidth { get; init; }
		public float UpperHeight { get; init; }
		public float UpperDepth { get; init; }
		public float UpperWidth { get; init; }
	}
	public readonly record struct EyebrowsData
	{
		public float Width { get; init; }
		public float Height { get; init; }
		public float PositionX { get; init; }
		public float PositionY { get; init; }
		public float AngleTilt { get; init; }
	}
	public readonly record struct EyeData
	{
		public float EyeHeight { get; init; }
		public float EyeSpacing { get; init; }
		public float EyeDepth { get; init; }
		public float EyeWidth { get; init; }
		public float EyeVertical { get; init; }
		public float EyeAngleZ { get; init; }
		public float EyeAngleY { get; init; }
		public float OuterHeight { get; init; }
		public float OuterDist { get; init; }
		public float InnerHeight { get; init; }
		public float InnerDist { get; init; }
		public float EyelidShape1 { get; init; }
		public float EyelidShape2 { get; init; }
	}
	public readonly record struct NoseData
	{
		public float NoseHeight { get; init; }
		public float NoseDepth { get; init; }
		public float NoseAngle { get; init; }
		public float NoseSize { get; init; }
		public float BridgeHeight { get; init; }
		public float BridgeWidth { get; init; }
		public float BridgeShape { get; init; }
		public float NostrilWidth { get; init; }
		public float NostrilHeight { get; init; }
		public float NostrilLength { get; init; }
		public float NostrilInnerWidth { get; init; }
		public float NostrilOuterWidth { get; init; }
		public float NoseTipLength { get; init; }
		public float NoseTipHeight { get; init; }
		public float NoseTipSize { get; init; }
	}
	public readonly record struct MouthData
	{
		public float MouthHeight { get; init; }
		public float MouthWidth { get; init; }
		public float LipThickness { get; init; }
		public float Depth { get; init; }
		public float UpperLipThickness { get; init; }
		public float LowerLipThickness { get; init; }
		public float CornerShape { get; init; }
	}
	public readonly record struct EarsData
	{
		public float EarSize { get; init; }
		public float EarAngle { get; init; }
		public float EarRotation { get; init; }
		public float UpEarShape { get; init; }
		public float LowEarShape { get; init; }
	}
	public readonly record struct MolesData
	{
		public string MoleType { get; init; }
		public Color Color { get; init; }
		public float MoleWidth { get; init; }
		public float MoleHeight { get; init; }
		public float MolePositionX { get; init; }
		public float MolePositionY { get; init; }
	}
	public readonly record struct EyeInfo
	{
		public Color ScleraColor { get; init; }
		public int _Iris { get; init; } // Illusion got "pupil" and "iris" mixed up in their variable names - pupilX refers to the iris and blackX refers to the pupil
		public Color IrisColor { get; init; }
		public float IrisWidth { get; init; }
		public float IrisHeight { get; init; }
		public float IrisGlow { get; init; }
		public int _Pupil { get; init; }
		public Color PupilColor { get; init; }
		public float PupilWidth { get; init; }
		public float PupilHeight { get; init; }
	}
	public readonly record struct IrisData
	{
		public float AdjustHeight { get; init; }
		public float ShadowRange { get; init; }
	}
	public readonly record struct EyeHighlightsData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Width { get; init; }
		public float Height { get; init; }
		public float PositionX { get; init; }
		public float PositionY { get; init; }
		public float Tilt { get; init; }
	}
	public readonly record struct EyebrowTypeData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
	}
	public readonly record struct EyelashTypeData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
	}
	public readonly record struct EyeshadowData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Shine { get; init; }
	}
	public readonly record struct BlushData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Shine { get; init; }
	}
	public readonly record struct LipstickData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Shine { get; init; }
	}
}
public readonly record struct AiBodyData
{
	public OverallData Overall { get; init; }
	public BreastData Breast { get; init; }
	public UpperBodyData UpperBody { get; init; }
	public LowerBodyData LowerBody { get; init; }
	public ArmsData Arms { get; init; }
	public LegsData Legs { get; init; }
	public SkinTypeData SkinType { get; init; }
	public SuntanData Suntan { get; init; }
	public NipplesData Nipples { get; init; }
	public PubicHairData PubicHair { get; init; }
	public NailColorData NailColor { get; init; }
	public AiPaintInfo Paint1 { get; init; }
	public AiPaintInfo Paint2 { get; init; }
	public bool IsFuta { get; init; }

	public readonly record struct OverallData
	{
		public float Height { get; internal init; } // 0
		public float HeadSize { get; init; } // 9
	}
	public readonly record struct BreastData
	{
		public float Size { get; init; } // 1
		public float Height { get; init; } // 2
		public float Direction { get; init; } // 3
		public float Spacing { get; init; } // 4
		public float Angle { get; init; } // 5
		public float Length { get; init; } // 6
		public float Softness { get; init; } // bustSoftness
		public float Weight { get; init; } // bustWeight
		public float AreolaDepth { get; init; } // 7
		public float AreolaSize { get; init; } // areolaSize
		public float NippleWidth { get; init; } // 8
		public float NippleDepth { get; init; } // 32
	}
	public readonly record struct UpperBodyData
	{
		public float NeckWidth { get; init; } // 10
		public float NeckThickness { get; init; } // 11
		public float ShoulderWidth { get; init; } // 12
		public float ShoulderThickness { get; init; } // 13
		public float ChestWidth { get; init; } // 14
		public float ChestThickness { get; init; } // 15
		public float WaistWidth { get; init; } // 16
		public float WaistThickness { get; init; } // 17
	}
	public readonly record struct LowerBodyData
	{
		public float WaistHeight { get; init; } // 18
		public float PelvisWidth { get; init; } // 19
		public float PelvisThickness { get; init; } // 20
		public float HipsWidth { get; init; } // 21
		public float HipsThickness { get; init; } // 22
		public float Butt { get; init; } // 23
		public float ButtAngle { get; init; } // 24
	}
	public readonly record struct ArmsData
	{
		public float Shoulder { get; init; } // 29
		public float UpperArms { get; init; } // 30
		public float Forearm { get; init; } // 31
	}
	public readonly record struct LegsData
	{
		public float UpperThighs { get; init; } // 25
		public float LowerThighs { get; init; } // 26
		public float Calves { get; init; } // 27
		public float Ankles { get; init; } // 28
	}
	public readonly record struct SkinTypeData
	{

	}
	public readonly record struct SuntanData
	{

	}
	public readonly record struct NipplesData
	{

	}
	public readonly record struct PubicHairData
	{

	}
	public readonly record struct NailColorData
	{

	}
}
public readonly record struct AiHairData
{
	public bool MatchBackHairAndBangs { get; init; }
	public bool AutoSetRootAndTipColors { get; init; }
	public bool MatchHairAxisSettings { get; init; }
	public HairSettingsData BackHair { get; init; }
	public HairSettingsData Bangs { get; init; }
	public HairSettingsData SideHair { get; init; }
	public HairSettingsData HairExtensions { get; init; }
	public HairRenderType RenderType { get; init; }

	public struct HairSettingsData
	{
	}
	public enum HairRenderType
	{
		RenderType01,
		RenderType02
	}
}
public readonly record struct AiClothingData
{
	public ClothingSettingsData Top { get; init; }
	public ClothingSettingsData Bottom { get; init; }
	public ClothingSettingsData InnerTop { get; init; }
	public ClothingSettingsData InnerBottom { get; init; }
	public ClothingSettingsData Gloves { get; init; }
	public ClothingSettingsData Pantyhose { get; init; }
	public ClothingSettingsData Socks { get; init; }
	public ClothingSettingsData Shoes { get; init; }
	public readonly record struct ClothingSettingsData
	{

	}
}
public readonly record struct AiAccessoriesData
{
}
public readonly record struct AiCharaStatusData // Status
{
	public Version Version { get; init; }
	//public byte[] clothesState { get; init; } = null!;
	public ClothingState Top { get; init; }
	public ClothingState Bottom { get; init; }
	public ClothingState InnerTop { get; init; }
	public ClothingState InnerBottom { get; init; }
	public ClothingState Pantyhose { get; init; }
	public ClothingState Gloves { get; init; }
	public ClothingState Socks { get; init; }
	public ClothingState Shoes { get; init; }
	public ImmutableArray<bool> AccessoryIsVisible { get; init; }
	public int EyebrowPosition { get; init; }
	public float EyebrowOpenMax { get; init; }
	public int EyesPosition { get; init; }
	public float EyesMaximumOpenAmount { get; init; }
	public bool BlinkingEnabled { get; init; }
	public bool eyesYure { get; init; }
	public int MouthPosition { get; init; }
	public float MouthMinimumOpenAmount { get; init; }
	public float MouthMaximumOpenAmount { get; init; }
	public bool MouthIsFixed { get; init; }
	public bool mouthAdjustWidth { get; init; }
	public byte TongueState { get; init; }
	public EyeLookType EyesLookPosition { get; init; }
	public int EyesTargetType { get; init; }
	public float EyesTargetAngle { get; init; }
	public float EyesTargetRange { get; init; }
	public float EyesTargetRate { get; init; }
	public NeckLookType NeckLookPosition { get; init; }
	public int neckTargetType { get; init; }
	public float neckTargetAngle { get; init; }
	public float neckTargetRange { get; init; }
	public float neckTargetRate { get; init; }
	public bool disableMouthShapeMask { get; init; }
	public bool[,] disableBustShapeMask { get; init; } = null!;
	public float NippleStiffness { get; init; }
	public float SkinGloss { get; init; }
	public float BlushingAmount { get; init; }
	public float TearsAmount { get; init; }
	public bool hideEyesHighlight { get; init; }
	public byte[] siruLv { get; init; }
	public float Wetness { get; init; }
	public bool PenisIsVisible { get; init; }
	public bool PenisIsAlwaysVisible { get; init; }
	public bool HeadIsAlwaysVisible { get; init; }
	public bool BodyIsAlwaysVisible { get; init; }
	public bool IsMonochrome { get; init; } // visibleSimple
	public bool visibleGomu { get; init; } // Condom?
	public Color MonochromeColor { get; init; } // simpleColor
	public ImmutableArray<bool> enableShapeHand { get; init; }
	public int[,] shapeHandPtn { get; init; }
	public ImmutableArray<float> shapeHandBlendValue { get; init; }
	public float siriAkaRate { get; init; }
	public enum ClothingState
	{
		None = 0b00,
		Half = 0b01,
		Full = 0b10
	}
	public enum EyeLookType
	{
		NO_LOOK,
		TARGET,
		AWAY,
		FORWARD,
		CONTROL
	}
	public enum NeckLookType
	{
		NO_LOOK,
		TARGET,
		AWAY,
		FORWARD,
		FIX,
		CONTROL
	}
}
public readonly record struct AiCharaInfoData // Parameter - this is common to both AIS and HS2
{
	public CharaSex Sex { get; init; }
	public string Name { get; init; }
	public PersonalityType Personality { get; init; }
	public int BirthMonth { get; init; }
	public int BirthDay { get; init; }
	public float VoiceRate { get; init; }
	public float VoicePitch => Mathf.Lerp(0.94f, 1.06f, VoiceRate);
	public bool IsFuta { get; init; }

	public enum PersonalityType
	{
		Composed,
		Normal,
		Hardworking,
		Girlfriend,
		Fashionable,
		Timid,
		Motherly,
		Sadistic,
		OpenMinded,
		Airhead,
		Careful,
		IdealJapanese,
		Tomboy,
		Obsessed
	}
}
public readonly record struct AISGameData // GameInfo
{
	public ImmutableHashSet<int> Wishes { get; init; } // This comes from Parameter and seems to be AIS-specific
	public bool gameRegistration { get; init; }
	public float LowerTempBound { get; init; }
	public float UpperTempBound { get; init; }
	public float LowerMoodBound { get; init; }
	public float UpperMoodBound { get; init; }
	public Dictionary<FlavorType, int> FlavorState { get; init; } = null!;
	public int totalFlavor { get; init; }
	public Dictionary<DesireFlags, DesireData> Desire { get; init; } = null!;
	public int Hearts { get; init; } // phase
	public Dictionary<int, int> normalSkill { get; init; } = null!;
	public Dictionary<int, int> hSkill { get; init; } = null!;
	public int favoritePlace { get; init; }
	public LifestyleType Lifestyle { get; init; }
	public int morality { get; init; }
	public int motivation { get; init; }
	public int immoral { get; init; }
	public bool isHAddTaii0 { get; init; }
	public bool isHAddTaii1 { get; init; }
	public enum FlavorType
	{
		Pheromone,
		Reliability,
		Reason,
		Instinct,
		Dirty,
		Wariness,
		Darkness,
		Sociability
	}
	[Flags]
	public enum DesireFlags
	{
		None = 0,
		Toilet = 1,
		Bath = 2,
		Sleep = 4,
		Eat = 8,
		Break = 16,
		Gift = 32,
		Want = 64,
		Lonely = 128,
		H = 256,
		Dummy = 512,
		Hunt = 1024,
		Game = 2048,
		Cook = 4096,
		Animal = 8192,
		Location = 16384,
		Drink = 32768
	}
	public enum StatusType
	{
		Temperature,
		Mood,
		Hunger,
		Physical,
		Life,
		Motivation,
		Immoral,
		Morality
	}
	public enum LifestyleType
	{
		Getter,
		Baby,
		Driver,
		Controller,
		ExcitementSeeker,
		Armchair
	}
	public enum SkillType
	{
		None = -1,
		CookingLover,
		CleanLover,
		AnimalLover,
		SleepingPrincess,
		PriestessBloodline,
		Achiever,
		Simple,
		ReactionLover,
		Dear,
		DevotedPartner,
		FishingLover,
		Klutz,
		CropKnowledge,
		Avarice,
		Tireless,
		Glutton,
		RainLover,
		Wild,
		GoodsSupplier,
		Beastmaster,
		Moody,
		LovesToPlay,
		SexualDesire,
		Curiosity,
		CursedBody,
		Sensitive,
		Distrustful,
		HeartWall,
		BodyManagement,
		Endurance,
		Lonely,
		GoodTalker,
		Chatty,
		Doer,
		SuperSense,
		Slacker,
		Fastidious,
		Misfortune,
		WeakConstitution,
		DeepDarkness,
		Unkempt,
		Lucky,
		DiggingManiac,
		BugCollector,
		Hunter,
		Courage,
		Collector,
		TerrainGrasp,
		Guts,
		GoodLuck
	}
	public readonly record struct DesireData
	{
		public float BaseDesire { get; init; }
		public float DesireBuff { get; init; }
	}
}
public readonly record struct HS2GameData // GameInfo2 and Parameter2
{
	public SexTraitType SexTrait { get; init; }
	public MentalityType Mentality { get; init; }
	public TraitType Trait { get; init; }
	public int FavorLevel { get; init; }
	public int EnjoymentLevel { get; init; }
	public int AversionLevel { get; init; }
	public int SlaveryLevel { get; init; }
	public int BrokenLevel { get; init; }
	public int DependenceLevel { get; init; }
	public bool StateLocked { get; init; }
	public bool BrokenLevelLocked { get; init; }
	public bool DependenceLevelLocked { get; init; }
	public HS2CharaStatus State { get; init; } // The dominant state, which is the highest priority state for the character's personality (must be >= 20)
	public HS2CharaStatus DisplayedState { get; init; } // The dominant state, but only if the stat is >= 50 - this determines the girl's displayed state in the lobby/H scenes/whatever
	public int DirtyLevel { get; init; }
	public int TirednessLevel { get; init; }
	public int ToiletLevel { get; init; }
	public int LibidoLevel { get; init; }
	public int AlertnessLevel { get; init; } // This doesn't seem to actually be used for anything, and all of my characters have this set to 0
											 // public bool arriveRoom50 { get; init; } // Something to do with bath events
											 // public bool arriveRoom80 { get; init; } // ?
											 //public bool arriveRoomHAfter { get; init; }
	public int SexExperience { get; init; } // resistH
	public int BDSMExperience { get; init; } // resistPain
	public int AnalExperience { get; init; } // resistAnal
	public SexItemType ActiveItem { get; init; } // usedItem
												 //public bool IsChangeParameter { get; init; }
	public bool IsConcierge { get; init; }
	public enum SexTraitType // hAttribute
	{
		None,
		Horny,
		Sadist,
		Masochist,
		SensitiveBreasts,
		SensitiveAss,
		SensitivePussy,
		LoveKisses,
		CleanFreak,
		SexHater,
		Lonely
	}
	public enum MentalityType // mind
	{
		None,
		Curious,
		Affectionate,
		Lovestruck,
		Awkward,
		Reluctant,
		Loathing,
		Cooperative,
		Obedient,
		Submissive,
		Interested,
		Charmed,
		Aroused,
	}
	public enum TraitType // trait
	{
		None,
		CleanLover,
		Lazy,
		Fragile,
		Tough,
		WeakBladder,
		Patient,
		GlassHeart,
		Brave,
		Perverted,
		SelfControl,
		AtWill,
		Sensitive
	}
	public enum SexItemType { }

	public enum HS2CharaStatus
	{
		Blank,
		Favor,
		Enjoyment,
		Aversion,
		Slavery,
		Broken,
		Dependence
	}
}

public readonly record struct AiPaintInfo
{
	public int id { get; init; }
	public Color Color { get; init; }
	public float Shine { get; init; }
	public float Texture { get; init; }
	public int layoutId { get; init; }
	public Vector4 Position { get; init; }
	public float Rotation { get; init; }
}