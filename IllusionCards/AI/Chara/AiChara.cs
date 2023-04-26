//using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("MessagePack"), InternalsVisibleTo("CardManagerCLI")]
namespace IllusionCards.AI.Chara;

[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Names match AI/HS2 naming.")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public readonly record struct AiChara : IIllusionChara
{
	//public static AiChara Tsubomi { get; }
	//public static AiChara Hero { get; }
	//public static AiChara HatanoMiwa { get; }
	//public static AiRawParameter2Data HS2NewChara { get; }
	//public static AiRawGameInfo2Data HS2NewGameData { get; }

	//internal AiChara DefaultChara => Sex is CharaSex.Male ? Hero : Tsubomi;

	public CharaSex Sex => CharaInfo.Sex;
	public string Name => CharaInfo.Name;

	public Version LoadVersion { get; }
	public int Language { get; }
	public string UserID { get; init; }
	public string DataID { get; init; }
	internal AiRawCustomData Custom { get; }
	internal AiRawCoordinateData Coordinate { get; }
	internal AiRawParameterData Parameter { get; }
	internal AiRawParameter2Data? Parameter2 { get; } = null; // = HS2NewChara;
	internal AiRawGameInfoData GameInfo { get; }
	internal AiRawGameInfo2Data? GameInfo2 { get; } = null; // = HS2NewGameData;
	internal AiRawStatusData Status { get; init; }

	public AiFaceData Face { get; init; }
	public AiBodyData Body { get; init; }
	public AiHairData Hair { get; init; }
	public AiClothingData Clothing { get; init; }
	public AiAccessoriesData Accessories { get; init; }
	public AiCharaInfoData CharaInfo { get; }
	public AiGameData AiGameInfo { get; init; }
	public HS2GameData? HS2GameInfo { get; init; }
	public ImmutableHashSet<AiPluginData>? ExtendedData { get; init; } = null;
	public ImmutableHashSet<NullPluginData>? NullData { get; init; } = null;

	private static void CheckInfoVersion(in BlockHeader.Info info, Version expectedVersion)
	{
		if (new Version(info.version) > expectedVersion)
			throw new InternalCardException($"{info.name} version {info.version} was greater than the expected version {expectedVersion}");
	}

	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly record struct BlockHeader
	{
		// ReSharper disable once UnassignedGetOnlyAutoProperty
		// ReSharper disable once CollectionNeverUpdated.Global
		// lstInfo is populated via MessagePack
		public ImmutableArray<Info> lstInfo { get; init; }

		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public readonly record struct Info
		{
			public Info() { }

			public string name { get; init; } = "";
			public string version { get; init; } = "";
			public long pos { get; init; } = 0;
			public long size { get; init; } = 0;
		}
	}
	
	// I try to break up methods and keep them simpler and easier to follow, but a character object is quite complex.
	// There's also a mashup of metadata assigned to local variables that are used both inside and outside the nested switch cases that I can't quite straighten out.
	// See also issue #5.
	internal AiChara(BinaryReader binary_reader, out long data_end_position)
	{
		LoadVersion = ParseAiCharaTypeVersion(binary_reader, IllusionConstants.AICharaIdentifier);
		Language = binary_reader.ReadInt32();
		
		BlockHeader block_header;
		try
		{
			UserID = ReadString(binary_reader);
			DataID = ReadString(binary_reader);
			int _count = binary_reader.ReadInt32();
			byte[] _bhBytes = binary_reader.ReadBytes(_count);
			block_header = MessagePackSerializer.Deserialize<BlockHeader>(_bhBytes);
			data_end_position = binary_reader.ReadInt64();
		}
		catch (Exception ex) { throw new InternalCardException("Could not parse character header information", ex); }

		AiRawCustomData? _custom = null;
		AiRawCoordinateData? _coordinate = null;
		AiRawParameterData? _parameter = null;
		AiRawParameter2Data? _parameter2 = null;
		AiRawGameInfoData? _gameInfo = null;
		AiRawGameInfo2Data? _gameInfo2 = null;
		AiRawStatusData? _status = null;

		long header_end_position = binary_reader.BaseStream.Position;
		foreach (BlockHeader.Info block_info in block_header.lstInfo)
		{
			long block_position = header_end_position + block_info.pos;
			_ = binary_reader.BaseStream.Seek(block_position, SeekOrigin.Begin);
			byte[] block_data = binary_reader.ReadBytes((int)block_info.size);
			ImmutableHashSet<AiPluginData>.Builder _pluginData = ImmutableHashSet.CreateBuilder<AiPluginData>();
			ImmutableHashSet<NullPluginData>.Builder _nullData = ImmutableHashSet.CreateBuilder<NullPluginData>();
			switch (block_info.name)
			{
				case IllusionConstants.AiCustomBlockName:
					CheckInfoVersion(block_info, AiCustomVersion);
					_custom = new(block_data);
					break;
				case IllusionConstants.AiCoordinateBlockName:
					CheckInfoVersion(block_info, AiCoordinateVersion);
					_coordinate = new(block_data, LoadVersion, Language);
					break;
				case IllusionConstants.AiParameterBlockName:
					CheckInfoVersion(block_info, AiParameterVersion);
					_parameter = MessagePackSerializer.Deserialize<AiRawParameterData>(block_data);
					break;
				case IllusionConstants.AiParameter2BlockName:
					CheckInfoVersion(block_info, AiParameter2Version);
					_parameter2 = MessagePackSerializer.Deserialize<AiRawParameter2Data>(block_data);
					break;
				case IllusionConstants.AiGameInfoBlockName:
					CheckInfoVersion(block_info, AiGameInfoVersion);
					_gameInfo = MessagePackSerializer.Deserialize<AiRawGameInfoData>(block_data);
					break;
				case IllusionConstants.AiGameInfo2BlockName:
					CheckInfoVersion(block_info, AiGameInfo2Version);
					_gameInfo2 = MessagePackSerializer.Deserialize<AiRawGameInfo2Data>(block_data);
					break;
				case IllusionConstants.AiStatusBlockName:
					CheckInfoVersion(block_info, AiStatusVersion);
					_status = MessagePackSerializer.Deserialize<AiRawStatusData>(block_data);
					break;
				case IllusionConstants.AiPluginDataBlockName:
					Dictionary<string, AiRawPluginData?> _rawExtendedData = MessagePackSerializer.Deserialize<Dictionary<string, AiRawPluginData?>>(block_data);
					foreach (KeyValuePair<string, AiRawPluginData?> plugin_kvp in _rawExtendedData)
					{
						if (plugin_kvp.Value is null) continue;
						if (plugin_kvp.Value?.data is null)
						{
							_ = _nullData.Add(new() { DataKey = plugin_kvp.Key });
							continue;
						}
						AiRawPluginData _rawPluginData = (AiRawPluginData)plugin_kvp.Value;
						AiPluginData _aiPluginData = AiPluginData.GetExtendedPluginData(plugin_kvp.Key, _rawPluginData);
						_ = _pluginData.Add(_aiPluginData);
					}
					ExtendedData = _pluginData.ToImmutable();
					NullData = _nullData.ToImmutable();
					break;
				default:
					throw new InternalCardException($"This character has an unknown data section {block_info.name}");
			}
		}
		_ = binary_reader.BaseStream.Seek(data_end_position, SeekOrigin.Begin);

		Custom = _custom?.IsInitialized ?? false ? (AiRawCustomData)_custom : throw new InvalidDataException("This character has no Custom data");
		Coordinate = _coordinate?.IsInitialized ?? false ? (AiRawCoordinateData)_coordinate : throw new InvalidDataException("This character has no Coordinate data");
		Parameter = _parameter?.version is not null ? (AiRawParameterData)_parameter : throw new InvalidDataException("This character has no Parameter data");
		GameInfo = _gameInfo?.version is not null ? (AiRawGameInfoData)_gameInfo : throw new InvalidDataException("This character has no GameInfo data");
		Status = _status?.version is not null ? (AiRawStatusData)_status : throw new InvalidDataException("This character has no Status data");
		if (_parameter2?.version is not null) Parameter2 = (AiRawParameter2Data)_parameter2;
		GameInfo2 = _gameInfo2;

		(Face, Body, Hair) = GetAllFriendlyBodyData(Custom);
		(Clothing, Accessories) = GetAllFriendlyCoordinateData(Coordinate);
		CharaInfo = GetFriendlyCharaInfoData(Parameter);
		AiGameInfo = GetFriendlyAiGameData(GameInfo, Parameter.hsWish);
		HS2GameInfo = GameInfo2 is not null && Parameter2 is not null ?
			GetFriendlyHs2GameInfoData((AiRawGameInfo2Data)GameInfo2, (AiRawParameter2Data)Parameter2) :
			null;
	}
}
