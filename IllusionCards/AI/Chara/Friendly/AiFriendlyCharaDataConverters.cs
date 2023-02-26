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
				Height = custom.face.shapeValueFace[23],
				Spacing = custom.face.shapeValueFace[20],
				Depth = custom.face.shapeValueFace[21],
				Width = custom.face.shapeValueFace[22],
				VerticalPosition = custom.face.shapeValueFace[19],
				AngleZ = custom.face.shapeValueFace[24],
				AngleY = custom.face.shapeValueFace[25],
				OuterHeight = custom.face.shapeValueFace[29],
				OuterWidth = custom.face.shapeValueFace[27],
				InnerHeight = custom.face.shapeValueFace[28],
				InnerWidth = custom.face.shapeValueFace[26],
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
				Height = custom.face.shapeValueFace[47],
				Width = custom.face.shapeValueFace[48],
				LipThickness = custom.face.shapeValueFace[49],
				Depth = custom.face.shapeValueFace[50],
				UpperLipThickness = custom.face.shapeValueFace[51],
				LowerLipThickness = custom.face.shapeValueFace[52],
				CornerShape = custom.face.shapeValueFace[53]
			},
			Ears = new()
			{
				Size = custom.face.shapeValueFace[54],
				Angle = custom.face.shapeValueFace[55],
				Rotation = custom.face.shapeValueFace[56],
				UpperEarShape = custom.face.shapeValueFace[57],
				LowerEarShape = custom.face.shapeValueFace[58]
			},
			Moles = new()
			{
				ID = custom.face.moleId,
				Width = custom.face.moleLayout.Z,
				Height = custom.face.moleLayout.W,
				PositionX = custom.face.moleLayout.X,
				PositionY = custom.face.moleLayout.Y
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
		Raw.Coordinate.ClothesPartsInfo[] _cparts = coordinate.clothes.parts;
		List<Clothing.AiClothingSettingsData> _clothingDatas = new(8);
		if (_cparts.Length != 8) throw new InvalidCardException($"Card has {coordinate.clothes.parts.Length} instead of 8 clothing parts");
		for (int i = 0; i < _cparts.Length; i++)
		{
			var _clothingColorInfosBuilder = ImmutableArray.CreateBuilder<Clothing.AiClothingColorInfo>();
			for (int j = 0; j < _cparts[i].colorInfo.Length; j++)
			{
				_clothingColorInfosBuilder.Add(new()
				{
					Color = _cparts[i].colorInfo[j].baseColor,
					PatternID = _cparts[i].colorInfo[j].pattern,
					PatternName = GetFriendlyClothingPatternByID(_cparts[i].colorInfo[j].pattern),
					PatternColor = _cparts[i].colorInfo[j].patternColor,
					PatternWidth = _cparts[i].colorInfo[j].layout.W,
					PatternHeight = _cparts[i].colorInfo[j].layout.Z,
					PatternPositionX = _cparts[i].colorInfo[j].layout.X,
					PatternPositionY = _cparts[i].colorInfo[j].layout.Y,
					PatternRotation = _cparts[i].colorInfo[j].rotation,
					Shine = _cparts[i].colorInfo[j].glossPower,
					Texture = _cparts[i].colorInfo[j].metallicPower
				});
			}
			_clothingDatas.Add(new()
			{
				ID = _cparts[i].id,
				Name = GetFriendlyFemaleClothingByIndexAndID(i, _cparts[i].id),
				ColorInfos = _clothingColorInfosBuilder.ToImmutable()
			});
		}
		AiClothingData _clothingData = new()
		{
			Top = _clothingDatas[0],
			Bottom = _clothingDatas[1],
			InnerTop = _clothingDatas[2],
			InnerBottom = _clothingDatas[3],
			Gloves = _clothingDatas[4],
			Pantyhose = _clothingDatas[5],
			Socks = _clothingDatas[6],
			Shoes = _clothingDatas[7]
		};

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
	public static AiCharaStatusData GetFriendlyAiCharaStatusData(in AiRawStatusData status) => new()
	{
		Version = status.version,
		Top = (AiCharaStatusData.ClothingState)status.clothesState[0],
		Bottom = (AiCharaStatusData.ClothingState)status.clothesState[0],
		InnerBottom = (AiCharaStatusData.ClothingState)status.clothesState[0],
		InnerTop = (AiCharaStatusData.ClothingState)status.clothesState[0],
		Pantyhose = (AiCharaStatusData.ClothingState)status.clothesState[0],
		Gloves = (AiCharaStatusData.ClothingState)status.clothesState[0],
		Socks = (AiCharaStatusData.ClothingState)status.clothesState[0],
		Shoes = (AiCharaStatusData.ClothingState)status.clothesState[0],
		AccessoryIsVisible = status.showAccessory.ToImmutableArray(),
		EyebrowsExpression = status.eyebrowPtn,
		EyebrowsMaximumOpenAmount = status.eyebrowOpenMax,
		EyesExpression = status.eyesPtn,
		EyesMaximumOpenAmount = status.eyesOpenMax,
		BlinkingEnabled = status.eyesBlink,
		Ahegao = status.eyesYure,
		MouthExpression = status.mouthPtn,
		MouthMinimumOpenAmount = status.mouthOpenMin,
		MouthMaximumOpenAmount = status.mouthOpenMax,
		MouthIsFixed = status.mouthFixed,
		//mouthAdjustWidth = status.mouthAdjustWidth,
		//tongueState = status.tongueState,
		EyesLookPosition = (AiCharaStatusData.EyeLookType)status.eyesLookPtn,
		//eyesTargetType = status.eyesTargetType,
		EyesTargetAngle = status.eyesTargetAngle,
		EyesTargetRange = status.eyesTargetRange,
		EyesTargetRate = status.eyesTargetRate,
		NeckLookPosition = (AiCharaStatusData.NeckLookType)status.neckLookPtn,
		//neckTargetType = status.neckTargetType,
		//neckTargetAngle = status.neckTargetAngle,
		//neckTargetRange = status.neckTargetRange,
		//disableMouthShapeMask = status.disableMouthShapeMask,
		//disableBustShapeMask = status.disableBustShapeMask,
		NippleStiffness = status.nipStandRate,
		SkinGloss = status.skinTuyaRate,
		BlushingAmount = status.hohoAkaRate,
		TearsAmount = status.tearsRate,
		//hideEyesHighlight = status.hideEyesHighlight,
		CumSplatter = new(status.siruLv),
		Wetness = status.wetRate,
		PenisIsVisible = status.visibleSon,
		PenisIsAlwaysVisible = status.visibleSonAlways,
		HeadIsAlwaysVisible = status.visibleHeadAlways,
		BodyIsAlwaysVisible = status.visibleBodyAlways,
		CondomIsVisible = status.visibleGomu,
		MonochromeColor = status.simpleColor,
		//enableShapeHand = status.enableShapeHand.ToImmutableArray(),
		//shapeHandPtn = status.shapeHandPtn,
		shapeHandBlendValue = status.shapeHandBlendValue.ToImmutableArray(),
		AssRednessAmount = status.siriAkaRate
	};
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
	public static AISGameData GetFriendlyAISGameData(in AiRawGameInfoData gameInfo, in HashSet<int> wishes)
	{
		int[] _wishes = new int[3] { -1, -1, -1 };
		int[] _hsWish = wishes.ToArray();
		for (int i = 0; i < wishes.Count; i++)
			_wishes[i] = _hsWish[i];
		Dictionary<AISGameData.FlavorType, int> _flavor = new();
		for (int i = 0; i < 8; i++)
			_flavor.Add((AISGameData.FlavorType)i, gameInfo.flavorState[i]);

		Dictionary<AISGameData.Desires, AISGameData.DesireData> _desire = new();
		for (int j = 0; j < 16; j++)
			_desire.Add((AISGameData.Desires)j, new() { BaseDesire = gameInfo.desireDefVal[j], DesireBuff = gameInfo.desireBuffVal[j] });

		return new()
		{
			Wishes = _wishes.ToImmutableArray(),
			IsRegistered = gameInfo.gameRegistration,
			LowerTempBound = gameInfo.tempBound.lower,
			UpperTempBound = gameInfo.tempBound.upper,
			LowerMoodBound = gameInfo.moodBound.lower,
			UpperMoodBound = gameInfo.moodBound.upper,
			FlavorState = _flavor.ToImmutableDictionary(),
			Desire = _desire.ToImmutableDictionary(),
			Lifestyle = (AISGameData.LifestyleType)gameInfo.lifestyle,
			Hearts = gameInfo.phase
		};
	}
	public static HS2GameData GetFriendlyHS2GameInfoData(in AiRawGameInfo2Data gameInfo2, in AiRawParameter2Data parameter2) => new()
	{
		SexTrait = (HS2GameData.SexTraitType)parameter2.hAttribute,
		Mentality = (HS2GameData.MentalityType)parameter2.mind,
		Trait = (HS2GameData.TraitType)parameter2.trait,
		FavorLevel = gameInfo2.Favor,
		EnjoymentLevel = gameInfo2.Enjoyment,
		AversionLevel = gameInfo2.Aversion,
		SlaveryLevel = gameInfo2.Slavery,
		BrokenLevel = gameInfo2.Broken,
		DependenceLevel = gameInfo2.Dependence,
		StateLocked = gameInfo2.lockNowState,
		BrokenLevelLocked = gameInfo2.lockBroken,
		DependenceLevelLocked = gameInfo2.lockDependence,
		State = (HS2GameData.HS2CharaStatus)gameInfo2.nowState,
		DisplayedState = (HS2GameData.HS2CharaStatus)gameInfo2.calcState,
		DirtyLevel = gameInfo2.Dirty,
		TirednessLevel = gameInfo2.Tiredness,
		ToiletLevel = gameInfo2.Toilet,
		LibidoLevel = gameInfo2.Libido,
		//arriveRoom50 = gameInfo2.arriveRoom50,
		//arriveRoom80 = gameInfo2.arriveRoom80,
		//arriveRoomHAfter = gameInfo2.arriveRoomHAfter,
		SexExperience = gameInfo2.resistH,
		BDSMExperience = gameInfo2.resistPain,
		AnalExperience = gameInfo2.resistAnal,
		ActiveItem = (HS2GameData.SexItemType)gameInfo2.usedItem,
		//isChangeParameter = gameInfo2.isChangeParameter,
		IsConcierge = gameInfo2.isConcierge,
	};

	// Looks like some unfinished business. Set to internal and come back later.
	//internal static AiRawCustomData GetCustomData(in AiFaceData faceData, in AiBodyData bodyData, in AiHairData hairData)
	//{
	//	return new();
	//}
	//internal static AiRawCoordinateData GetCoordinateData(in AiClothingData clothingData, in ImmutableArray<AiAccessoriesData> accessorySettingsDatas)
	//{
	//	return new();
	//}
	//internal static AiRawParameterData GetParameterData(in AiCharaInfoData charaInfoData)
	//{
	//	return new();
	//}
	//internal static (AiRawParameter2Data, AiRawGameInfo2Data) GetRawHS2Data(in HS2GameData gameData)
	//{
	//	return (new(), new());
	//}

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