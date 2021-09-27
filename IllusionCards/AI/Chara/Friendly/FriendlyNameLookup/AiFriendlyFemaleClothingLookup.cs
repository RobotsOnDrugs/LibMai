﻿namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyFemaleClothingByIndexAndID(in FemaleClothingType type, in int itemID) => GetFriendlyFemaleClothingByIndexAndID((int)type, itemID);
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

	public static string GetFriendlyFemaleTopName(in int itemID) => itemID switch // 240 fo_top
	{
		0 => "None",
		1 => "Dress",
		2 => "T-shirt",
		3 => "Mini Tee",
		4 => "Angled Mini Tee",
		5 => "Baby Tee",
		6 => "Camisole A",
		7 => "Camisole B",
		8 => "Camisole C",
		9 => "Tube Top",
		10 => "Blouse",
		11 => "Open Blouse",
		12 => "Oversized Shirt",
		13 => "Salopettes",
		14 => "Salopette (Naked)",
		15 => "Hoodie",
		16 => "Open Hoodie",
		17 => "Athletic Wear",
		18 => "Long Pareo",
		19 => "Tropical Tube Top (Frills)",
		20 => "Tropical Pareo",
		21 => "Tight Dress",
		22 => "Flared Shirt",
		23 => "Sleeveless Knit Sweater",
		24 => "Cardigan & Camisole",
		25 => "Cardigan & Dress Shirt",
		26 => "Open Cardigan",
		27 => "Body Harness",
		28 => "Suit",
		29 => "Suit & Camisole",
		30 => "Open Suit",
		31 => "Blazer",
		32 => "Sailor Uniform",
		33 => "Gym Shirt",
		34 => "Sailor Collar",
		35 => "Coconut Bra",
		38 => "Summer Knit Sweater",
		39 => "Summer Dress",
		40 => "Cocktail Dress",
		41 => "Shoulderless Shirt",
		42 => "Knit Camisole",
		43 => "Hiking Jacket",
		44 => "Simple Dress",
		45 => "Ribboned Camisole",
		46 => "Cute Jacket",
		47 => "Sleeveless Turtleneck",
		48 => "Sleeveless Blouse",
		37 => "0",
		36 => "0",
		49 => "Witch Negligee",
		50 => "0",
		51 => "Christmas Poncho",
		200 => "0",
		201 => "0",
		202 => "0",
		203 => "0",
		204 => "0",
		205 => "0",
		206 => "0",
		207 => "0",
		209 => "0",
		210 => "0",
		211 => "0",
		212 => "0",
		213 => "0",
		214 => "0",
		215 => "0",
		216 => "0",
		217 => "0",
		218 => "0",
		219 => "0",
		220 => "0",
		221 => "0",
		222 => "0",
		223 => "0",
		224 => "0",
		225 => "0",
		226 => "0",
		228 => "0",
		229 => "0",
		208 => "0",
		227 => "エプロン",
		230 => "亀甲縛り",
		231 => "着物ミニ",
		232 => "逆バニートップス",
		233 => "0",
		234 => "0",
		236 => "0",
		237 => "0",
		235 => "0",
		238 => "0",
		239 => "0",
		240 => "0",
		241 => "0",
		242 => "0",
		243 => "0",
		244 => "0",
		245 => "0",
		246 => "0",
		249 => "0",
		248 => "0",
		247 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleBottomName(in int itemID) => itemID switch // 241 fo_bot
	{
		0 => "None",
		1 => "Shorts",
		2 => "Hot Pants",
		3 => "Athletic Shorts",
		4 => "Pleated Skirt",
		5 => "Mini Skirt",
		6 => "Tight Skirt",
		7 => "Slitted Skirt (Back)",
		8 => "Tight Mini Skirt",
		9 => "Short Leggings",
		10 => "Jeans",
		11 => "Suit Pants",
		12 => "Bloomers",
		13 => "Pareo",
		14 => "Tropical Skirt",
		15 => "Grass Skirt",
		16 => "Leather Skirt",
		19 => "Stretch Pants",
		20 => "Ribbon Pants",
		21 => "Wrap Skirt",
		17 => "0",
		18 => "0",
		200 => "0",
		201 => "0",
		202 => "0",
		203 => "0",
		204 => "0",
		205 => "0",
		206 => "0",
		207 => "0",
		208 => "0",
		209 => "0",
		210 => "0",
		211 => "0",
		212 => "0",
		213 => "0",
		214 => "0",
		215 => "0",
		216 => "0",
		218 => "0",
		217 => "0",
		220 => "0",
		219 => "0",
		221 => "0",
		222 => "0",
		223 => "0",
		224 => "0",
		227 => "0",
		225 => "0",
		226 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleInnerTopName(in int itemID) => itemID switch // 242 fo_inner_t
	{
		0 => "None",
		1 => "Standard",
		2 => "Ribbon Lace",
		3 => "Adult Lace",
		4 => "Half Lace",
		5 => "Full Lace",
		6 => "Micro Lace",
		7 => "Sports Bra",
		8 => "Strapless",
		9 => "Tube",
		10 => "Bikini",
		11 => "Ribbon Bikini",
		12 => "Micro Bikini",
		13 => "Micro S Bikini",
		14 => "Twist",
		15 => "One-piece",
		16 => "Classic School Swimsuit",
		17 => "Racing Swimsuit",
		18 => "Heart Stickers",
		19 => "Star Stickers",
		20 => "Bandage",
		21 => "0",
		22 => "Bunny Suit",
		23 => "Slingshot",
		24 => "Mecha Tights",
		25 => "Mecha Suit",
		26 => "Christmas Bikini",
		27 => "0",
		28 => "Ribbon Bra",
		200 => "0",
		201 => "0",
		204 => "0",
		205 => "0",
		206 => "0",
		207 => "0",
		208 => "0",
		209 => "0",
		210 => "0",
		211 => "0",
		212 => "0",
		213 => "0",
		214 => "0",
		202 => "0",
		203 => "0",
		215 => "サラシ",
		216 => "ライトレザー水着",
		217 => "小悪魔水着トップス",
		218 => "0",
		219 => "0",
		220 => "0",
		221 => "0",
		222 => "0",
		224 => "0",
		223 => "0",
		225 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleInnerBottomName(in int itemID) => itemID switch // 243 fo_inner_b
	{
		0 => "None",
		1 => "Standard",
		2 => "Ribbon Lace",
		3 => "Adult Lace",
		4 => "Half Lace",
		5 => "Full Lace",
		6 => "Micro Lace",
		7 => "Sports Bottom",
		8 => "High Back",
		9 => "Thong",
		10 => "Bikini",
		11 => "Ribbon Bikini",
		12 => "Micro Bikini",
		13 => "Micro S Bikini",
		14 => "Heart Stickers",
		15 => "Star Stickers",
		16 => "Bandage",
		17 => "0",
		18 => "0",
		19 => "Low-rise Lace",
		20 => "0",
		21 => "Christmas Bikini",
		200 => "0",
		201 => "0",
		203 => "0",
		204 => "0",
		205 => "0",
		206 => "0",
		207 => "0",
		208 => "0",
		202 => "0",
		209 => "小悪魔水着ボトム",
		210 => "0",
		211 => "0",
		212 => "0",
		213 => "0",
		214 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleGlovesName(in int itemID) => itemID switch // 244 fo_gloves
	{
		0 => "None",
		1 => "Cotton Gloves",
		2 => "Sport Gloves",
		3 => "Sport Glove (Left)",
		4 => "Long Gloves",
		5 => "Finger Gloves",
		6 => "0",
		7 => "Witch Sleeves",
		8 => "Christmas Gloves",
		9 => "Christmas Mittens",
		10 => "0",
		200 => "0",
		201 => "0",
		202 => "0",
		205 => "0",
		206 => "0",
		207 => "0",
		208 => "0",
		209 => "0",
		203 => "0",
		204 => "0",
		210 => "フリルリボン",
		211 => "0",
		212 => "0",
		213 => "0",
		214 => "0",
		215 => "0",
		216 => "0",
		217 => "0",
		218 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemalePantyhoseName(in int itemID) => itemID switch // 245 fo_panst
	{
		0 => "None",
		1 => "Pantyhose",
		2 => "Pantyhose T",
		3 => "Pantyhose H",
		4 => "Lace Stockings",
		6 => "Fishnet Tights (Fine)",
		5 => "Fishnet Tights (Medium)",
		7 => "Fishnet Tights (Large)",
		8 => "Crotchless Pantyhose",
		10 => "Spats A",
		11 => "Spats B",
		12 => "Short Spats",
		13 => "Simple Garter Belt",
		14 => "Lace Garter Belt",
		15 => "Garter Belt",
		16 => "Bunny Net Tights",
		17 => "Bunny Stockings",
		200 => "0",
		201 => "0",
		202 => "0",
		203 => "0",
		204 => "逆バニーボトム",
		205 => "0",
		206 => "0",
		207 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleSocksName(in int itemID) => itemID switch // 246 fo_socks
	{
		0 => "None",
		1 => "Socks",
		2 => "High Socks",
		3 => "Knee Socks",
		4 => "Sneaker Socks",
		5 => "Loose Socks",
		6 => "Thigh-highs",
		7 => "Sheer Thigh-highs",
		8 => "Garter Stockings",
		9 => "Slip-ons",
		10 => "0",
		11 => "Witch Thigh-highs",
		12 => "0",
		13 => "Christmas Socks",
		14 => "0",
		200 => "0",
		201 => "0",
		202 => "0",
		204 => "0",
		206 => "0",
		207 => "0",
		203 => "0",
		205 => "0",
		208 => "足袋",
		209 => "0",
		210 => "0",
		211 => "0",
		213 => "0",
		212 => "0",
		214 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleShoesName(in int itemID) => itemID switch // 247 fo_shoes
	{
		0 => "None",
		1 => "Beach Sandals",
		2 => "Strap Sandals",
		3 => "Loafers",
		4 => "Pumps",
		5 => "Belt Pumps",
		6 => "Running Shoes",
		7 => "Sneakers",
		8 => "Mesh Shoes",
		9 => "High Tops",
		10 => "Hiking Shoes",
		11 => "Aquatic Sneakers",
		12 => "Slippers",
		13 => "Leather Boots & Chaps",
		15 => "0",
		14 => "0",
		16 => "Bunny Pumps",
		17 => "Witch Boots",
		18 => "0",
		19 => "Ugg Boots",
		20 => "0",
		200 => "0",
		201 => "0",
		202 => "0",
		203 => "0",
		204 => "0",
		206 => "0",
		207 => "0",
		209 => "0",
		210 => "0",
		211 => "0",
		212 => "0",
		213 => "0",
		214 => "0",
		215 => "0",
		205 => "0",
		208 => "0",
		216 => "キュートスリッパ",
		217 => "２色鼻緒下駄",
		227 => "サマーサンダル",
		218 => "0",
		220 => "0",
		219 => "0",
		221 => "0",
		222 => "0",
		223 => "0",
		224 => "0",
		228 => "0",
		226 => "0",
		225 => "0",
		_ => "Unknown"
	};

	public enum FemaleClothingType // This matches the indices for ChaFileStatus.clothesState
	{
		Top,
		Bottom,
		InnerTop,
		InnerBottom,
		Gloves,
		Pantyhose,
		Socks,
		Shoes
	}
}
