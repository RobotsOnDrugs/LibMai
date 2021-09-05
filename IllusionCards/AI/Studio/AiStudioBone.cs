namespace IllusionCards.AI.Studio;

public record AiStudioBone : AiStudioObject
{
	public override int Kind => -1;
	public BoneGroup Group { get; init; } = BoneGroup.None;
	public int Level { get; init; } = 0;
	public AiStudioBone(BinaryReader binaryReader) : base(binaryReader, false)
	{ }

	[Flags]
	public enum BoneGroup
	{
		None = 0,
		Body = 1,
		RightLeg = 2,
		LeftLeg = 4,
		RightArm = 8,
		LeftArm = 16,
		RightHand = 32,
		LeftHand = 64,
		Hair = 128,
		Neck = 256,
		Breast = 512,
		Skirt = 1024
	}
}
