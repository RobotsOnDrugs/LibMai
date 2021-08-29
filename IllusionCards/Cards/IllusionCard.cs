
using System.Collections.Immutable;

using IllusionCards.Util;

using NLog;

namespace IllusionCards.Cards
{
	public abstract record IllusionCard
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		public CardStructure CardStructure { get; init; }
		public ImmutableArray<byte> PngData { get; init; }

		internal FileStream CardFileStream { get; init; }
		internal BinaryReader CardBinaryReader { get; init; }
		internal string CardPath { get; init; }
		internal long CurPos { get; init; }

		internal IllusionCard(CardStructure cs)
		{
			CardStructure = cs;
			CardPath = CardStructure.CardFile.FullName;
			CardFileStream = CardStructure.CardFileStream;
			CardBinaryReader = CardStructure.CardBinaryReader;
			CurPos = CardFileStream.Position;
			Logger.Debug(CardFileStream.Position);
			CardFileStream.Seek(0, SeekOrigin.Begin);
			PngData = ImmutableArray.Create<byte>(CardBinaryReader.ReadBytes((int)CardStructure.DataStartOffset));
			CardFileStream.Seek(CurPos, SeekOrigin.Begin);
		}

		public class WrongCardTypeException : InvalidOperationException { }

		public static IllusionCard NewCard(CardStructure cs)
		{
			string _friendlyName = Constants.CardTypeNames[cs.CardType];
			return cs.CardType switch
			{
				CardType.AIChara => new AI.Cards.AiCharaCard(cs),
				CardType.AICoordinate => new AI.Cards.AiCoordinateCard(cs),
				CardType.AIScene => new AI.Cards.AiSceneCard(cs),
				CardType.KKChara => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.KKPartyChara => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.KKPartySPChara => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.KKScene => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.PHFemaleChara => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.PHFemaleClothes => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.PHMaleChara => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.PHScene => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				CardType.ECChara => throw new UnsupportedCardException(cs.CardFile.FullName, $"{_friendlyName} cards are currently not supported."),
				_ => throw new Exception($"How did we end up here? ({cs.CardType})"),
			};
		}
	}
}
