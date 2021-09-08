namespace IllusionCards.AI.Chara;

public readonly struct AiFaceData
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
	public EyesInfo LeftEyeInfo { get; init; }
	public EyesInfo RightEyeInfo { get; init; }
	public IrisData IrisSettings { get; init; }
	public EyeHighlightsData EyeHighlights { get; init; }
	public EyebrowTypeData EyebrowType { get; init; }
	public EyelashTypeData EyelashType { get; init; }
	public EyeshadowData Eyeshadow { get; init; }
	public BlushData Blush { get; init; } // It's called "Cheeks" for both the structure and the makeup, so this is "Blush" to avoid a naming conflict
	public LipstickData Lipstick { get; init; } // "Lipstick" to avoid confusion with structure
	public PaintInfo Paint1 { get; init; }
	public PaintInfo Paint2 { get; init; }
	public readonly struct FaceTypeData
	{
		public string Contour { get; init; }
		public string Skin { get; init; }
		public string Wrinkles { get; init; }
	}
	public readonly struct OverallData
	{
		public float HeadWidth { get; init; }
		public float UpperDepth { get; init; }
		public float UpperHeight { get; init; }
		public float LowerDepth { get; init; }
		public float LowerWidth { get; init; }
	}
	public readonly struct JawData
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
	public readonly struct CheeksData
	{
		public float LowerHeight { get; init; }
		public float LowerDepth { get; init; }
		public float LowerWidth { get; init; }
		public float UpperHeight { get; init; }
		public float UpperDepth { get; init; }
		public float UpperWidth { get; init; }
	}
	public readonly struct EyebrowsData
	{
		public float Width { get; init; }
		public float Height { get; init; }
		public float PositionX { get; init; }
		public float PositionY { get; init; }
		public float AngleTilt { get; init; }
	}
	public readonly struct EyeData
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
	public readonly struct NoseData
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
	public readonly struct MouthData
	{
		public float MouthHeight { get; init; }
		public float MouthWidth { get; init; }
		public float LipThickness { get; init; }
		public float Depth { get; init; }
		public float UpperLipThickness { get; init; }
		public float LowerLipThickness { get; init; }
		public float CornerShape { get; init; }
	}
	public readonly struct EarsData
	{
		public float EarSize { get; init; }
		public float EarAngle { get; init; }
		public float EarRotation { get; init; }
		public float UpEarShape { get; init; }
		public float LowEarShape { get; init; }
	}
	public readonly struct MolesData
	{
		public string MoleType { get; init; }
		public Color Color { get; init; }
		public float MoleWidth { get; init; }
		public float MoleHeight { get; init; }
		public float MolePositionX { get; init; }
		public float MolePositionY { get; init; }
	}
	public readonly struct IrisData
	{
		public float AdjustHeight { get; init; }
		public float ShadowRange { get; init; }
	}
	public readonly struct EyeHighlightsData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Width { get; init; }
		public float Height { get; init; }
		public float PositionX { get; init; }
		public float PositionY { get; init; }
		public float Tilt { get; init; }
	}
	public readonly struct EyebrowTypeData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
	}
	public readonly struct EyelashTypeData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
	}
	public readonly struct EyeshadowData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Shine { get; init; }
	}
	public readonly struct BlushData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Shine { get; init; }
	}
	public readonly struct LipstickData
	{
		public int Type { get; init; }
		public Color Color { get; init; }
		public float Shine { get; init; }
	}
}
public readonly struct AiBodyData
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
	public PaintInfo Paint1 { get; init; }
	public PaintInfo Paint2 { get; init; }
	public bool IsFuta { get; init; }

	public readonly struct OverallData
	{
		public float Height { get; internal init; } // 0
		public float HeadSize { get; init; } // 9
	}
	public readonly struct BreastData
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
	public readonly struct UpperBodyData
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
	public readonly struct LowerBodyData
	{
		public float WaistHeight { get; init; } // 18
		public float PelvisWidth { get; init; } // 19
		public float PelvisThickness { get; init; } // 20
		public float HipsWidth { get; init; } // 21
		public float HipsThickness { get; init; } // 22
		public float Butt { get; init; } // 23
		public float ButtAngle { get; init; } // 24
	}
	public readonly struct ArmsData
	{
		public float Shoulder { get; init; } // 29
		public float UpperArms { get; init; } // 30
		public float Forearm { get; init; } // 31
	}
	public readonly struct LegsData
	{
		public float UpperThighs { get; init; } // 25
		public float LowerThighs { get; init; } // 26
		public float Calves { get; init; } // 27
		public float Ankles { get; init; } // 28
	}
	public readonly struct SkinTypeData
	{

	}
	public readonly struct SuntanData
	{

	}
	public readonly struct NipplesData
	{

	}
	public readonly struct PubicHairData
	{

	}
	public readonly struct NailColorData
	{

	}
}
public readonly struct AiHairData
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
public readonly struct AiClothingData
{
	public ClothingSettingsData Top { get; init; }
	public ClothingSettingsData Bottom { get; init; }
	public ClothingSettingsData InnerTop { get; init; }
	public ClothingSettingsData InnerBottom { get; init; }
	public ClothingSettingsData Gloves { get; init; }
	public ClothingSettingsData Pantyhose { get; init; }
	public ClothingSettingsData Socks { get; init; }
	public ClothingSettingsData Shoes { get; init; }
	public readonly struct ClothingSettingsData
	{

	}
}
public readonly struct AiAccessorySettingsData
{
}
public readonly struct AiCharaStatusData // Status
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
}
public readonly struct AiCharaInfoData // Parameter - this is common to both AIS and HS2
{
	public CharaSex Sex { get; init; }
	public string Name { get; init; }
	public PersonalityType Personality { get; init; }
	public int BirthMonth { get; init; }
	public int BirthDay { get; init; }
	public float VoiceRate { get; init; }
	public float VoicePitch => Mathf.Lerp(0.94f, 1.06f, VoiceRate);
	public bool IsFuta { get; init; }
}
public readonly struct AISGameData // GameInfo
{
	public ImmutableHashSet<int> Wishes => new HashSet<int>().ToImmutableHashSet(); // { get; init; } // This comes from Parameter and seems to be AIS-specific

}
public readonly struct HS2GameData // GameInfo2 and Parameter2
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
}

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

