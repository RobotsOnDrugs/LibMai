﻿namespace IllusionCards.AI.Chara.Friendly;

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
	public static string GetFriendlyFemaleTopName(in int clothingID) => clothingID switch //fo_top = 240 0-35, 38-51, 200-207, 209-226, 228-229, 208, 227, 230-234, 236-237, 235, 238-246, 249, 248, 247
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		10 => "",
		11 => "",
		12 => "",
		13 => "",
		14 => "",
		15 => "",
		16 => "",
		17 => "",
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
		34 => "",
		35 => "",
		38 => "",
		39 => "",
		40 => "",
		41 => "",
		42 => "",
		43 => "",
		44 => "",
		45 => "",
		46 => "",
		47 => "",
		48 => "",
		49 => "",
		50 => "",
		51 => "",
		200 => "",
		201 => "",
		202 => "",
		203 => "",
		204 => "",
		205 => "",
		206 => "",
		207 => "",
		209 => "",
		210 => "",
		211 => "",
		212 => "",
		213 => "",
		214 => "",
		215 => "",
		216 => "",
		217 => "",
		218 => "",
		219 => "",
		220 => "",
		221 => "",
		222 => "",
		223 => "",
		224 => "",
		225 => "",
		226 => "",
		228 => "",
		229 => "",
		208 => "",
		227 => "",
		230 => "",
		231 => "",
		232 => "",
		233 => "",
		234 => "",
		236 => "",
		237 => "",
		235 => "",
		238 => "",
		239 => "",
		240 => "",
		241 => "",
		242 => "",
		243 => "",
		244 => "",
		245 => "",
		246 => "",
		249 => "",
		248 => "",
		247 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleBottomName(in int clothingID) => clothingID switch //fo_bot = 241 0-16, 19-21, 200-216, 218, 217, 220, 219, 221-224, 227, 225-226
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		10 => "",
		11 => "",
		12 => "",
		13 => "",
		14 => "",
		15 => "",
		16 => "",
		19 => "",
		20 => "",
		21 => "",
		200 => "",
		201 => "",
		202 => "",
		203 => "",
		204 => "",
		205 => "",
		206 => "",
		207 => "",
		208 => "",
		209 => "",
		210 => "",
		211 => "",
		212 => "",
		213 => "",
		214 => "",
		215 => "",
		216 => "",
		218 => "",
		217 => "",
		220 => "",
		219 => "",
		221 => "",
		222 => "",
		223 => "",
		224 => "",
		227 => "",
		225 => "",
		226 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleInnerTopName(in int clothingID) => clothingID switch //fo_inner_t = 242 0-20, 22-28, 200-201, 204-214, 202-203, 215-222, 224, 223, 225
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		10 => "",
		11 => "",
		12 => "",
		13 => "",
		14 => "",
		15 => "",
		16 => "",
		17 => "",
		18 => "",
		19 => "",
		20 => "",
		22 => "",
		23 => "",
		24 => "",
		25 => "",
		26 => "",
		27 => "",
		28 => "",
		200 => "",
		201 => "",
		204 => "",
		205 => "",
		206 => "",
		207 => "",
		208 => "",
		209 => "",
		210 => "",
		211 => "",
		212 => "",
		213 => "",
		214 => "",
		202 => "",
		203 => "",
		215 => "",
		216 => "",
		217 => "",
		218 => "",
		219 => "",
		220 => "",
		221 => "",
		222 => "",
		224 => "",
		223 => "",
		225 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleInnerBottomName(in int clothingID) => clothingID switch //fo_inner_b = 243 0-16, 19-21, 200-201, 203-208, 202, 209-214
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		10 => "",
		11 => "",
		12 => "",
		13 => "",
		14 => "",
		15 => "",
		16 => "",
		19 => "",
		20 => "",
		21 => "",
		200 => "",
		201 => "",
		203 => "",
		204 => "",
		205 => "",
		206 => "",
		207 => "",
		208 => "",
		202 => "",
		209 => "",
		210 => "",
		212 => "",
		213 => "",
		214 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleGlovesName(in int clothingID) => clothingID switch //fo_gloves = 244 0-5, 7-10, 200-202, 205-209, 203-204, 210-218
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		7 => "",
		8 => "",
		9 => "",
		10 => "",
		200 => "",
		201 => "",
		202 => "",
		205 => "",
		206 => "",
		207 => "",
		208 => "",
		209 => "",
		203 => "",
		204 => "",
		210 => "",
		211 => "",
		212 => "",
		213 => "",
		214 => "",
		215 => "",
		216 => "",
		217 => "",
		218 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFemalePantyhoseName(in int clothingID) => clothingID switch //fo_panst = 245 0-4, 6, 5, 7-8, 10-17, 200-207
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		6 => "",
		5 => "",
		7 => "",
		8 => "",
		10 => "",
		11 => "",
		12 => "",
		13 => "",
		14 => "",
		15 => "",
		16 => "",
		17 => "",
		200 => "",
		201 => "",
		202 => "",
		203 => "",
		204 => "",
		205 => "",
		206 => "",
		207 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleSocksName(in int clothingID) => clothingID switch //fo_socks = 246 0-9, 11-14, 200-202, 204, 206-207, 203, 205, 208-211, 213, 212, 214
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		11 => "",
		12 => "",
		13 => "",
		14 => "",
		200 => "",
		201 => "",
		202 => "",
		204 => "",
		206 => "",
		207 => "",
		203 => "",
		205 => "",
		208 => "",
		209 => "",
		210 => "",
		211 => "",
		213 => "",
		212 => "",
		214 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleShoesName(in int clothingID) => clothingID switch //fo_shoes = 247 0-13, 16-20, 200-204, 206-207, 209-215, 205, 208, 216-217, 227, 218, 220, 219, 221-224, 228, 226, 225
	{
		0 => "None",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		10 => "",
		11 => "",
		12 => "",
		13 => "",
		16 => "",
		17 => "",
		18=> "",
		19 => "",
		20 => "",
		200 => "",
		201 => "",
		202 => "",
		203 => "",
		204 => "",
		206 => "",
		207 => "",
		209 => "",
		210 => "",
		211 => "",
		212 => "",
		213 => "",
		214 => "",
		215 => "",
		205 => "",
		208 => "",
		216 => "",
		217 => "",
		227 => "",
		218 => "",
		220 => "",
		219 => "",
		221 => "",
		222 => "",
		223 => "",
		224 => "",
		228 => "",
		226 => "",
		225 => "",
		_ => "Unknown"
	};
}