namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlySkinColorPresetName(in int itemID) => itemID switch // 336 preset_skin_color
	{
		0 => "Light",
		1 => "Beige",
		2 => "Pink",
		3 => "Tan",
		4 => "Brown",
		5 => "Dark",
		6 => "Blue",
		_ => "Unknown"
	};
}