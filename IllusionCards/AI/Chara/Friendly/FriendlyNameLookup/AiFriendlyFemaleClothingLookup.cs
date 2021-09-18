namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyFemaleClothingByIndexAndID(in int position, in int itemID) => position switch
	{
		0 => GetFriendlyNameByCategoryID(240, itemID),
		1 => GetFriendlyNameByCategoryID(241, itemID),
		2 => GetFriendlyNameByCategoryID(242, itemID),
		3 => GetFriendlyNameByCategoryID(243, itemID),
		4 => GetFriendlyNameByCategoryID(244, itemID),
		5 => GetFriendlyNameByCategoryID(245, itemID),
		6 => GetFriendlyNameByCategoryID(246, itemID),
		7 => GetFriendlyNameByCategoryID(247, itemID),
		_ => throw new ArgumentOutOfRangeException(nameof(position), "There are only 8 possible indices in a female clothing info array.")
	};
	//fo_top = 240 0-35, 38-51, 200-207, 209-226, 228-229, 208, 227, 230-234, 236-237, 235, 238-246, 249, 248, 247
	//fo_bot = 241 0-16, 19-21, 200-216, 218, 217, 220, 219, 221-224, 227, 225-226
	//fo_inner_t = 242 0-20, 22-28, 200-201, 204-214, 202-203, 215-222, 224, 223, 225
	//fo_inner_b = 243 0-16, 19-21, 200-201, 203-208, 202, 209-214
	//fo_gloves = 244 0-5, 7-10, 200-202, 205-209, 203-204, 210-218
	//fo_panst = 245 0-4, 6, 5, 7-8, 10-17, 200-207
	//fo_socks = 246 0-9, 11-14, 200-202, 204, 206-207, 203, 205, 208-211, 213, 212, 214
	//fo_shoes = 247 0-13, 16-20, 200-204, 206-207, 209-215, 205, 208, 216-217, 227, 218, 220, 219, 221-224, 228, 226, 225
}
