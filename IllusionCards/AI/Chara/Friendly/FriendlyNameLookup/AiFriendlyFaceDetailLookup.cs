namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMoleLayoutName(in int headID) => headID switch //mole_layout = 6
	{
		0 => "Below Lips (Left)",
		1 => "Below Lips (Right)",
		2 => "Above Lips (Left)",
		3 => "Above Lips (Right)",
		4 => "Below Left Eye",
		5 => "Below Right Eye",
		6 => "Forehead Center",
		7 => "Freckles",
		_ => "Unknown",
	};
	public static string GetFriendlyFacePaintLayoutName(in int headID) => headID switch //facepaint_layout = 7 0-5

	{
		0 => "Left Side of Face",
		1 => "Right Side of Face",
		2 => "Forehead",
		3 => "Nose",
		4 => "Mouth",
		5 => "Jaw",
		_ => "Unknown",
	};
	public static string GetFriendlyBodyPaintLayoutName(in int headID) => headID switch //bodypaint_layout = 8 0-9
	{
		0 => "Chest",
		1 => "Midriff",
		2 => "Between Shoulder Blades",
		3 => "Hips",
		4 => "Back of Right Leg",
		5 => "Back of Right Calf",
		6 => "Back of Left Leg",
		7 => "Back of Left Calf",
		8 => "Right Leg",
		9 => "Left Leg",
		// TODO: There are more that look like vanilla locations but I'll have to test
		_ => "Unknown",
	};
}
