namespace IllusionCards.AI.Chara.Friendly;

public readonly record struct AiCharaInfoData // Parameter - this is common to both AIS and HS2
{
	public CharaSex Sex { get; init; }
	public string Name { get; init; }
	public PersonalityType Personality { get; init; }
	public int BirthMonth { get; init; }
	public int BirthDay { get; init; }
	public float VoiceRate { get; init; }
	public float VoicePitch => Mathf.Lerp(0.94f, 1.06f, VoiceRate);
	public bool IsFuta { get; init; }

	public enum PersonalityType
	{
		Composed,
		Normal,
		Hardworking,
		Girlfriend,
		Fashionable,
		Timid,
		Motherly,
		Sadistic,
		OpenMinded,
		Airhead,
		Careful,
		IdealJapanese,
		Tomboy,
		Obsessed
	}
}