
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.Util;

using MessagePack;

using NLog;

namespace IllusionCards.Cards
{
	public readonly struct CardStructure
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		public FileInfo CardFile { get; init; }
		public const long PngStartOffset = 0;
		public long DataStartOffset { get; init; }
		public int? LoadProductNo { get; init; } = null;
		public CardType CardType { get; init; } = CardType.Unknown;
		internal FileStream CardFileStream { get; init; }
		internal BinaryReader CardBinaryReader { get; init; }
		// internal BinaryWriter CardBinaryWriter { get; init; }

		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public readonly struct BlockHeader
		{
			public ImmutableArray<Info> lstInfo { get; init; }

			[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
			public readonly struct Info
			{
				public string name { get; init; }
				public string version { get; init; }
				public long pos { get; init; }
				public long size { get; init; }
			}
		}
		private Version? TrySceneParse()
		{
			// Studio scene files for AI, KK, and PH all start with a version number.
			if (Version.TryParse(CardBinaryReader.ReadString(), out Version? _version))
			{
				int _num = CardBinaryReader.ReadInt32();
				Logger.Debug("{CardName:l} num: {num}", CardFile.Name, _num);
				// TODO: Further parse the card to determine type and set up the objects
				throw new UnsupportedCardException(CardFile.FullName, $"Scene cards are not supported yet.");
				return _version;
			}
			CardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			return null;
		}
		private bool TryPHParse()
		{
			// PH non-scene cards start with the identifier.
			switch (CardBinaryReader.ReadString())
			{
				case Constants.PHFemaleCharaIdentifier:
					throw new UnsupportedCardException(CardFile.FullName, $"PlayHome cards are not supported yet.");
				case Constants.PHFemaleClothesIdentifier:
					throw new UnsupportedCardException(CardFile.FullName, $"PlayHome cards are not supported yet.");
				default:
					break;
			}
			CardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			return false;
		}

		private static CardType? GetCardType(string identifier)
		{
			return identifier switch
			{
				Constants.AICharaIdentifier => CardType.AIChara,
				Constants.AIClothesIdentifier => CardType.AICoordinate,
				Constants.KKCharaIdentifier => CardType.KKChara,
				Constants.KKPartyCharaIdentifier => CardType.KKPartyChara,
				Constants.KKPartySPCharaIdentifier => CardType.KKPartySPChara,
				Constants.ECCharaIdentifier => CardType.ECChara,
				_ => null,
			};
		}
		public void CleanupStreams()
		{
			CardBinaryReader.Close();
			CardFileStream.Close();
		}

		internal CardStructure(string filePath, bool keepStreams = false) : this(new FileInfo(filePath), keepStreams) { }
		internal CardStructure(FileInfo cardFile, bool keepStreams = false)
		{
			CardFile = cardFile;
			CardFileStream = new(CardFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
			CardBinaryReader = new(CardFileStream);
			byte[] _header = CardBinaryReader.ReadBytes(Constants.pngHeader.Length);
			if (!_header.SequenceEqual(Constants.pngHeader)) { throw new InvalidCardException(CardFile.FullName, "No PNG header was found at the beginning of the file."); }
			long _pngEndOffset = Helpers.FindSequence(CardFileStream, Constants.pngFooter) ?? throw new InvalidCardException(CardFile.FullName, "No PNG footer was found.");
			DataStartOffset = _pngEndOffset + Constants.pngFooter.Length;
			if (CardFileStream.Length <= DataStartOffset) { throw new InvalidCardException(CardFile.FullName, "This is a normal PNG file with no extra data."); }
			CardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			Logger.Debug("Data offset for {CardName:l}: {DataStartOffset}", CardFile.Name, DataStartOffset);
			if (TrySceneParse() is not null) { if (!keepStreams) { CleanupStreams(); } return; }
			if (TryPHParse()) { if (!keepStreams) { CleanupStreams(); } return; }
			if (CardBinaryReader.ReadInt32() == 100)
			{
				string _gameId = CardBinaryReader.ReadString();
				CardType = GetCardType(_gameId) ?? throw new InvalidCardException(CardFile.FullName, $"Looks like an AI or KK card, but could not determine card type from this identifier: {_gameId}");
				LoadProductNo = 100;
				if (!keepStreams) { CleanupStreams(); } else { }
				return;
			}
			else
			{
				CleanupStreams();
				throw new InvalidCardException(CardFile.FullName, $"Could not determine card type.");
			}

		}

	}
}
