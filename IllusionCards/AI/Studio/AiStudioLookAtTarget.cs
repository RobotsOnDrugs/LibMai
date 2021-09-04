namespace IllusionCards.AI.Studio
{
	public record AiStudioLookAtTarget : AiStudioObject
	{
		public override int Kind => -1;
		public AiStudioLookAtTarget(BinaryReader binaryReader) : base(binaryReader, false) { }
	}
}
