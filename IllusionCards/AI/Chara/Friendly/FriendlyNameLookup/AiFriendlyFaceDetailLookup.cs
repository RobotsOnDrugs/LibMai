namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMoleLayoutName(in int itemID) => itemID switch // 6 mole_layout
	{
		0 => "Below Lips (Left)",
		1 => "Below Lips (Right)",
		2 => "Above Lips (Left)",
		3 => "Above Lips (Right)",
		4 => "Below Left Eye",
		5 => "Below Right Eye",
		6 => "Forehead Center",
		7 => "Freckles",
		_ => "Unknown"
	};
	public static string GetFriendlyFacepaintLayoutName(in int itemID) => itemID switch // 7 facepaint_layout
	{
		0 => "Left Cheek",
		1 => "Right Cheek",
		2 => "Forehead",
		3 => "Nose",
		4 => "Mouth",
		5 => "Chin",
		_ => "Unknown"
	};
	public static string GetFriendlyBodypaintLayoutName(in int itemID) => itemID switch // 8 bodypaint_layout
	{
		0 => "Chest",
		1 => "Stomach",
		2 => "Upper Back",
		3 => "Lower Back",
		4 => "Right Thigh (Back)",
		5 => "Right Calf",
		6 => "Left Thigh (Back)",
		7 => "Left Calf",
		8 => "Right Thigh",
		9 => "Left Thigh",
		10 => "Right Shin",
		11 => "Left Shin",
		12 => "Right Foot",
		13 => "Left Foot",
		14 => "Left Butt",
		15 => "Right Butt",
		16 => "Left Bicep",
		17 => "Left Forearm",
		18 => "Right Bicep",
		19 => "Right Forearm",
		_ => "Unknown"
	};
	public static string GetFriendlyFacepaintName(in int facepaintID) => facepaintID switch // 313 st_paint
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
		7 => "Heart",
		10 => "Kiss",
		15 => "Eye 1",
		17 => "Eye 2",
		16 => "Smudge",
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
	public static string GetFriendlyEyebrowName(in int itemID) => itemID switch // 314 st_eyebrow
	{
		>= 0 and <= 16 => $"Type {itemID + 1}",
		17 => "0",
		18 => "0",
		19 => "0",
		20 => "0",
		21 => "0",
		22 => "0",
		23 => "0",
		24 => "0",
		25 => "0",
		26 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyEyelashTypeName(in int itemID) => itemID switch // 315 st_eyelash
	{
		>= 0 and <= 4 => $"Type {itemID + 1}",
		5 => "0",
		6 => "0",
		7 => "0",
		8 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyEyeshadowName(in int itemID) => itemID switch // 316 st_eyeshadow
	{
		0 => "None",
		>= 1 and <= 23 => $"Type {itemID}",
		24 => "0",
		25 => "0",
		26 => "0",
		27 => "0",
		28 => "0",
		29 => "0",
		30 => "0",
		31 => "0",
		32 => "0",
		33 => "0",
		34 => "0",
		35 => "0",
		36 => "0",
		37 => "0",
		38 => "0",
		39 => "0",
		40 => "0",
		41 => "0",
		42 => "0",
		43 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyIrisName(in int itemID) => itemID switch // 317 st_eye
	{
		>= 0 and <= 22 => $"Type {itemID + 1}",
		23 => "0",
		24 => "0",
		25 => "0",
		26 => "0",
		27 => "0",
		28 => "0",
		29 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyPupilName(in int itemID) => itemID switch // 318 st_eyeblack
	{
		>= 0 and <= 7 => $"Type {itemID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyEyeHighlightName(in int itemID) => itemID switch // 319 st_eye_hl
	{
		>= 0 and <= 43 => $"Type {itemID + 1}",
		44 => "Reflective",
		_ => "Unknown"
	};
	public static string GetFriendlyBlushName(in int itemID) => itemID switch // 320 st_cheek
	{
		0 => "None",
		>= 1 and <= 14 => $"Type {itemID}",
		15 => "0",
		16 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyLipstickName(in int itemID) => itemID switch // 322 st_lip
	{
		0 => "None",
		>= 1 and <= 18 => $"Type {itemID}",
		_ => "Unknown"
	};
	public static string GetFriendlyMoleName(in int moleID) => moleID switch //323 st_mole
	{
		0 => "None",
		1 => "Mole",
		2 => "Mole 2",
		3 => "Freckles",
		4 => "Freckles 2",
		_ => "Unknown"
	};
	public static string GetFriendlyNippleName(in int itemID) => itemID switch // 334 st_nip
	{
		>= 0 and <= 4 => $"Type {itemID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyPubicHairName(in int itemID) => itemID switch // 335 st_underhair
	{
		0 => "None",
		1 => "Square",
		2 => "Round",
		3 => "Sparse Small",
		4 => "Sparse Square",
		5 => "Sparse Round",
		6 => "Small Round",
		7 => "Large Triangle",
		8 => "Small Triangle",
		9 => "Landing Strip",
		10 => "Thin Landing Strip",
		11 => "Diamond",
		12 => "Heart",
		13 => "Stubble",
		14 => "Natural",
		_ => "Unknown"
	};
}
