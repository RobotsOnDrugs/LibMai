namespace IllusionCards.AI.Chara.Friendly.FriendlyNameLookup;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMaleTopName(in int itemID) => itemID switch // 140 mo_top
	{
		0 => "None",
		1 => "T-shirt",
		2 => "Dress Shirt A",
		3 => "Dress Shirt B",
		4 => "Polo Shirt",
		5 => "Jacket",
		6 => "Vest",
		7 => "Worker's Jacket",
		8 => "Tank Top A",
		9 => "Tank Top B",
		10 => "Long Cardigan",
		200 => "0",
		201 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleBottomName(in int itemID) => itemID switch // 141 mo_bot
	{
		0 => "None",
		1 => "Cropped Pants",
		2 => "Shorts",
		3 => "Hemmed Pants",
		4 => "Slacks",
		5 => "Worker's Pants",
		6 => "Surf Pants",
		7 => "Jeans",
		200 => "0",
		201 => "0",
		202 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleGlovesName(in int itemID) => itemID switch // 144 mo_gloves
	{
		0 => "None",
		1 => "Cotton Gloves",
		2 => "Gloves",
		3 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleShoesName(in int itemID) => itemID switch // 147 mo_shoes
	{
		0 => "None",
		1 => "Sneakers",
		2 => "Beach Sandals",
		3 => "Loafers",
		4 => "Business Shoes",
		5 => "Running Shoes",
		6 => "Mesh Shoes",
		7 => "High Tops",
		8 => "Hiking Shoes",
		9 => "Aquatic Sneakers",
		10 => "Slippers",
		11 => "0",
		_ => "Unknown"
	};
}
