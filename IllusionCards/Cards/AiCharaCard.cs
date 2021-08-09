using MessagePack;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace IllusionCards.Cards
{
	public class AiCharaCard : IllusionCard
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		private readonly CardStructure CardStructure;

		public int Language;
		public string UserID;
		public string DataID;

		internal static class AiChaFileDefine
		{
			public static readonly Version ChaFileVersion = new Version("1.0.0");
			public static readonly Version ChaFileCustomVersion = new Version("0.0.0");
			public static readonly Version ChaFileFaceVersion = new Version("0.0.2");
			public static readonly Version ChaFileBodyVersion = new Version("0.0.1");
			public static readonly Version ChaFileHairVersion = new Version("0.0.3");
			public static readonly Version ChaFileCoordinateVersion = new Version("0.0.0");
			public static readonly Version ChaFileClothesVersion = new Version("0.0.0");
			public static readonly Version ChaFileAccessoryVersion = new Version("0.0.0");
			public static readonly Version ChaFileParameterVersion = new Version("0.0.1");
			public static readonly Version ChaFileParameterVersion2 = new Version("0.0.0");
			public static readonly Version ChaFileStatusVersion = new Version("0.0.0");
			public static readonly Version ChaFileGameInfoVersion = new Version("0.0.0");
			public static readonly Version ChaFileGameInfoVersion2 = new Version("0.0.0");
		}

		[MessagePackObject(true)]
		public class BlockHeader
		{
			public List<Info> lstInfo { get; set; }
			public BlockHeader()
			{
				lstInfo = new List<Info>();
			}

			[MessagePackObject(true)]
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
		public AiCharaCard(CardStructure cs) : base(cs)
		{
			CardStructure = cs;
			FileStream _cardFileStream = CardStructure.cardFileStream;
			BinaryReader _cardBinaryReader = CardStructure.cardBinaryReader;
			Logger.Debug(_cardFileStream.Position);
			VerifyDataNull(delegate() {
				string _version = _cardBinaryReader.ReadString();
				Version _cardVersion = new Version(_version);
				if (_cardVersion > AiChaFileDefine.ChaFileVersion) {
					throw new UnsupportedCardException(CardStructure.CardFile.FullName, $"Load version {_cardVersion} was greater than the expected version {AiChaFileDefine.ChaFileVersion}"); }
				});
			Language = (int)VerifyData(delegate { return _cardBinaryReader.ReadInt32(); });
			UserID = (string)VerifyData(delegate { return _cardBinaryReader.ReadString(); });
			DataID = (string)VerifyData(delegate { return _cardBinaryReader.ReadString(); });
			int _count = (int)VerifyData(delegate { return _cardBinaryReader.ReadInt32(); });
			byte[] _bhBytes = (byte[])VerifyData(delegate { return _cardBinaryReader.ReadBytes(_count); });
			BlockHeader _blockHeader = MessagePackSerializer.Deserialize<BlockHeader>(_bhBytes);
			long _num = (long)VerifyData(delegate { return _cardBinaryReader.ReadInt64(); });
			long _postNumPosition = _cardFileStream.Position;
			CardStructure.CleanupStreams();
		}
	}
}