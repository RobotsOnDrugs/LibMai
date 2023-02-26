namespace IllusionCards.AI.Scene;

public record AiStudioLookAtTarget : AiStudioObject
{
	public override int Kind => -1;
	public AiStudioLookAtTarget(BinaryReader binaryReader) : base(binaryReader, false) { }
}
