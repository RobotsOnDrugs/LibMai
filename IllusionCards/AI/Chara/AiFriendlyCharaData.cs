namespace IllusionCards.AI.Chara;

public readonly struct AiFriendlyCharaData
{
	public FaceData Face { get; internal init; }
	public BodyData Body { get; internal init; }
	public HairData Hair { get; internal init; }
	public ClothingData Clothing { get; internal init; }
	public ImmutableArray<AccessorySettingsData> Accessories { get; internal init; }
	public CharaInfoData CharaInfo { get; internal init; }
	public AISGameInfoData AISGameInfo { get; internal init; }
	public HS2GameInfoData HS2GameInfo { get; internal init; }
	public readonly struct FaceData
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
	public readonly struct BodyData
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
	public readonly struct HairData
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
	public readonly struct ClothingData
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
	public readonly struct AccessorySettingsData
	{
	}
	public readonly struct CharaInfoData { }
	public readonly struct AISGameInfoData { }
	public readonly struct HS2GameInfoData // GameInfo2
	{
		public readonly struct Mindset
		{

		}
		public int FavorLevel { get; init; }
		public int EnjoymentLevel { get; init; }
		public int AversionLevel { get; init; }
		public int SlaveryLevel { get; init; }
		public int BrokenLevel { get; init; }
		public int DependenceLevel { get; init; }
		public bool StateLocked { get; init; }
		public bool BrokenLevelLocked { get; init; }
		public bool DependenceLevelLocked { get; init; }
		public AiCharaCardDefinitions.HS2CharaStatus State { get; init; } // The dominant state, which is the highest priority state for the character's personality (must be >= 20)
		public AiCharaCardDefinitions.HS2CharaStatus DisplayedState { get; init; } // The dominant state, but only if the stat is >= 50 - this determines the girl's displayed state in the lobby/H scenes/whatever
		public int DirtyLevel { get; init; }
		public int TirednessLevel { get; init; }
		public int ToiletLevel { get; init; }
		public int LibidoLevel { get; init; }
		public int AlertnessLevel { get; init; } // This doesn't seem to actually be used for anything, and all of my characters have this set to 0
	}
}
