using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.AI.Cards;
using IllusionCards.AI.ExtendedData.PluginData;
using IllusionCards.Cards;
using IllusionCards.Chara;
using IllusionCards.Util;

using MessagePack;

using static IllusionCards.AI.Chara.FriendlyNameLookup;
using static IllusionCards.Cards.IllusionCard;

namespace IllusionCards.AI.Chara
{
	public readonly struct AiChara : IIllusionChara
	{
		public IIllusionChara.CharaSex Sex
		{
			get => Parameter.sex switch
			{
				0b0 => IIllusionChara.CharaSex.Male,
				0b1 => IIllusionChara.CharaSex.Female,
				_ => IIllusionChara.CharaSex.Unknown
			};
		}
		public string Name { get => Parameter.fullname; }

		public string UserID { get; init; }
		public string DataID { get; init; }

		public AiCustom Custom { get; init; } = new();
		public AiCoordinate Coordinate { get; init; } = new();
		public AiParameter Parameter { get; init; } = new();
		public AiParameter2? Parameter2 { get; init; } = null;
		public AiGameInfo GameInfo { get; init; } = new();
		public AiGameInfo2? GameInfo2 { get; init; } = null;
		public AiStatus Status { get; init; } = new();
		public ImmutableHashSet<AiPluginData>? ExtendedData { get; init; } = null;
		public ImmutableHashSet<NullPluginData>? NullData { get; init; } = null;
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
		private static void CheckInfoVersion(BlockHeader.Info info, Version expectedVersion)
		{
			if (new Version(info.version) > expectedVersion)
				throw new InternalCardException($"{info.name} version {info.version} was greater than the expected version {expectedVersion}");
		}

		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public readonly struct BlockHeader
		{
			public ImmutableArray<Info> lstInfo { get; init; }

			[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
			public readonly struct Info
			{
				public string name { get; init; } = "";
				public string version { get; init; } = "";
				public long pos { get; init; } = 0;
				public long size { get; init; } = 0;
			}
		}
		public AiChara(BinaryReader binaryReader)
		{
			string _userID;
			string _dataID;
			int _count;
			byte[] _bhBytes;
			BlockHeader _blockHeader;
			long _num;
			try
			{
				_userID = ReadStringAndReset(binaryReader, noReset: true);
				_dataID = ReadStringAndReset(binaryReader, noReset: true);
				_count = binaryReader.ReadInt32();
				_bhBytes = binaryReader.ReadBytes(_count);
				_blockHeader = MessagePackSerializer.Deserialize<BlockHeader>(_bhBytes);
				_num = binaryReader.ReadInt64();
			}
			catch (Exception ex)
			{
				throw new InternalCardException("Could not parse character header information", ex);
			}
			UserID = _userID;
			DataID = _dataID;

			long _postNumPosition = binaryReader.BaseStream.Position;
			List<InvalidDataException> _exList = new();
			bool[] _blockHits = new bool[5] { false, false, false, false, false };
			foreach (BlockHeader.Info info in _blockHeader.lstInfo)
			{
				long _infoPos = _postNumPosition + info.pos;
				binaryReader.BaseStream.Seek(_infoPos, SeekOrigin.Begin);
				byte[] _infoData = binaryReader.ReadBytes((int)info.size);
				Version _dataVersion;
				if (info.name != Constants.AiPluginDataBlockName)
					_dataVersion = new(info.version);
				ImmutableHashSet<AiPluginData>.Builder _pluginData = ImmutableHashSet.CreateBuilder<AiPluginData>();
				ImmutableHashSet<NullPluginData>.Builder _nullData = ImmutableHashSet.CreateBuilder<NullPluginData>();
				try
				{
					switch (info.name)
					{
						case Constants.AiCustomBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiCustomVersion);
							Custom = new AiCustom(_infoData);
							_blockHits[0] = true;
							break;
						case Constants.AiCoordinateBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiCoordinateVersion);
							Coordinate = new(_infoData);
							_blockHits[1] = true;
							break;
						case Constants.AiParameterBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiParameterVersion);
							Parameter = MessagePackSerializer.Deserialize<AiParameter>(_infoData);
							_blockHits[2] = true;
							break;
						case Constants.AiParameter2BlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiParameter2Version);
							Parameter2 = MessagePackSerializer.Deserialize<AiParameter2>(_infoData);
							break;
						case Constants.AiGameInfoBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiGameInfoVersion);
							GameInfo = MessagePackSerializer.Deserialize<AiGameInfo>(_infoData);
							_blockHits[3] = true;
							break;
						case Constants.AiGameInfo2BlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiGameInfo2Version);
							GameInfo2 = MessagePackSerializer.Deserialize<AiGameInfo2>(_infoData);
							break;
						case Constants.AiStatusBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiStatusVersion);
							Status = MessagePackSerializer.Deserialize<AiStatus>(_infoData);
							_blockHits[4] = true;
							break;
						case Constants.AiPluginDataBlockName:
							Dictionary<string, AiRawPluginData?> _rawExtendedData = MessagePackSerializer.Deserialize<Dictionary<string, AiRawPluginData?>>(_infoData);
							foreach (var kvp in _rawExtendedData)
							{
								if (kvp.Value is null)
								{
									_nullData.Add(new NullPluginData() { DataKey = kvp.Key });
									continue;
								}
								if (kvp.Value?.data is null)
								{
									_nullData.Add(new NullPluginData() { DataKey = kvp.Key });
									continue;
								}
								AiRawPluginData _rawPluginData = (AiRawPluginData)kvp.Value;
								if (kvp.Value is not null)
								{
									AiPluginData _aiPluginData = new(kvp.Key, _rawPluginData);
									_pluginData.Add(_aiPluginData);
								}
							}
							ExtendedData = _pluginData.ToImmutable();
							NullData = _nullData.ToImmutable();
							break;
						default:
							throw new InternalCardException($"This character has an unknown data section {info.name}");
					}
				}
				catch (InvalidDataException ex) { _exList.Add(ex); }
			}
			if (_exList.Count != 0) throw new AggregateException("Some critical data was missing from this character.", _exList);

			if (!Custom.IsInitialized) throw new InvalidDataException("This character has no Custom data");
			if (!Coordinate.IsInitialized) throw new InvalidDataException("This character has no Coordinate data");
			if (Parameter.version is null) throw new InvalidDataException("This character has no Parameter data");
			if (GameInfo.version is null) throw new InvalidDataException("This character has no GameInfo data");
			if (Status.version is null) throw new InvalidDataException("This character has no Status data");

			for (int i = 0; i < _blockHits.Length; i++)
				if (!_blockHits[i]) throw new InternalCardException($"Failed to detect missing blocks normally. This is a bug. (Missed block at index {i})");
		}
	}
}
