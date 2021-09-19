namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyHairBackName(in int hairID) => hairID switch //so_hair_b = 300 0-3, 16, 4-10, 17, 11-15, 18-29, 50-68
	{
		0 => "",
		_ => "Unknown"
	};

	public static string GetFriendlyHairFrontName(in int hairID) => hairID switch //so_hair_f = 301 0-24, 50-64
	{
		0 => "",
		_ => "Unknown"
	};

	public static string GetFriendlyHairSideName(in int hairID) => hairID switch //so_hair_s = 302 0-7
	{
		0 => "",
		_ => "Unknown"
	};

	public static string GetFriendlyHairExtensionName(in int hairID) => hairID switch //so_hair_o = 303 0-7
	{
		0 => "None",
		1 => "Sideways Hair",
		2 => "Double Hair Strands",
		3 => "Upper Hair Strand",
		4 => "Forward Hair",
		5 => "Bun",
		6 => "Braided Band",
		7 => "Braided Band (Back)",
		_ => "Unknown"
	};

	public static string GetFriendlyHairColorPresetName(in int hairID) => hairID switch //preset_hair_color = 305 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	{
		0 => "",
		_ => "Unknown"
	};

	public static string GetFriendlyHairMeshPatternName(in int hairID) => hairID switch //st_hairmeshptn = 306 0-11 "Type n"
	{
		0 => "None",
		>= 0 and <= 11 => $"Type {hairID}",
		_ => "Unknown"
	};
}
