namespace IllusionCards.AI.Chara;

public static class AiCharaType
{
	public const int LoadProductNumber = 100;
	internal static Version ParseAiCharaTypeVersion(BinaryReader binaryReader, in string identifier)
	{
		try
		{
			if (binaryReader.ReadInt32() != LoadProductNumber)
				throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character type data");
			string type_id = ReadString(binaryReader);
			if (type_id != identifier)
				throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character type data");
			string version = ReadString(binaryReader);
			return new(version);
		}
		catch (InternalCardException) { throw; }
		catch (Exception ex) { throw new InternalCardException($"Wrong card type or stream position {binaryReader.BaseStream.Position} for AI character data", ex); }
	}
}
