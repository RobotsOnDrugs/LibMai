namespace IllusionCards.AI.Chara.Friendly.FriendlyNameLookup;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMaleSampleCharacterName(in int itemID) => itemID switch // 0 cha_sample_m
	{
		0 => "Sample 01",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleSampleCharacterName(in int itemID) => itemID switch // 1 cha_sample_f
	{
		0 => "Sample 01",
		1 => "Merchant",
		2 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyPersonalityName(in int itemID) => itemID switch // 3 init_type_param
	{
		0 => "Robotic Deadpan",
		1 => "Gentle & Kind",
		2 => "Confident Go-Getter",
		3 => "Selfish Narcissist",
		4 => "Listless Deadpan",
		5 => "Cheerful Optimist",
		6 => "0",
		7 => "0",
		8 => "0",
		9 => "0",
		10 => "0",
		11 => "0",
		12 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyDesireName(in int itemID) => itemID switch // 4 init_wish_param
	{
		0 => "Kindness",
		1 => "Pleasure",
		2 => "Impishness",
		3 => "Stimulation",
		4 => "Courtesy",
		5 => "Deviance",
		6 => "Composure",
		7 => "Money",
		8 => "Intelligence",
		9 => "Conviction",
		10 => "Loyalty",
		11 => "Stamina",
		12 => "Sweetness",
		13 => "Innocence",
		14 => "Imperfection",
		15 => "Insight",
		16 => "Decisiveness",
		17 => "Soothing",
		_ => "Unknown"
	};
	public static string GetFriendlyCharaSampleVoiceName(in int itemID) => itemID switch // 5 cha_sample_voice
	{
		0 => "Robotic Deadpan",
		1 => "Gentle & Kind",
		2 => "Confident Go-Getter",
		3 => "Selfish Narcissist",
		4 => "Listless Deadpan",
		5 => "Cheerful Optimist",
		6 => "0",
		7 => "0",
		8 => "0",
		9 => "0",
		10 => "0",
		11 => "0",
		12 => "0",
		13 => "0",
		_ => "Unknown"
	};
}
