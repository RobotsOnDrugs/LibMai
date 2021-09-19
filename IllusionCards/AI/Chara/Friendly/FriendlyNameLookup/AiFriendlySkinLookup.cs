namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlySkinColorPresetName(in int skinColorID) => skinColorID switch //preset_skin_color = 336 0-19
	{
		0 => "",
		_ => "Unknown"
	};

	public static string GetFriendly_st_pattern_Name(in int patternID) => patternID switch //st_pattern = 348 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	{
		0 => "",
		14 => "",
		12 => "",
		11 => "",
		13 => "",
		1 => "",
		3 => "",
		2 => "",
		4 => "",
		9 => "",
		8 => "",
		5 => "",
		6 => "",
		7 => "",
		10 => "",
		15 => "",
		17 => "",
		16 => "",
		18 => "",
		19 => "",
		20 => "",
		21 => "",
		22 => "",
		23 => "",
		24 => "",
		25 => "",
		26 => "",
		27 => "",
		28 => "",
		29 => "",
		30 => "",
		31 => "",
		32 => "",
		33 => "",
		36 => "",
		34 => "",
		35 => "",
		37 => "",
		38 => "",
		39 => "",
		40 => "",
		41 => "",
		42 => "",
		47 => "",
		48 => "",
		43 => "",
		44 => "",
		45 => "",
		46 => "",
		_ => "Unknown"
	};
}
