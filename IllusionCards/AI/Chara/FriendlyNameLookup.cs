namespace IllusionCards.AI.Chara;

record FriendlyNameLookup
{
	//cha_sample_m = 0
	//cha_sample_f = 1,
	//init_mind_param = 3
	//cha_sample_voice = 5
	//mole_layout = 6 0-7
	//facepaint_layout = 7 0-5
	//bodypaint_layout = 8 0-9
	//mo_head = 110
	//mt_skin_f = 111
	//mt_detail_f = 112
	//mt_beard = 121
	//mt_skin_b = 131
	//mt_detail_b = 132
	//mt_sunburn = 133
	//mo_top = 140
	//mo_bot = 141
	//mo_gloves = 144
	//mo_shoes = 147

	internal static string GetFriendlyFaceContourName(int headID) => headID switch //fo_head = 210
	{
		0 => "Type 1",
		1 => "Type 2",
		2 => "Type 3",
		3 => "Type 4",
		_ => "Unknown",
	};
	internal static string GetFriendlyFaceSkinName(int skinID) => skinID switch //ft_skin_f = 211
	{
		0 or 9 or 20 or 30 => "Type 1",
		1 or 10 or 21 or 31 => "Type 2",
		2 or 11 or 22 or 32 => "Type 3",
		3 or 12 or 23 or 33 => "Type 4",
		4 or 13 or 24 or 34 => "Type 5",
		5 or 14 or 25 or 35 => "Type 6",
		6 or 15 or 26 or 36 => "Type 7",
		7 or 16 or 27 or 37 => "Type 8",
		8 or 17 or 28 or 38 => "Type 9",
		18 or 19 or 29 or 39 => "Type 10",
		40 => "Type 11",
		41 => "Type 12",
		42 => "Type 13",
		43 => "Type 14",
		44 => "Type 15",
		45 => "Type 16",
		46 => "Type 17",
		47 => "Type 18",
		48 => "Type 19",
		_ => "Unknown"
	};
	internal static string GetFriendlyFaceWrinklesName(int detailID) => detailID switch //ft_detail_f = 212
	{
		0 => "None",
		1 => "Laugh Lines",
		2 => "Crow's Feet",
		3 => "Mouth Lines",
		4 => "Face 1",
		5 => "Face 2",
		6 => "Gaunt Cheeks",
		7 => "Full Cheeks",
		8 => "Eye Effect 1",
		9 => "Eye Effect 2",
		10 => "Eye Effect 3",
		11 => "Eye Effect 4",
		12 => "Eye Effect 5",
		13 => "Eye Effect 6",
		14 => "Eye Effect 7",
		15 => "Lip Emphasis",
		16 => "Bone Structure 1",
		17 => "Bone Structure 2",
		18 => "Bone Structure 3",
		_ => "Unknown"
	};

