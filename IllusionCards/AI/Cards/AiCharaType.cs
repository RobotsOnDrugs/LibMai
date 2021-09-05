namespace IllusionCards.AI.Chara;

public static class AiCharaType
{
	public const int LoadProductNumber = 100;
	internal static void ParseAiCharaTypeData(BinaryReader binaryReader, string identifier, out Version version, out int language)
	{
		try
		{
			if (binaryReader.ReadInt32() != LoadProductNumber)
				throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character type data");
			string _typeId = ReadString(binaryReader);
			if (_typeId != identifier)
				throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character type data");
			string _version = ReadString(binaryReader);
			version = new(_version);
			language = binaryReader.ReadInt32();
		}
		catch (InternalCardException) { throw; }
		catch (Exception ex) { throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character data", ex); }
	}
}
