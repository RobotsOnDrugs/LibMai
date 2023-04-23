namespace IllusionCards.AI.Chara.Friendly.FriendlyNameLookup;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyHairBackName(in int hairID) => hairID switch // 300 so_hair_b
	{
		0 => "Long Straight",
		1 => "Messy Short",
		2 => "Thick Ponytail",
		3 => "Thin Twin Tails",
		16 => "Thin & Long Twin Tails",
		4 => "Medium Length",
		5 => "Blunt Long",
		6 => "Twin Over-shoulder Tails",
		7 => "Ponytail",
		8 => "Voluminous Long",
		9 => "Short",
		10 => "Twin Rolls",
		17 => "Long Twin Rolls",
		11 => "Wavy Long",
		12 => "Bob Cut",
		13 => "Spiky Medium",
		14 => "Spiky Short",
		15 => "Side Tail",
		18 => "Both Sides Up",
		19 => "Messy Medium",
		20 => "Ponytail Bun",
		21 => "Double Bun",
		22 => "Buzz Cut",
		23 => "Voluminous Twin Tails",
		24 => "Voluminous Sides Up",
		25 => "Side Tail (Left)",
		26 => "Side Tail (Right)",
		27 => "0",
		28 => "0",
		29 => "Voluminous Twin Rolls",
		50 => "0",
		51 => "0",
		52 => "0",
		53 => "0",
		54 => "0",
		55 => "0",
		56 => "0",
		57 => "0",
		58 => "0",
		59 => "0",
		60 => "三つ編みツインおさげ",
		61 => "0",
		62 => "0",
		63 => "0",
		64 => "0",
		65 => "0",
		66 => "0",
		67 => "0",
		68 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyHairFrontName(in int itemID) => itemID switch // 301 so_hair_f
	{
		0 => "None",
		1 => "Long",
		2 => "Messy Short",
		3 => "Side Part",
		4 => "M Bangs",
		5 => "Trim",
		6 => "Princess",
		7 => "Center Part (Bare Forehead)",
		8 => "Over-eye",
		9 => "Spiky",
		10 => "Short",
		11 => "Asymmetric",
		12 => "Wavy Long",
		13 => "Bangs",
		14 => "Medium Wave",
		15 => "Antenna Bangs",
		16 => "Lopsided Short",
		17 => "Framed Blunt",
		18 => "Medium Cross",
		19 => "Side Wave (Left)",
		20 => "Side Wave (Right)",
		21 => "0",
		23 => "0",
		24 => "Wavy Goth Lolita Bangs",
		50 => "0",
		51 => "0",
		52 => "0",
		53 => "0",
		54 => "0",
		55 => "0",
		56 => "0",
		57 => "ナチュラルエムバング",
		58 => "0",
		59 => "0",
		60 => "0",
		61 => "0",
		62 => "0",
		63 => "0",
		64 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyHairSideName(in int itemID) => itemID switch // 302 so_hair_s
	{
		0 => "None",
		1 => "Thick Locks",
		2 => "Long Locks",
		3 => "Thin Locks",
		4 => "Curly",
		5 => "Unkempt Ponytail",
		6 => "Braided Locks",
		7 => "Thin Braided Locks",
		_ => "Unknown"
	};
	public static string GetFriendlyHairExtensionName(in int itemID) => itemID switch // 303 so_hair_o
	{
		0 => "None",
		1 => "Side Hair Flick",
		2 => "Double Hair Flick",
		3 => "Vertical Hair Flick",
		4 => "Forward Hair Flick",
		5 => "Bun",
		6 => "Braided Band",
		7 => "Braided Band (Back)",
		_ => "Unknown"
	};
	public static string GetFriendlyHairColorPresetName(in int itemID) => itemID switch // 305 preset_hair_color
	{
		_ => "Unknown"
	};
	public static string GetFriendlyHairMeshPatternName(in int hairID) => hairID switch // 306 st_hairmeshptn
	{
		0 => "None",
		>= 0 and <= 11 => $"Type {hairID}",
		_ => "Unknown"
	};
}