	//ft_skin_b = 231 0-3
	//ft_detail_b = 232 0-4
	//ft_sunburn = 233 0-14
	//fo_top = 240 0-35, 38-51, 200-207, 209-226, 228-229, 208, 227, 230-234, 236-237, 235, 238-246, 249, 248, 247
	//fo_bot = 241 0-16, 19-21, 200-216, 218, 217, 220, 219, 221-224, 227, 225-226
	//fo_inner_t = 242 0-20, 22-28, 200-201, 204-214, 202-203, 215-222, 224, 223, 225
	//fo_inner_b = 243 0-16, 19-21, 200-201, 203-208, 202, 209-214
	//fo_gloves = 244 0-5, 7-10, 200-202, 205-209, 203-204, 210-218
	//fo_panst = 245 0-4, 6, 5, 7-8, 10-17, 200-207
	//fo_socks = 246 0-9, 11-14, 200-202, 204, 206-207, 203, 205, 208-211, 213, 212, 214
	//fo_shoes = 247 0-13, 16-20, 200-204, 206-207, 209-215, 205, 208, 216-217, 227, 218, 220, 219, 221-224, 228, 226, 225
	//so_hair_b = 300 0-3, 16, 4-10, 17, 11-15, 18-29, 50-68
	//so_hair_f = 301 0-24, 50-64
	//so_hair_s = 302 0-7
	//so_hair_o = 303 0-7
	//preset_hair_color = 305 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//st_hairmeshptn = 306 0-11 "Type n"
	//st_paint = 313 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//st_eyebrow = 314 0-26
	//st_eyelash = 315 0-8
	//st_eyeshadow = 316 0-43
	//st_eye = 317 0-29
	//st_eyeblack = 318 0-7
	//st_eye_hl = 319 0-44
	//st_cheek = 320 0-16
	//st_lip = 322 0-18
	//st_mole = 323 0-4
	//st_nip = 334 0-4
	//st_underhair = 335 0-14
	//preset_skin_color = 336 0-19
	//st_pattern = 348 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//ao_none = 350 0 "None"
	//ao_head = 351 0, 3, 32 ,26, 34, 27, 7, 4-6, 38-39, 33, 8-9, 35, 10-11, 13, 12, 14-15, 36-37, 16-25, 40-52, 54-103, 107-112, 53, 104-106, 113-115, 200-203, 205-210, 214-221, 204, 211-213, 222, 226, 225, 227-234, 236, 235, 223-224, 237-238
	//ao_ear = 352 0-8
	//ao_glasses = 353 0-12, 21, 13-20, 22
	//ao_face = 354 0-12, 200-201
	//ao_neck = 355 0-9, 22-23, 10-13, 17, 14-16, 18-21, 24, 26, 32, 25, 27-31, 33, 200-202, 204-212, 203, 213-217, 220, 218-219
	//ao_shoulder = 356 0-11, 202-203, 200-201, 204-205
	//ao_chest = 357 0-7
	//ao_waist = 358 0-4, 7-8, 5, 9, 11-17, 10, 18-20, 200, 204-205, 203, 201-202, 207, 206, 208
	//ao_back = 359 0-1, 3, 2, 4, 6-20
	//ao_arm = 360 0-4, 7-18, 5-6, 19, 200-206
	//ao_hand = 361 0-15, 17-82, 202-205, 200-201, 206-209
	//ao_leg = 362 0-2, 4-11, 200-202
	//ao_kokan = 363 0-2
	//custom_pose_m = 500
	//custom_pose_f = 501 0, 14, 12, 11, 13, 1, 3, 2, 4, 9, 8, 5-7, 10, 15, 17, 16, 18-33, 36, 34-35, 37-42, 47-48, 43-46
	//custom_eyebrow_m = 502
	//custom_eyebrow_f = 503
	//custom_eye_m = 504
	//custom_eye_f = 505
	//custom_mouth_m = 506
	//custom_mouth_f = 507
	internal static string GetFriendlyEyebrowName(int eyebrowID) => eyebrowID switch
	{
		>= 0 and <= 29 => $"Type {eyebrowID + 1}",
		_ => "Unknown"
	};
	internal static string GetFriendlyMoleName(int moleID) => moleID switch
	{
		0 => "None",
		1 => "Mole",
		2 => "Mole 2",
		3 => "Freckles",
		4 => "Freckles 2",
		_ => "Unknown"
	};
	internal static string GetFriendlyPaintName(int paintInfoID) => paintInfoID switch // IDs are in the order they are shown in the (HS2) character maker
	{
		0 => "None",
		14 => "Heart",
		12 => "Star",
		11 => "Crescent Moon",
		13 => "Water Drop",
		1 => "Bandage",
		3 => "Cross",
		2 => "5-Line Cross",
		4 => "Butterfly",
		9 => "Spider",
		8 => "Spiderweb",
		5 => "Forbidden",
		6 => "Yin-Yang",
		7 => "Rose",
		10 => "Kiss",
		15 => "Eye 1",
		17 => "Eye 2",
		16 => "Dirty",
		18 => "Square",
		19 => "Pyramid",
		20 => "Circle",
		21 => "Blurred Circle",
		22 => "Claw Marks",
		23 => "Starburst",
		24 => "Dot Circle",
		25 => "Triangle 1",
		26 => "Triangle 2",
		27 => "Hexagram",
		28 => "Thorns",
		29 => "Flame Moon",
		30 => "Handprint",
		31 => "Cat",
		32 => "Sunburst",
		33 => "Tribal 1",
		36 => "Tribal 2",
		34 => "Flower 1",
		35 => "Flower 2",
		37 => "Single Line",
		38 => "Double Line",
		39 => "Maro Eyebrows",
		40 => "Fox Prints",
		41 => "Crack",
		42 => "Lightning",
		47 => "Anchor",
		48 => "Wave",
		43 => "Cross 1",
		44 => "Cross 2",
		45 => "Flower Moon",
		46 => "Heart 2",
		_ => "Unknown"
	};
	// 350 ao_none has a single item with index 0 and is the "none" thumbnail
}
