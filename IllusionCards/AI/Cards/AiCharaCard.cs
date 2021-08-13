using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

using IllusionCards.AI.Chara;
using IllusionCards.Cards;

using MessagePack;

using NLog;

namespace IllusionCards.AI.Cards
{
	public class AiCharaCard : IllusionCard
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public int Language;
		public string UserID;
		public string DataID;

		public AiCustom Custom = null!;
		public AiCoordinate Coordinate = null!;

		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public class BlockHeader
		{
			public List<Info> lstInfo { get; set; }
			public BlockHeader()
			{
				lstInfo = new List<Info>();
			}

			[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
			public class Info
			{
				public string name { get; set; }
				public string version { get; set; }
				public long pos { get; set; }
				public long size { get; set; }
				public Info()
				{
					name = "";
					version = "";
					pos = 0L;
					size = 0L;
				}
			}
		}

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
			FileStream _cardFileStream = CardStructure.cardFileStream;
			BinaryReader _cardBinaryReader = CardStructure.cardBinaryReader;
			Logger.Debug(_cardFileStream.Position);
			VerifyDataNull(delegate ()
			{
				string _version = _cardBinaryReader.ReadString();
				Version _cardVersion = new(_version);
				if (_cardVersion > AiCharaCardDefinitions.AiChaVersion)
				{
					throw new UnsupportedCardException(_cardPath, $"Load version {_cardVersion} was greater than the expected version {AiCharaCardDefinitions.AiChaVersion}");
				}
			});
			Language = (int)VerifyData(delegate { return _cardBinaryReader.ReadInt32(); });
			UserID = (string)VerifyData(delegate { return _cardBinaryReader.ReadString(); });
			DataID = (string)VerifyData(delegate { return _cardBinaryReader.ReadString(); });
			int _count = (int)VerifyData(delegate { return _cardBinaryReader.ReadInt32(); });
			byte[] _bhBytes = (byte[])VerifyData(delegate { return _cardBinaryReader.ReadBytes(_count); });
			BlockHeader _blockHeader = MessagePackSerializer.Deserialize<BlockHeader>(_bhBytes);
			long _num = (long)VerifyData(delegate { return _cardBinaryReader.ReadInt64(); });
			long _postNumPosition = _cardFileStream.Position;
			foreach (BlockHeader.Info info in _blockHeader.lstInfo)
			{
				long _infoPos = _postNumPosition + info.pos;
				_cardFileStream.Seek(_infoPos, SeekOrigin.Begin);
				byte[] _infoData = _cardBinaryReader.ReadBytes((int)info.size);
				Version _version = new(info.version);
				switch (info.name)
				{
					case AiCustom.BlockName:
						CheckInfoVersion(info, AiCharaCardDefinitions.AiCustomVersion, _cardPath);
						Custom = new(_infoData);
						break;
					case AiCoordinate.BlockName:
						break;
					//case AiParameter.BlockName:
					//	break;
					//case AiParameter2.BlockName:
					//	break;
					//case AiGameInfo.BlockName:
					//	break;
					//case AiGameInfo2.BlockName:
					//	break;
					//case AiStatus.BlockName:
					//	break;
					default:
						break;
				}
			}
			CardStructure.CleanupStreams();
		}
	}
}