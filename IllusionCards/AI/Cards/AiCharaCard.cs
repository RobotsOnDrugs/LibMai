using System.Collections.Immutable;

using IllusionCards.AI.Chara;
using IllusionCards.AI.ExtendedData.PluginData;
using IllusionCards.Cards;
using IllusionCards.Util;

using MessagePack;

using NLog;

using static IllusionCards.Cards.CardStructure;

namespace IllusionCards.AI.Cards
{
	public record AiCharaCard : IllusionCard
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public int Language { get; init; }
		public string UserID { get; init; }
		public string DataID { get; init; }
		public AiChara Chara { get; init; }
		public ImmutableArray<byte> PngData { get; init; }


		private AiCustom Custom { get; init; }
		private AiCoordinate Coordinate { get; init; }
		private AiParameter Parameter { get; init; }
		private AiParameter2? Parameter2 { get; init; }
		private AiGameInfo GameInfo { get; init; }
		private AiGameInfo2? GameInfo2 { get; init; }
		private AiStatus Status { get; init; }
		private ImmutableHashSet<AiPluginData>? ExtendedData { get; init; } = null;
		private ImmutableHashSet<NullPluginData>? NullData { get; init; } = null;

		private Object VerifyData(Func<Object> func)
		{
			try { return func(); }
			catch (Exception ex)
			{
				CardStructure.CleanupStreams();
				if (ex is IOException || ex is UnsupportedCardException) { throw; }
				throw new InvalidCardException(CardStructure.CardFile.FullName, ex.Message);
			}

		}
		private void VerifyDataNull(Action action)
		{
			try { action(); }
			catch (Exception ex)
			{
				CardStructure.CleanupStreams();
				if (ex is IOException || ex is UnsupportedCardException) { throw; }
				throw new InvalidCardException(CardStructure.CardFile.FullName, ex.Message);
			}
		}
		private static void CheckInfoVersion(BlockHeader.Info info, Version expectedVersion, string cardPath)
		{
			if (new Version(info.version) > expectedVersion)
				throw new UnsupportedCardException(cardPath, $"{info.name} version {info.version} was greater than the expected version {expectedVersion}");
		}

		public AiCharaCard(CardStructure cs) : base(cs)
		{
			CardStructure = cs;
			string _cardPath = CardStructure.CardFile.FullName;
			FileStream _cardFileStream = CardStructure.CardFileStream;
			BinaryReader _cardBinaryReader = CardStructure.CardBinaryReader;
			long _curPos = _cardFileStream.Position;
			Logger.Debug(_cardFileStream.Position);
			_cardFileStream.Seek(0, SeekOrigin.Begin);
			PngData = ImmutableArray.Create<byte>(_cardBinaryReader.ReadBytes((int)CardStructure.DataStartOffset));
			_cardFileStream.Seek(_curPos, SeekOrigin.Begin);
			VerifyDataNull(delegate ()
			{
				string _version = _cardBinaryReader.ReadString();
				Version _cardVersion = new(_version);
				if (_cardVersion > AiCharaCardDefinitions.AiChaVersion)
					throw new UnsupportedCardException(_cardPath, $"Load version {_cardVersion} was greater than the expected version {AiCharaCardDefinitions.AiChaVersion}");
			});
			Language = (int)VerifyData(delegate { return _cardBinaryReader.ReadInt32(); });
			UserID = (string)VerifyData(delegate { return _cardBinaryReader.ReadString(); });
			DataID = (string)VerifyData(delegate { return _cardBinaryReader.ReadString(); });
			int _count = (int)VerifyData(delegate { return _cardBinaryReader.ReadInt32(); });
			byte[] _bhBytes = (byte[])VerifyData(delegate { return _cardBinaryReader.ReadBytes(_count); });
			BlockHeader _blockHeader = MessagePackSerializer.Deserialize<BlockHeader>(_bhBytes);
			long _num = (long)VerifyData(delegate { return _cardBinaryReader.ReadInt64(); });
			long _postNumPosition = _cardFileStream.Position;
			List<InternalCardException> _exList = new();
			foreach (BlockHeader.Info info in _blockHeader.lstInfo)
			{
				long _infoPos = _postNumPosition + info.pos;
				_cardFileStream.Seek(_infoPos, SeekOrigin.Begin);
				byte[] _infoData = _cardBinaryReader.ReadBytes((int)info.size);
				Version _version;
				if (info.name != Constants.AiPluginDataBlockName)
					_version = new(info.version);
				ImmutableHashSet<AiPluginData>.Builder _pluginData = ImmutableHashSet.CreateBuilder<AiPluginData>();
				ImmutableHashSet<NullPluginData>.Builder _nullData = ImmutableHashSet.CreateBuilder<NullPluginData>();
				try
				{
					switch (info.name)
					{
						case Constants.AiCustomBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiCustomVersion, _cardPath);
							Custom = new(_infoData);
							if (!Custom.IsInitialized)
								throw new InternalCardException("No Custom data was found on this card");
							break;
						case Constants.AiCoordinateBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiCoordinateVersion, _cardPath);
							Coordinate = new(_infoData);
							if (!Coordinate.IsInitialized)
								throw new InternalCardException("No Coordinate data was found on this card");
							break;
						case Constants.AiParameterBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiParameterVersion, _cardPath);
							Parameter = MessagePackSerializer.Deserialize<AiParameter>(_infoData);
							if (Parameter.version is null)
								throw new InternalCardException("No Parameter data was found on this card");
							break;
						case Constants.AiParameter2BlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiParameter2Version, _cardPath);
							Parameter2 = MessagePackSerializer.Deserialize<AiParameter2>(_infoData);
							break;
						case Constants.AiGameInfoBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiGameInfoVersion, _cardPath);
							GameInfo = MessagePackSerializer.Deserialize<AiGameInfo>(_infoData);
							if (GameInfo.version is null)
								throw new InternalCardException("No GameInfo data was found on this card");
							break;
						case Constants.AiGameInfo2BlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiGameInfo2Version, _cardPath);
							GameInfo2 = MessagePackSerializer.Deserialize<AiGameInfo2>(_infoData);
							break;
						case Constants.AiStatusBlockName:
							CheckInfoVersion(info, AiCharaCardDefinitions.AiStatusVersion, _cardPath);
							Status = MessagePackSerializer.Deserialize<AiStatus>(_infoData);
							if (Status.version is null)
								throw new InternalCardException("No Status data was found on this card");
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
							throw new UnsupportedCardException(_cardPath, $"This card has an unknown data section {info.name}");
					}
				}
				catch (InternalCardException ex)
				{
					_exList.Add(ex);
					try
					{
						if (_exList.Count != 0)
							throw new AggregateException("Some critical data was missing from this card.", _exList);
					}
					catch (AggregateException aex) { throw new UnsupportedCardException(CardStructure.CardFile.FullName, aex.Message); }
				}
			}
			//Chara = new(Custom, Coordinate, Parameter, Parameter2, GameInfo, GameInfo2, Status, ExtendedData, NullData);
			Chara = new()
			{
				Custom = Custom,
				Coordinate = Coordinate,
				Parameter = Parameter,
				Parameter2 = Parameter2,
				GameInfo = GameInfo,
				GameInfo2 = GameInfo2,
				Status = Status,
				ExtendedData = ExtendedData,
				NullData = NullData
			};
			CardStructure.CleanupStreams();
		}
	}
}