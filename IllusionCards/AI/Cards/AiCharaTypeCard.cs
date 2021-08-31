using IllusionCards.Cards;
using IllusionCards.Util;

using static IllusionCards.Cards.IllusionCard;

namespace IllusionCards.AI.Cards
{
	public abstract record AiCharaTypeCard : IllusionCard
	{
		public Version LoadVersion { get; init; }
		public int Language { get; init; }
		public AiCharaTypeCard(CardStructure cs, BinaryReader binaryReader, string identifier) : base(cs, binaryReader)
		{
			ParseAiCharaTypeCard(binaryReader, identifier, out string _version);
			LoadVersion = new(_version);
			Language = binaryReader.ReadInt32();
		}
		private static void ParseAiCharaTypeCard(BinaryReader binaryReader, string identifier, out string version)
		{
			try
			{
				if (binaryReader.ReadInt32() != 100)
					throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character data");
				string _gameId = ReadStringAndReset(binaryReader, noReset: true);
				if (_gameId != identifier)
					throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character data");
				version = ReadStringAndReset(binaryReader, noReset: true);
			}
			catch (InternalCardException) { throw; }
			catch (Exception ex) { throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character data", ex); }
		}
	}
}