namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMaleTopName(in int clothingID) => clothingID switch //mo_top = 140
	{
		0 => "None",
		1 => "T-Shirt",
		2 => "Dress Shirt A",
		3 => "Dress Shirt B",
		4 => "Polo Shirt",
		5 => "Jacket",
		6 => "Vest",
		7 => "Worker's Jacket",
		8 => "Tank Top A",
		9 => "Tank Top B",
		10 => "Long Cardigan",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleBottomName(in int clothingID) => clothingID switch //mo_bot = 141
	{
		0 => "None",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleGlovesName(in int clothingID) => clothingID switch //mo_gloves = 144
	{
		0 => "None",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleShoesName(in int clothingID) => clothingID switch //mo_shoes = 147
	{
		0 => "None",
		_ => "Unknown"
	};
}
