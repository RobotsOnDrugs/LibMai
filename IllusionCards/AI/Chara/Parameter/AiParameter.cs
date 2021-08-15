using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiParameter
	{
		public Version version { get; init; } = null!;
		public byte sex { get; init; }
		public string fullname { get; init; } = null!;
		public int personality { get; init; }
		public byte birthMonth { get; init; }
		public byte birthDay { get; init; }
		[IgnoreMember]
		public string strBirthDay { get => $"{birthMonth}/{birthDay}"; }
		public float voiceRate { get; init; }
		[IgnoreMember]
		public float voicePitch { get => Mathf.Lerp(0.94f, 1.06f, this.voiceRate); }
		public HashSet<int> hsWish { get; init; } = null!;
		[IgnoreMember]
		public int wish01 { get => hsWish.Count == 0 ? -1 : this.hsWish.ToArray<int>()[0]; }

		[IgnoreMember]
		public int wish02 { get => hsWish.Count == 0 ? -1 : this.hsWish.ToArray<int>()[1]; }
		[IgnoreMember]

		public int wish03 { get => hsWish.Count == 0 ? -1 : this.hsWish.ToArray<int>()[2]; }
		public bool futanari { get; init; }
		[IgnoreMember]
		public const string BlockName = "Parameter";
		public object? ExtendedSaveData { get; init; }
		public AiParameter() { }
	}
}
