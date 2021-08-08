using System;
using System.Linq;
using System.IO;

using NLog;

using IllusionCards.Cards;
using IllusionCards.Util;
using static IllusionCards.Constants;

namespace IllusionCards
{
	public class UnsupportedCardException : Exception
	{
		public string CardPath;
		public UnsupportedCardException(string cardPath, string message) : base(message)
		{
			CardPath = cardPath;
		}
	}
	public class InvalidCardException : UnsupportedCardException
	{
		public InvalidCardException(string cardPath, string message) : base(cardPath, message)
		{
		}
	}
	public class CardStructure
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


		public FileInfo CardFile;

		public const long PngStartOffset = 0;
		public long DataStartOffset;

		public int LoadProductNo;
		public CardType CardType;
		public Version Version;

		private FileStream cardFileStream;
		private BinaryReader cardBinaryReader;
		// private BinaryWriter _cardBinaryWriter;

		private bool TrySceneParse()
		{
			// Studio scene files for AI, KK, and PH all start with a version number.
			if (Version.TryParse(cardBinaryReader.ReadString(), out Version? _version))
			{
				Version = _version;
				int _num = cardBinaryReader.ReadInt32();
				Logger.Debug("{CardName:l} num: {num}", CardFile.Name, _num);
				// TODO: Further parse the card to determine type and set up the objects
				throw new UnsupportedCardException(CardFile.FullName, $"Scene cards are not supported yet.");
				//return true;
			}
			cardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			return false;
		}
		private bool TryPHParse()
		{
			// PH non-scene cards start with the identifier.
			switch (cardBinaryReader.ReadString())
			{
				case Constants.PHFemaleCharaIdentifier:
					throw new UnsupportedCardException(CardFile.FullName, $"PlayHome cards are not supported yet.");
				case Constants.PHFemaleClothesIdentifier:
					throw new UnsupportedCardException(CardFile.FullName, $"PlayHome cards are not supported yet.");
				default:
					break;
			}
			cardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			return false;
		}
		private bool TryAIKKParse()
		{
			// AI and KK chara and clothes cards begin with a product number (which is always 100 apparently), followed by the identifier.
			if ((LoadProductNo = cardBinaryReader.ReadInt32()) == 100)
			{
				string _gameId = cardBinaryReader.ReadString();
				CardType = GetCardType(_gameId) ?? throw new InvalidCardException(CardFile.FullName, $"Looks like an AI or KK card, but could not determine card type from this identifier: {_gameId}");
				Version = new Version(cardBinaryReader.ReadString());
				Logger.Info("Card type for {CardName:l}: {CardType}", CardFile.Name, CardType);
				return true;
			}
			cardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			return false;
		}
		private void ParseCard()
		{
			
		}

		private static CardType? GetCardType(string identifier)
		{
			return identifier switch
			{
				AICharaIdentifier => CardType.AIChara,
				AIClothesIdentifier => CardType.AICoordinate,
				KKCharaIdentifier => CardType.KKChara,
				KKPartyCharaIdentifier => CardType.KKPartyChara,
				KKPartySPCharaIdentifier => CardType.KKPartySPChara,
				ECCharaIdentifier => CardType.ECChara,
				_ => null,
			};
		}

		internal CardStructure(string filePath) : this(new FileInfo(filePath)) {}
		internal CardStructure(FileInfo cardFile)
		{
			CardFile = cardFile;
			using FileStream _cardFileStream = new(CardFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
			using BinaryReader _cardBinaryReader = new(_cardFileStream);
			cardFileStream = _cardFileStream;
			cardBinaryReader = _cardBinaryReader;
			byte[] _header = cardBinaryReader.ReadBytes(Constants.pngHeader.Length);
			if (!_header.SequenceEqual(Constants.pngHeader)) { throw new InvalidCardException(CardFile.FullName, "No PNG header was found at the beginning of the file."); }
			long _pngEndOffset = Helpers.FindSequence(cardFileStream, Constants.pngFooter) ?? throw new InvalidCardException(CardFile.FullName, "No PNG footer was found.");
			DataStartOffset = _pngEndOffset + Constants.pngFooter.Length;
			cardFileStream.Seek(DataStartOffset, SeekOrigin.Begin);
			Logger.Debug("Data offset for {CardName:l}: {DataStartOffset}", CardFile.Name, DataStartOffset);
			if (TrySceneParse()) { return; }
			if (TryPHParse()) { return; }
			if (TryAIKKParse()) { return; }
			else { throw new InvalidCardException(CardFile.FullName, $"Could not determine card type."); }
		}

	}
}
