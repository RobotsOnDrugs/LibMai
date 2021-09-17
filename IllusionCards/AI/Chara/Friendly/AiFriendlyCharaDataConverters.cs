namespace IllusionCards.AI.Chara.Friendly;

public static class AiFriendlyCharaDataConverters
{
	public static (AiFaceData, AiBodyData, AiHairData) GetAllFriendlyBodyData(in AiRawCustomData custom)
	{
		AiFaceData faceData = new()
		{
			FaceType = new()
			{
				Contour = GetFriendlyFemaleFaceContourName(custom.face.headId),
				Skin = GetFriendlyFemaleFaceSkinName(custom.face.skinId),
				Wrinkles = GetFriendlyFemaleFaceWrinklesName(custom.face.detailId),
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
			LeftEye = ConvertEyeInfo(custom.face.pupil[0]),
			RightEye_ = custom.face.pupilSameSetting ? null : ConvertEyeInfo(custom.face.pupil[1]),
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
			Paint1 = ConvertPaintInfo(custom.face.makeup.paintInfo[0]),
			Paint2 = ConvertPaintInfo(custom.face.makeup.paintInfo[1])
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
	public static (AiClothingData, AiAccessoriesData) GetAllFriendlyCoordinateData(in AiRawCoordinateData coordinate)
	{
		AiClothingData _clothingData = new() { };
		var _accessoryDatasBuilder = ImmutableArray.CreateBuilder<AiAccessoryData>();
		foreach (Raw.Coordinate.AccessoryPartsInfo part in coordinate.accessory.parts)
		{
			var _accessoryAdjustmentDatasBuilder = ImmutableArray.CreateBuilder<AiAccessoryAdjustmentData>();
			for (int i = 0; i < part.addMove.Rank; i++)
				_accessoryAdjustmentDatasBuilder.Add(new()
				{
					Position = part.addMove[i, 0],
					Rotation = part.addMove[i, 1],
					Scale = part.addMove[i, 2]
				});
			var _accessoryColorinfosBuilder = ImmutableArray.CreateBuilder<AiAccessoryColorInfo>();
			for (int j = 0; j < part.colorInfo.Length; j++)
				_accessoryColorinfosBuilder.Add(new()
				{
					Color = part.colorInfo[j].color,
					Shine = part.colorInfo[j].glossPower,
					Smoothness = part.colorInfo[j].smoothnessPower,
					Texture = part.colorInfo[j].metallicPower
				});

			AiAccessoryData _accessoryData = new()
			{
				AccessoryType = (AiAccessoryType)part.type,
				ID = part.id,
				Name = GetFriendlyNameByCategoryID(part.type, part.id),
				Parent = GetFriendlyAccessoryParent(part.parentKey),
				Adjustments = _accessoryAdjustmentDatasBuilder.ToImmutable(),
				ColorInfos = _accessoryColorinfosBuilder.ToImmutable(),
				hideCategory = part.hideCategory,
				hideTiming = part.hideTiming,
				IsRigid = part.noShake
			};
			_accessoryDatasBuilder.Add(_accessoryData);
		}
		AiAccessoriesData _accessorySettingsData = new()
		{
			Version = coordinate.accessory.version,
			Accessories = _accessoryDatasBuilder.ToImmutable()
		};
		return (_clothingData, _accessorySettingsData);
	}
	public static AiCharaStatusData GetFriendlyAiCharaStatusData(in AiRawStatusData status)
	{
		return new();
	}
	public static AiCharaInfoData GetFriendlyCharaInfoData(in AiRawParameterData parameter) => new()
	{
		Sex = (CharaSex)parameter.sex,
		Name = parameter.fullname,
		Personality = (AiCharaInfoData.PersonalityType)parameter.personality,
		BirthMonth = parameter.birthMonth,
		BirthDay = parameter.birthDay,
		VoiceRate = parameter.voiceRate,
		IsFuta = parameter.futanari
	};
	public static AISGameData GetFriendlyAISGameData(in AiRawGameInfoData gameInfo)
	{
		return new();
	}
	public static HS2GameData? GetFriendlyHS2GameInfoData(in AiRawGameInfo2Data gameInfo2, in AiRawParameter2Data parameter2)
	{
		return new();
	}

	public static AiRawCustomData GetCustomData(in AiFaceData faceData, in AiBodyData bodyData, in AiHairData hairData)
	{
		return new();
	}
	public static AiRawCoordinateData GetCoordinateData(in AiClothingData clothingData, in ImmutableArray<AiAccessoriesData> accessorySettingsDatas)
	{
		return new();
	}
	public static AiRawParameterData GetParameterData(in AiCharaInfoData charaInfoData)
	{
		return new();
	}
	public static (AiRawParameter2Data, AiRawGameInfo2Data) GetRawHS2Data(in HS2GameData gameData)
	{
		return (new(), new());
	}

	private static Face.EyeInfo ConvertEyeInfo(in Raw.Custom.AiRawFaceData.EyesInfo rawEyeInfo) => new()
	{
		ScleraColor = rawEyeInfo.whiteColor,
		_Iris = rawEyeInfo.pupilId,
		IrisColor = rawEyeInfo.pupilColor,
		IrisWidth = rawEyeInfo.pupilW,
		IrisHeight = rawEyeInfo.pupilH,
		IrisGlow = rawEyeInfo.pupilEmission,
		_Pupil = rawEyeInfo.blackId,
		PupilColor = rawEyeInfo.blackColor,
		PupilWidth = rawEyeInfo.blackW,
		PupilHeight = rawEyeInfo.blackH,
	};
	private static AiPaintInfo ConvertPaintInfo(in Raw.Custom.AiRawPaintInfo rawPaintInfo) => new()
	{
		id = rawPaintInfo.id,
		Color = rawPaintInfo.color,
		Shine = rawPaintInfo.glossPower,
		Texture = rawPaintInfo.metallicPower,
		layoutId = rawPaintInfo.layoutId,
		Position = rawPaintInfo.layout,
		Rotation = rawPaintInfo.rotation
	};
}