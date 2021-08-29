using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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
		private CardType? TrySceneParse()
		{
			// Studio scene files for AI, KK, and PH all start with a version number.
			if (Version.TryParse(CardBinaryReader.ReadString(), out Version? _))
			{
				long? _pos = Helpers.FindSequence(CardFileStream, Constants.MarkerOpener) ?? throw new InvalidCardException(CardFile.FullName, "This card contains no card identifiers.");
				CardFileStream.Seek((long)_pos, SeekOrigin.Begin);
				long? _pos2 = Helpers.FindSequence(CardFileStream, Constants.MarkerCloser) ?? throw new InvalidCardException(CardFile.FullName, "This card contains no card identifiers.");
				while (_pos is not null && _pos2 is not null)
				{
					CardFileStream.Seek((long)_pos, SeekOrigin.Begin);
					byte[] _potentialMarkerBytes = CardBinaryReader.ReadBytes((int)_pos2 - (int)_pos + Constants.MarkerCloser.Length);
					string _potentialMarker = Encoding.UTF8.GetString(_potentialMarkerBytes);
					if (_potentialMarker == Constants.StudioNEOV2Identifier)
						return CardType.AIScene;
					if (_potentialMarker == Constants.PHStudioIdentifier)
						return CardType.PHScene;
					if (_potentialMarker == Constants.KStudioIdentifier)
						return CardType.KKScene;
					_pos = Helpers.FindSequence(CardFileStream, Constants.MarkerOpener);
					if (_pos is null)
						break;
					CardFileStream.Seek((long)_pos, SeekOrigin.Begin);
					_pos2 = Helpers.FindSequence(CardFileStream, Constants.MarkerCloser);
				}
				return CardType.Unknown;
			}
			return null;
		}
		private CardType? TryPHParse()
		{
			// PH non-scene cards start with the identifier.
			switch (CardBinaryReader.ReadString())
			{
				case Constants.PHFemaleCharaIdentifier:
					return CardType.PHFemaleChara;
				case Constants.PHFemaleClothesIdentifier:
					return CardType.PHFemaleClothes;
				case Constants.PHMaleCharaIdentifier:
					return CardType.PHMaleChara;
				default:
					break;
			}
			return null;
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
			CardBinaryReader = new(CardFileStream, Encoding.UTF8);
			byte[] _header = CardBinaryReader.ReadBytes(Constants.pngHeader.Length);
			if (!_header.SequenceEqual(Constants.pngHeader)) { throw new InvalidCardException(CardFile.FullName, "No PNG header was found at the beginning of the file."); }
			long _pngEndOffset = Helpers.FindSequence(CardFileStream, Constants.pngFooter) ?? throw new InvalidCardException(CardFile.FullName, "No PNG footer was found.");
			DataStartOffset = _pngEndOffset + Constants.pngFooter.Length;
			if (CardFileStream.Length <= DataStartOffset) { throw new InvalidCardException(CardFile.FullName, "This is a normal PNG file with no extra data."); }
			CardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			Logger.Debug("Data offset for {CardName:l}: {DataStartOffset}", CardFile.Name, DataStartOffset);
			CardType? _cardType = TrySceneParse();
			CardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			if (_cardType is not null)
			{
				if (_cardType is CardType.Unknown)
					throw new UnsupportedCardException(CardFile.FullName, $"Unknown scene card.");
				CardType = (CardType)_cardType;
				if (!keepStreams) { CleanupStreams(); }
				return;
			}
			_cardType = TryPHParse();
			CardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			if (_cardType is not null)
			{
				CardType = (CardType)_cardType;
				if (!keepStreams) { CleanupStreams(); }
				return;
			}
			CardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			if (CardBinaryReader.ReadInt32() == 100)
			{
				//string _gameId = CardBinaryReader.ReadString(); // ReadString() is prone to overflows in its character buffer :(
				byte[] _idBytes = CardBinaryReader.ReadBytes(CardBinaryReader.Read7BitEncodedInt());
				string _gameId = Encoding.UTF8.GetString(_idBytes);
				CardType = GetCardType(_gameId) ?? throw new InvalidCardException(CardFile.FullName, $"Looks like an AI or KK card, but could not determine card type from this identifier: {_gameId}");
				LoadProductNo = 100;
				if (!keepStreams) { CleanupStreams(); }
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
