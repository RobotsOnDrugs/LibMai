using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly struct AiParameter2
	{
		public Version version { get; init; } = null!;
		public int personality { get; init; }
		public float voiceRate { get; init; }
		[IgnoreMember]
		public float voicePitch { get => Mathf.Lerp(0.94f, 1.06f, this.voiceRate); }
		public byte trait { get; init; }
		public byte mind { get; init; }
		public byte hAttribute { get; init; }
		public object? ExtendedSaveData { get; init; }
	}
}
