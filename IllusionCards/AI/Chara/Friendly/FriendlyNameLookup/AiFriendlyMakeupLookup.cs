namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	//st_paint = 313 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//st_eyebrow = 314 0-26
	//st_eyelash = 315 0-8
	//st_eyeshadow = 316 0-43
	//st_eye = 317 0-29
	//st_eyeblack = 318 0-7
	//st_eye_hl = 319 0-44
	//st_cheek = 320 0-16
	//st_lip = 322 0-18
	//st_mole = 323 0-4
	//st_nip = 334 0-4
	//st_underhair = 335 0-14
	public static string GetFriendlyEyebrowName(in int eyebrowID) => eyebrowID switch
	{
		>= 0 and <= 29 => $"Type {eyebrowID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyMoleName(in int moleID) => moleID switch
	{
		0 => "None",
		1 => "Mole",
		2 => "Mole 2",
		3 => "Freckles",
		4 => "Freckles 2",
		_ => "Unknown"
	};
	public static string GetFriendlyPaintName(in int paintInfoID) => paintInfoID switch // IDs are in the order they are shown in the (HS2) character maker
	{
		0 => "None",
		14 => "Heart",
		12 => "Star",
		11 => "Crescent Moon",
		13 => "Water Drop",
		1 => "Bandage",
		3 => "Cross",
		2 => "5-Line Cross",
		4 => "Butterfly",
		9 => "Spider",
		8 => "Spiderweb",
		5 => "Forbidden",
		6 => "Yin-Yang",
		7 => "Rose",
		10 => "Kiss",
		15 => "Eye 1",
		17 => "Eye 2",
		16 => "Dirty",
		18 => "Square",
		19 => "Pyramid",
		20 => "Circle",
		21 => "Blurred Circle",
		22 => "Claw Marks",
		23 => "Starburst",
		24 => "Dot Circle",
		25 => "Triangle 1",
		26 => "Triangle 2",
		27 => "Hexagram",
		28 => "Thorns",
		29 => "Flame Moon",
		30 => "Handprint",
		31 => "Cat",
		32 => "Sunburst",
		33 => "Tribal 1",
		36 => "Tribal 2",
		34 => "Flower 1",
		35 => "Flower 2",
		37 => "Single Line",
		38 => "Double Line",
		39 => "Maro Eyebrows",
		40 => "Fox Prints",
		41 => "Crack",
		42 => "Lightning",
		47 => "Anchor",
		48 => "Wave",
		43 => "Cross 1",
		44 => "Cross 2",
		45 => "Flower Moon",
		46 => "Heart 2",
		_ => "Unknown"
	};
}
