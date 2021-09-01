using IllusionCards.Cards;

namespace IllusionCards.AI.Cards
{
	public abstract record AiCharaTypeCard : IllusionCard
	{
		public const int LoadProductNumber = 100;
		public Version LoadVersion { get; init; }
		public int Language { get; init; }
		public AiCharaTypeCard(CardStructure cs, BinaryReader binaryReader, string identifier) : base(cs, binaryReader)
		{
			ParseAiCharaTypeCard(binaryReader, identifier, out Version _version, out int _language);
			LoadVersion = _version;
			Language = _language;
		}
		private static void ParseAiCharaTypeCard(BinaryReader binaryReader, string identifier, out Version version, out int language)
		{
			try
			{
				if (binaryReader.ReadInt32() != LoadProductNumber)
					throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character type data");
				string _typeId = ReadStringAndReset(binaryReader, noReset: true);
				if (_typeId != identifier)
					throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character type data");
				string _version = ReadStringAndReset(binaryReader, noReset: true);
				version = new(_version);
				language = binaryReader.ReadInt32();
			}
			catch (InternalCardException) { throw; }
			catch (Exception ex) { throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character data", ex); }
		}
	}
}