public static class AiFriendlyCharaData
{
	public static (AiFaceData, AiBodyData, AiHairData) GetAllFriendlyBodyData(AiCustom custom)
	{
		AiFaceData faceData = new()
		{
			FaceType = new()
			{
				Contour = GetFriendlyFaceContourName(custom.face.headId),
				Skin = GetFriendlyFaceSkinName(custom.face.skinId),
				Wrinkles = GetFriendlyFaceSkinName(custom.face.detailId),
			},
			Overall = new()
			{
				HeadWidth = custom.face.shapeValueFace[0],
				UpperDepth = custom.face.shapeValueFace[1],
				UpperHeight = custom.face.shapeValueFace[2],
				LowerDepth = custom.face.shapeValueFace[3],
				LowerWidth = custom.face.shapeValueFace[4],
			},
			Jaw = new()
			{
				JawWidth = custom.face.shapeValueFace[5],
				JawHeight = custom.face.shapeValueFace[6],
				JawDepth = custom.face.shapeValueFace[7],
				JawAngle = custom.face.shapeValueFace[8],
				NeckDroop = custom.face.shapeValueFace[9],
				ChinSize = custom.face.shapeValueFace[10],
				ChinHeight = custom.face.shapeValueFace[11],
				ChinDepth = custom.face.shapeValueFace[12]
			},
			Cheeks = new()
			{
				LowerHeight = custom.face.shapeValueFace[13],
				LowerDepth = custom.face.shapeValueFace[14],
				LowerWidth = custom.face.shapeValueFace[15],
				UpperHeight = custom.face.shapeValueFace[16],
				UpperDepth = custom.face.shapeValueFace[17],
				UpperWidth = custom.face.shapeValueFace[18]
			},
			Eyebrows = new()
			{
				Width = custom.face.eyebrowLayout.Z,
				Height = custom.face.eyebrowLayout.W,
				PositionX = custom.face.eyebrowLayout.X,
				PositionY = custom.face.eyebrowLayout.Y,
				AngleTilt = custom.face.eyebrowTilt
			},
			Eye = new()
			{
				EyeHeight = custom.face.shapeValueFace[23],
				EyeSpacing = custom.face.shapeValueFace[20],
				EyeDepth = custom.face.shapeValueFace[21],
				EyeWidth = custom.face.shapeValueFace[22],
				EyeVertical = custom.face.shapeValueFace[19],
				EyeAngleZ = custom.face.shapeValueFace[24],
				EyeAngleY = custom.face.shapeValueFace[25],
				OuterHeight = custom.face.shapeValueFace[29],
				OuterDist = custom.face.shapeValueFace[27],
				InnerHeight = custom.face.shapeValueFace[28],
				InnerDist = custom.face.shapeValueFace[26],
				EyelidShape1 = custom.face.shapeValueFace[30],
				EyelidShape2 = custom.face.shapeValueFace[31]
			},
			Nose = new()
			{
				NoseHeight = custom.face.shapeValueFace[32],
				NoseDepth = custom.face.shapeValueFace[33],
				NoseAngle = custom.face.shapeValueFace[34],
				NoseSize = custom.face.shapeValueFace[35],
				BridgeHeight = custom.face.shapeValueFace[36],
				BridgeWidth = custom.face.shapeValueFace[37],
				BridgeShape = custom.face.shapeValueFace[38],
				NostrilWidth = custom.face.shapeValueFace[39],
				NostrilHeight = custom.face.shapeValueFace[40],
				NostrilLength = custom.face.shapeValueFace[41],
				NostrilInnerWidth = custom.face.shapeValueFace[42],
				NostrilOuterWidth = custom.face.shapeValueFace[43],
				NoseTipLength = custom.face.shapeValueFace[44],
				NoseTipHeight = custom.face.shapeValueFace[45],
				NoseTipSize = custom.face.shapeValueFace[46]
			},
			Mouth = new()
			{
				MouthHeight = custom.face.shapeValueFace[47],
				MouthWidth = custom.face.shapeValueFace[48],
				LipThickness = custom.face.shapeValueFace[49],
				Depth = custom.face.shapeValueFace[50],
				UpperLipThickness = custom.face.shapeValueFace[51],
				LowerLipThickness = custom.face.shapeValueFace[52],
				CornerShape = custom.face.shapeValueFace[53]
			},
			Ears = new()
			{
				EarSize = custom.face.shapeValueFace[54],
				EarAngle = custom.face.shapeValueFace[55],
				EarRotation = custom.face.shapeValueFace[56],
				UpEarShape = custom.face.shapeValueFace[57],
				LowEarShape = custom.face.shapeValueFace[58]
			},
			Moles = new()
			{
				MoleType = GetFriendlyMoleName(custom.face.moleId),
				MoleWidth = custom.face.moleLayout.Z,
				MoleHeight = custom.face.moleLayout.W,
				MolePositionX = custom.face.moleLayout.X,
				MolePositionY = custom.face.moleLayout.Y
			},
			SetBothLeftAndRightEyes = custom.face.pupilSameSetting,
			LeftEyeInfo = custom.face.pupil[0],
			RightEyeInfo = custom.face.pupil[1],
			IrisSettings = new()
			{
				AdjustHeight = custom.face.pupilY,
				ShadowRange = custom.face.whiteShadowScale
			},
			EyeHighlights = new()
			{
				Type = custom.face.hlId,
				Color = custom.face.hlColor,
				Width = custom.face.hlLayout.Z,
				Height = custom.face.hlLayout.W,
				PositionX = custom.face.hlLayout.X,
				PositionY = custom.face.hlLayout.Y,
				Tilt = custom.face.hlTilt
			},
			EyebrowType = new()
			{
				Type = custom.face.eyebrowId,
				Color = custom.face.eyebrowColor
			},
			EyelashType = new()
			{
				Type = custom.face.eyelashesId,
				Color = custom.face.eyelashesColor
			},
			Eyeshadow = new()
			{
				Type = custom.face.makeup.eyeshadowId,
				Color = custom.face.makeup.eyeshadowColor,
				Shine = custom.face.makeup.eyeshadowGloss,
			},
			Blush = new()
			{
				Type = custom.face.makeup.cheekId,
				Color = custom.face.makeup.cheekColor,
				Shine = custom.face.makeup.cheekGloss
			},
			Lipstick = new()
			{
				Type = custom.face.makeup.lipId,
				Color = custom.face.makeup.lipColor,
				Shine = custom.face.makeup.lipGloss
			},
			Paint1 = custom.face.makeup.paintInfo[0],
			Paint2 = custom.face.makeup.paintInfo[1]
		};
		AiBodyData bodyData = new()
		{
			Overall = new()
			{
				Height = custom.body.shapeValueBody[0],
				HeadSize = custom.body.shapeValueBody[9]
			},
			Breast = new()
			{
				Size = custom.body.shapeValueBody[1],
				Height = custom.body.shapeValueBody[2],
				Direction = custom.body.shapeValueBody[3],
				Spacing = custom.body.shapeValueBody[4],
				Angle = custom.body.shapeValueBody[5],
				Length = custom.body.shapeValueBody[6],
				Softness = custom.body.bustSoftness,
				Weight = custom.body.bustWeight,
				AreolaDepth = custom.body.shapeValueBody[7],
				AreolaSize = custom.body.areolaSize,
				NippleWidth = custom.body.shapeValueBody[8],
				NippleDepth = custom.body.shapeValueBody[32]
			},
			UpperBody = new()
			{
				NeckWidth = custom.body.shapeValueBody[10],
				NeckThickness = custom.body.shapeValueBody[11],
				ShoulderWidth = custom.body.shapeValueBody[12],
				ShoulderThickness = custom.body.shapeValueBody[13],
				ChestWidth = custom.body.shapeValueBody[14],
				ChestThickness = custom.body.shapeValueBody[15],
				WaistWidth = custom.body.shapeValueBody[16],
				WaistThickness = custom.body.shapeValueBody[17],
			},
			LowerBody = new()
			{
				WaistHeight = custom.body.shapeValueBody[18],
				PelvisWidth = custom.body.shapeValueBody[19],
				PelvisThickness = custom.body.shapeValueBody[20],
				HipsWidth = custom.body.shapeValueBody[21],
				HipsThickness = custom.body.shapeValueBody[22],
				Butt = custom.body.shapeValueBody[23],
				ButtAngle = custom.body.shapeValueBody[24],
			},
			Arms = new()
			{
				Shoulder = custom.body.shapeValueBody[29],
				UpperArms = custom.body.shapeValueBody[30],
				Forearm = custom.body.shapeValueBody[31]
			},
			Legs = new()
			{
				UpperThighs = custom.body.shapeValueBody[25],
				LowerThighs = custom.body.shapeValueBody[26],
				Calves = custom.body.shapeValueBody[27],
				Ankles = custom.body.shapeValueBody[28],
			}
		};
		AiHairData hairData = new() { };
		return (faceData, bodyData, hairData);
	}
	[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "Analyzer doesn't recognize immutable builder methods as apparent")]
	public static (AiClothingData, ImmutableArray<AiAccessorySettingsData>) GetAllFriendlyCoordinateData(AiCoordinate coordinate)
	{
		AiClothingData clothingData = new() { };
		AiAccessorySettingsData _accessorySettingsData = new() { };
		var accessorySettingsDatas = ImmutableArray.CreateBuilder<AiAccessorySettingsData>();
		accessorySettingsDatas.Add(_accessorySettingsData);
		return (clothingData, accessorySettingsDatas.ToImmutable());
	}
	public static AiCharaInfoData GetFriendlyCharaInfoData(AiParameter parameter) => new()
	{
		Sex = (CharaSex)parameter.sex,
		Name = parameter.fullname,
		Personality = (PersonalityType)parameter.personality,
		BirthMonth = parameter.birthMonth,
		BirthDay = parameter.birthDay,
		VoiceRate = parameter.voiceRate,
		IsFuta = parameter.futanari
	};
	public static AISGameData GetFriendlyAISGameData(AiGameInfo gameInfo)
	{
		return new();
	}
	public static HS2GameData? GetFriendlyHS2GameInfoData(AiGameInfo2 gameInfo2, AiParameter2 parameter2)
	{
		return new();
	}

	public static AiCustom GetCustomData(AiFaceData faceData, AiBodyData bodyData, AiHairData hairData)
	{
		return Tsubomi.Custom;
	}
	public static AiCoordinate GetCoordinateData(AiClothingData clothingData, ImmutableArray<AiAccessorySettingsData> accessorySettingsDatas)
	{
		return Tsubomi.Coordinate;
	}
	public static AiParameter GetParameterData(AiCharaInfoData charaInfoData)
	{
		return Tsubomi.Parameter;
	}
	public static (AiParameter2, AiGameInfo2) GetRawHS2Data(HS2GameData gameData)
	{
		return (Tsubomi.Parameter2, Tsubomi.GameInfo2);
	}
}