using IllusionCards.FakeUnity;

using static IllusionCards.AI.Chara.AiFace;

namespace IllusionCards.AI.Chara
{
	public readonly struct AiFriendlyCharaData
	{
		public Body BodyStats { get; internal init; }
		public Face FaceStats { get; init; }
		public readonly struct Body
		{
			public OverallStats Overall { get; init; }
			public BreastStats Breast { get; init; }
			public UpperBodyStats UpperBody { get; init; }
			public LowerBodyStats LowerBody { get; init; }
			public ArmsStats Arms { get; init; }
			public LegsStats Legs { get; init; }

			public readonly struct OverallStats
			{
				public float Height { get; internal init; } // 0
				public float HeadSize { get; init; } // 9

			}
			public readonly struct BreastStats
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
			public readonly struct UpperBodyStats
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
			public readonly struct LowerBodyStats
			{
				public float WaistHeight { get; init; } // 18
				public float PelvisWidth { get; init; } // 19
				public float PelvisThickness { get; init; } // 20
				public float HipsWidth { get; init; } // 21
				public float HipsThickness { get; init; } // 22
				public float Butt { get; init; } // 23
				public float ButtAngle { get; init; } // 24
			}
			public readonly struct ArmsStats
			{
				public float Shoulder { get; init; } // 29
				public float UpperArms { get; init; } // 30
				public float Forearm { get; init; } // 31
			}
			public readonly struct LegsStats
			{
				public float UpperThighs { get; init; } // 25
				public float LowerThighs { get; init; } // 26
				public float Calves { get; init; } // 27
				public float Ankles { get; init; } // 28
			}
		}
		public readonly struct Face
		{
			public FaceType FaceTypeStats { get; init; }
			public Overall OverallStats { get; init; }
			public Jaw JawStats { get; init; }
			public Cheeks CheeksStats { get; init; }
			public Eyebrows EyebrowsStats { get; init; }
			public Eye EyeStats { get; init; }
			public Nose NoseStats { get; init; }
			public Mouth MouthStats { get; init; }
			public Ears EarsStats { get; init; }
			public Moles MolesStats { get; init; }
			public IrisSettings IrisSettingsStats { get; init; }
			public EyeHighlights EyeHighlightsStats { get; init; }
			public EyebrowType EyebrowTypeStats { get; init; }
			public EyelashType EyelashTypeStats { get; init; }
			public Eyeshadow EyeshadowStats { get; init; }
			public Blush BlushStats { get; init; } // It's called "Cheeks" for both the structure and the makeup, so this is "Blush" to avoid a naming conflict
			public Lipstick LipstickStats { get; init; } // "Lipstick" to avoid confusion with structure
			public readonly struct FaceType
			{
				public string Contour { get; init; }
				public string Skin { get; init; }
				public string Wrinkles { get; init; }
			}
			public readonly struct Overall
			{
				public float HeadWidth { get; init; }
				public float UpperDepth { get; init; }
				public float UpperHeight { get; init; }
				public float LowerDepth { get; init; }
				public float LowerWidth { get; init; }
			}
			public readonly struct Jaw
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
			public readonly struct Cheeks
			{
				public float LowerHeight { get; init; }
				public float LowerDepth { get; init; }
				public float LowerWidth { get; init; }
				public float UpperHeight { get; init; }
				public float UpperDepth { get; init; }
				public float UpperWidth { get; init; }
			}
			public readonly struct Eyebrows
			{
				public float Width { get; init; }
				public float Height { get; init; }
				public float PositionX { get; init; }
				public float PositionY { get; init; }
				public float AngleTilt { get; init; }

			}
			public readonly struct Eye
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
			public readonly struct Nose
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
			public readonly struct Mouth
			{
				public float MouthHeight { get; init; }
				public float MouthWidth { get; init; }
				public float LipThickness { get; init; }
				public float Depth { get; init; }
				public float UpperLipThickness { get; init; }
				public float LowerLipThickness { get; init; }
				public float CornerShape { get; init; }
			}
			public readonly struct Ears
			{
				public float EarSize { get; init; }
				public float EarAngle { get; init; }
				public float EarRotation { get; init; }
				public float UpEarShape { get; init; }
				public float LowEarShape { get; init; }
			}
			public readonly struct Moles
			{
				public string MoleType { get; init; }
				public Color Color { get; init; }
				public float MoleWidth { get; init; }
				public float MoleHeight { get; init; }
				public float MolePositionX { get; init; }
				public float MolePositionY { get; init; }
			}
			public bool SetBothLeftAndRightEyes { get; init; }
			public EyesInfo LeftEyeInfo { get; init; }
			public EyesInfo RightEyeInfo { get; init; }
			public readonly struct IrisSettings
			{
				public float AdjustHeight { get; init; }
				public float ShadowRange { get; init; }
			}
			public readonly struct EyeHighlights
			{
				public int Type { get; init; }
				public Color Color { get; init; }
				public float Width { get; init; }
				public float Height { get; init; }
				public float PositionX { get; init; }
				public float PositionY { get; init; }
				public float Tilt { get; init; }
			}
			public readonly struct EyebrowType
			{
				public int Type { get; init; }
				public Color Color { get; init; }
			}
			public readonly struct EyelashType
			{
				public int Type { get; init; }
				public Color Color { get; init; }
			}
			public readonly struct Eyeshadow
			{
				public int Type { get; init; }
				public Color Color { get; init; }
				public float Shine { get; init; }
			}
			public readonly struct Blush
			{
				public int Type { get; init; }
				public Color Color { get; init; }
				public float Shine { get; init; }
			}
			public readonly struct Lipstick
			{
				public int Type { get; init; }
				public Color Color { get; init; }
				public float Shine { get; init; }
			}
			public PaintInfo Paint1 { get; init; }
			public PaintInfo Paint2 { get; init; }
		}
	}
}
