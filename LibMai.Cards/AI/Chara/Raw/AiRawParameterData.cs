namespace LibMai.Cards.AI.Chara.Raw;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawParameterData
{
	public AiRawParameterData() { }
	public Version version { get; init; } = null!;
	public byte sex { get; init; }
	public string fullname { get; init; } = null!;
	public int personality { get; init; }
	public byte birthMonth { get; init; }
	public byte birthDay { get; init; }
	[IgnoreMember]
	public string strBirthDay => $"{birthMonth}/{birthDay}";
	public float voiceRate { get; init; }
	[IgnoreMember]
	public float voicePitch => Mathf.Lerp(0.94f, 1.06f, voiceRate);
	public HashSet<int> hsWish { get; init; } = null!;
	[IgnoreMember]
	public int wish01 => hsWish.Count == 0 ? -1 : hsWish.ToArray()[0];

	[IgnoreMember]
	public int wish02 => hsWish.Count == 0 ? -1 : hsWish.ToArray()[1];
	[IgnoreMember]

	public int wish03 => hsWish.Count == 0 ? -1 : hsWish.ToArray()[2];
	public bool futanari { get; init; }
}
