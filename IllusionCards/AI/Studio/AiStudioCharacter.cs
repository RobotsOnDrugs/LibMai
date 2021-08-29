using static IllusionCards.Chara.IIllusionChara;

namespace IllusionCards.AI.Studio
{
	public record AiStudioCharacter : AiStudioObject
	{
		public CharaSex Sex { get; init; }
		public AiStudioCharacter(BinaryReader binaryReader) : base(binaryReader)
		{
			Sex = (CharaSex)binaryReader.ReadInt32();

		}
	}
}
