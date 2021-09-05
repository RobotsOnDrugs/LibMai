namespace IllusionCards.AI.Studio;

public readonly struct AiVoiceControl
{
	// There are a bunch of other properties that the game uses internally, but they are calculated rather than stored
	// Only these properties exist in the saved data.
	public ImmutableArray<AiVoiceInfo> VoiceInfo { get; init; }
	public Repeat RepeatMode { get; init; }

	public readonly struct AiVoiceInfo
	{
		public int Category { get; init; }
		public int Group { get; init; }
		public int Number { get; init; }

		public AiVoiceInfo(BinaryReader binaryReader)
		{
			Category = binaryReader.ReadInt32();
			Group = binaryReader.ReadInt32();
			Number = binaryReader.ReadInt32();
		}
	}
	public enum Repeat { None, All, Select }

	public AiVoiceControl(BinaryReader binaryReader)
	{
		var _voiceInfoBuilder = ImmutableArray.CreateBuilder<AiVoiceInfo>();
		int _count = binaryReader.ReadInt32();
		for (int i = 0; i < _count; i++)
		{
			_voiceInfoBuilder.Add(new(binaryReader));
		}
		VoiceInfo = _voiceInfoBuilder.ToImmutable();
		RepeatMode = (Repeat)binaryReader.ReadInt32();
	}
}
