using System.Collections.Immutable;

using IllusionCards.AI.Cards;
using IllusionCards.AI.ExtendedData.PluginData;
using IllusionCards.Chara;

using static IllusionCards.AI.Chara.FriendlyNameLookup;

namespace IllusionCards.AI.Chara
{
	public readonly struct AiChara : IIllusionChara
	{
		public IIllusionChara.CharaSex Sex { get {
				return Parameter.sex switch {
					0b0 => IIllusionChara.CharaSex.Male,
					0b1 => IIllusionChara.CharaSex.Female,
					_ => IIllusionChara.CharaSex.Unknown
		}; } }
		public string Name { get => Parameter.fullname; }

		public AiCustom Custom { get; init; }
		public AiCoordinate Coordinate { get; init; }
		public AiParameter Parameter { get; init; }
		public AiParameter2? Parameter2 { get; init; }
		public AiGameInfo GameInfo { get; init; }
		public AiGameInfo2? GameInfo2 { get; init; }
		public AiStatus Status { get; init; }
		public ImmutableHashSet<AiPluginData>? ExtendedData { get; init; }
		public ImmutableHashSet<NullPluginData>? NullData { get; init; }
		public AiFriendlyCharaData FriendlyCharaData { get => GetAiFriendlyCharaData(Custom); }
		public static AiFriendlyCharaData GetAiFriendlyCharaData(AiCustom custom)
		{
			return new()
			{
				BodyStats = new()
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
				},
				FaceStats = new()
				{
					FaceTypeStats = new()
					{
						Contour = GetFriendlyFaceContourName(custom.face.headId),
						Skin = GetFriendlyFaceSkinName(custom.face.skinId),
						Wrinkles = GetFriendlyFaceSkinName(custom.face.detailId),
					},
					OverallStats = new()
					{
						HeadWidth = custom.face.shapeValueFace[0],
						UpperDepth = custom.face.shapeValueFace[1],
						UpperHeight = custom.face.shapeValueFace[2],
						LowerDepth = custom.face.shapeValueFace[3],
						LowerWidth = custom.face.shapeValueFace[4],
					},
					JawStats = new()
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
					CheeksStats = new()
					{
						LowerHeight = custom.face.shapeValueFace[13],
						LowerDepth = custom.face.shapeValueFace[14],
						LowerWidth = custom.face.shapeValueFace[15],
						UpperHeight = custom.face.shapeValueFace[16],
						UpperDepth = custom.face.shapeValueFace[17],
						UpperWidth = custom.face.shapeValueFace[18]
					},
					EyebrowsStats = new()
					{
						Width = custom.face.eyebrowLayout.z,
						Height = custom.face.eyebrowLayout.w,
						PositionX = custom.face.eyebrowLayout.x,
						PositionY = custom.face.eyebrowLayout.y,
						AngleTilt = custom.face.eyebrowTilt
					},
					EyeStats = new()
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
					NoseStats = new()
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
					MouthStats = new()
					{
						MouthHeight = custom.face.shapeValueFace[47],
						MouthWidth = custom.face.shapeValueFace[48],
						LipThickness = custom.face.shapeValueFace[49],
						Depth = custom.face.shapeValueFace[50],
						UpperLipThickness = custom.face.shapeValueFace[51],
						LowerLipThickness = custom.face.shapeValueFace[52],
						CornerShape = custom.face.shapeValueFace[53]
					},
					EarsStats = new()
					{
						EarSize = custom.face.shapeValueFace[54],
						EarAngle = custom.face.shapeValueFace[55],
						EarRotation = custom.face.shapeValueFace[56],
						UpEarShape = custom.face.shapeValueFace[57],
						LowEarShape = custom.face.shapeValueFace[58]
					},
					MolesStats = new()
					{
						MoleType = GetFriendlyMoleName(custom.face.moleId),
						MoleWidth = custom.face.moleLayout.z,
						MoleHeight = custom.face.moleLayout.w,
						MolePositionX = custom.face.moleLayout.x,
						MolePositionY = custom.face.moleLayout.y
					},
					SetBothLeftAndRightEyes = custom.face.pupilSameSetting,
					LeftEyeInfo = custom.face.pupil[0],
					RightEyeInfo = custom.face.pupil[1],
					IrisSettingsStats = new()
					{
						AdjustHeight = custom.face.pupilY,
						ShadowRange = custom.face.whiteShadowScale
					},
					EyeHighlightsStats = new()
					{
						Type = custom.face.hlId,
						Color = custom.face.hlColor,
						Width = custom.face.hlLayout.z,
						Height = custom.face.hlLayout.w,
						PositionX = custom.face.hlLayout.x,
						PositionY = custom.face.hlLayout.y,
						Tilt = custom.face.hlTilt
					},
					EyebrowTypeStats = new()
					{
						Type = custom.face.eyebrowId,
						Color = custom.face.eyebrowColor
					},
					EyelashTypeStats = new()
					{
						Type = custom.face.eyelashesId,
						Color = custom.face.eyelashesColor
					},
					EyeshadowStats = new()
					{
						Type = custom.face.makeup.eyeshadowId,
						Color = custom.face.makeup.eyeshadowColor,
						Shine = custom.face.makeup.eyeshadowGloss,
					},
					BlushStats = new()
					{
						Type = custom.face.makeup.cheekId,
						Color = custom.face.makeup.cheekColor,
						Shine = custom.face.makeup.cheekGloss
					},
					LipstickStats = new()
					{
						Type = custom.face.makeup.lipId,
						Color = custom.face.makeup.lipColor,
						Shine = custom.face.makeup.lipGloss
					},
					Paint1 = custom.face.makeup.paintInfo[0],
					Paint2 = custom.face.makeup.paintInfo[1]
				}
			};
		}
	}
}
