namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyNameByCategoryID(in int categoryID, in int itemID) => categoryID switch
	{
		0 => throw new NotImplementedException(), //cha_sample_m
		1 => throw new NotImplementedException(), //cha_sample_f
		3 => throw new NotImplementedException(), //init_mind_param
		5 => throw new NotImplementedException(), //cha_sample_voice
		6 => throw new NotImplementedException(), //mole_layout
		7 => throw new NotImplementedException(), //facepaint_layout
		8 => throw new NotImplementedException(), //bodypaint_layout
		110 => throw new NotImplementedException(), //mo_head
		111 => throw new NotImplementedException(), //mt_skin_f
		112 => throw new NotImplementedException(), //mt_detail_f
		121 => throw new NotImplementedException(), //mt_beard
		131 => throw new NotImplementedException(), //mt_skin_b
		132 => throw new NotImplementedException(), //mt_detail_b
		133 => throw new NotImplementedException(), //mt_sunburn
		140 => throw new NotImplementedException(), //mo_top
		141 => throw new NotImplementedException(), //mo_bot
		144 => throw new NotImplementedException(), //mo_gloves
		147 => throw new NotImplementedException(), //mo_shoes
		210 => GetFriendlyFemaleFaceContourName(itemID),
		211 => GetFriendlyFemaleFaceSkinName(itemID),
		212 => GetFriendlyFemaleFaceWrinklesName(itemID),
		350 => "None", // The "none" accessory type
		351 => GetFriendlyHeadAccesoryName(itemID),
		//_ => throw new ArgumentException("Unknown category ID")
		_ => $"Unknown category ID {categoryID}, item ID {itemID}"
	};
	//cha_sample_m = 0
	//cha_sample_f = 1,
	//init_mind_param = 3
	//cha_sample_voice = 5
	//mole_layout = 6 0-7
	//facepaint_layout = 7 0-5
	//bodypaint_layout = 8 0-9
	//mo_head = 110
	//mo_top = 140
	//mo_bot = 141
	//mo_gloves = 144
	//mo_shoes = 147


	//so_hair_b = 300 0-3, 16, 4-10, 17, 11-15, 18-29, 50-68
	//so_hair_f = 301 0-24, 50-64
	//so_hair_s = 302 0-7
	//so_hair_o = 303 0-7
	//preset_hair_color = 305 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//st_hairmeshptn = 306 0-11 "Type n"
	//preset_skin_color = 336 0-19
	//st_pattern = 348 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//custom_pose_m = 500
	//custom_pose_f = 501 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//custom_eyebrow_m = 502
	//custom_eyebrow_f = 503
	//custom_eye_m = 504
	//custom_eye_f = 505
	//custom_mouth_m = 506
	//custom_mouth_f = 507
}
