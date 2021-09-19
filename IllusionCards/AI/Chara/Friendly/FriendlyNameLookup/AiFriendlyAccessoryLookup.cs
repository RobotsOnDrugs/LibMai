﻿namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyHeadAccessoryName(in int accID) => accID switch //ao_head = 351
	{
		0 => "",
		3 => "",
		32 => "",
		26 => "",
		34 => "",
		27 => "",
		7 => "",
		4 => "",
		5 => "",
		6 => "",
		38 => "",
		39 => "",
		33 => "",
		8 => "",
		9 => "",
		35 => "",
		10 => "",
		11 => "",
		13 => "",
		12 => "",
		14 => "",
		15 => "",
		36 => "",
		37 => "",
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
		52 => "",
		54 => "",
		55 => "",
		56 => "",
		57 => "",
		58 => "",
		59 => "",
		60 => "",
		61 => "",
		62 => "",
		63 => "",
		64 => "",
		65 => "",
		66 => "",
		67 => "",
		68 => "",
		69 => "",
		70 => "",
		71 => "",
		72 => "",
		73 => "",
		74 => "",
		75 => "",
		76 => "",
		77 => "",
		78 => "",
		79 => "",
		80 => "",
		81 => "",
		82 => "",
		83 => "",
		84 => "",
		85 => "",
		86 => "",
		87 => "",
		88 => "",
		89 => "",
		90 => "",
		91 => "",
		92 => "",
		93 => "",
		94 => "",
		95 => "",
		96 => "",
		97 => "",
		98 => "",
		99 => "",
		100 => "",
		101 => "",
		102 => "",
		103 => "",
		107 => "",
		108 => "",
		109 => "",
		110 => "",
		111 => "",
		112 => "",
		53 => "",
		104 => "",
		105 => "",
		106 => "",
		113 => "",
		114 => "",
		115 => "",
		200 => "",
		201 => "",
		202 => "",
		203 => "",
		205 => "",
		206 => "",
		207 => "",
		208 => "",
		209 => "",
		210 => "",
		214 => "",
		215 => "",
		216 => "",
		217 => "",
		218 => "",
		219 => "",
		220 => "",
		221 => "",
		204 => "",
		211 => "",
		212 => "",
		213 => "",
		222 => "",
		226 => "",
		225 => "",
		227 => "",
		228 => "",
		229 => "",
		230 => "",
		231 => "",
		232 => "",
		233 => "",
		234 => "",
		236 => "",
		235 => "",
		223 => "",
		224 => "",
		237 => "",
		238 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyEarringName(in int accID) => accID switch //ao_ear = 352 0-8
	{
		0 => "",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyGlassesName(in int accID) => accID switch //ao_glasses = 353 0-12, 21, 13-20, 22
	{
		0 => "",
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
		21 => "",
		13 => "",
		14 => "",
		15 => "",
		16 => "",
		17 => "",
		18 => "",
		19 => "",
		20 => "",
		22 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyFaceAccessoryName(in int accID) => accID switch //ao_face = 354 0-12, 200-201
	{
		0 => "",
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
		200 => "",
		201 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyNeckAccessoryName(in int accID) => accID switch //ao_neck = 355 0-9, 22-23, 10-13, 17, 14-16, 18-21, 24, 26, 32, 25, 27-31, 33, 200-202, 204-212, 203, 213-217, 220, 218-219
	{
		0 => "",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		22 => "",
		23 => "",
		10 => "",
		11 => "",
		12 => "",
		13 => "",
		17 => "",
		14 => "",
		15 => "",
		16 => "",
		18 => "",
		19 => "",
		20 => "",
		21 => "",
		24 => "",
		26 => "",
		32 => "",
		25 => "",
		27 => "",
		28 => "",
		29 => "",
		30 => "",
		31 => "",
		33 => "",
		200 => "",
		201 => "",
		202 => "",
		204 => "",
		205 => "",
		206 => "",
		207 => "",
		208 => "",
		209 => "",
		210 => "",
		211 => "",
		212 => "",
		203 => "",
		213 => "",
		214 => "",
		215 => "",
		216 => "",
		217 => "",
		220 => "",
		218 => "",
		219 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyShoulderAccessoryName(in int accID) => accID switch //ao_shoulder = 356 0-11, 202-203, 200-201, 204-205
	{
		0 => "",
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
		202 => "",
		203 => "",
		200 => "",
		201 => "",
		204 => "",
		205 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyChestAccessoryName(in int accID) => accID switch //ao_chest = 357 0-7
	{
		0 => "",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyWaistAccessoryName(in int accID) => accID switch //ao_waist = 358 0-4, 7-8, 5, 9, 11-17, 10, 18-20, 200, 204-205, 203, 201-202, 207, 206, 208
	{
		0 => "",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
		7 => "",
		8 => "",
		5 => "",
		9 => "",
		11 => "",
		12 => "",
		13 => "",
		14 => "",
		15 => "",
		16 => "",
		17 => "",
		10 => "",
		18 => "",
		19 => "",
		20 => "",
		200 => "",
		204 => "",
		205 => "",
		203 => "",
		201 => "",
		202 => "",
		207 => "",
		206 => "",
		208 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyBackAccessoryName(in int accID) => accID switch //ao_back = 359 0-1, 3, 2, 4, 6-20
	{
		0 => "",
		1 => "",
		3 => "",
		2 => "",
		4 => "",
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
		_ => "Unknown"
	};
	public static string GetFriendlyArmAccessoryName(in int accID) => accID switch //ao_arm = 360 0-4, 7-18, 5-6, 19, 200-206
	{
		0 => "",
		1 => "",
		2 => "",
		3 => "",
		4 => "",
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
		5 => "",
		6 => "",
		19 => "",
		200 => "",
		201 => "",
		202 => "",
		203 => "",
		204 => "",
		205 => "",
		206 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyHandAccessoryName(in int accID) => accID switch //ao_hand = 361 0-15, 17-82, 202-205, 200-201, 206-209
	{
		0 => "",
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
		36 => "",
		37 => "",
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
		52 => "",
		53 => "",
		54 => "",
		55 => "",
		56 => "",
		57 => "",
		58 => "",
		59 => "",
		60 => "",
		61 => "",
		62 => "",
		63 => "",
		64 => "",
		65 => "",
		66 => "",
		67 => "",
		68 => "",
		69 => "",
		70 => "",
		71 => "",
		72 => "",
		73 => "",
		74 => "",
		75 => "",
		76 => "",
		77 => "",
		78 => "",
		79 => "",
		80 => "",
		81 => "",
		82 => "",
		202 => "",
		203 => "",
		204 => "",
		205 => "",
		200 => "",
		201 => "",
		206 => "",
		207 => "",
		208 => "",
		209 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyLegAccessoryName(in int accID) => accID switch //ao_leg = 362 0-2, 4-11, 200-202
	{
		0 => "",
		1 => "",
		2 => "",
		4 => "",
		5 => "",
		6 => "",
		7 => "",
		8 => "",
		9 => "",
		10 => "",
		11 => "",
		200 => "",
		201 => "",
		202 => "",
		_ => "Unknown"
	};
	public static string GetFriendlyCrotchAccessoryName(in int accID) => accID switch //ao_kokan = 363 0-2
	{
		0 => "",
		1 => "",
		2 => "",
		_ => "Unknown"
	};

	public static AiAccessoryParent GetFriendlyAccessoryParent(string parentKey) => parentKey switch
	{
		"" => AiAccessoryParent.None,
		"N_Hair_pony" => AiAccessoryParent.N_Hair_pony,
		"N_Hair_twin_L" => AiAccessoryParent.N_Hair_twin_L,
		"N_Hair_twin_R" => AiAccessoryParent.N_Hair_twin_R,
		"N_Hair_pin_L" => AiAccessoryParent.N_Hair_pin_L,
		"N_Hair_pin_R" => AiAccessoryParent.N_Hair_pin_R,
		"N_Head_top" => AiAccessoryParent.N_Head_top,
		"N_Hitai" => AiAccessoryParent.N_Hitai,
		"N_Head" => AiAccessoryParent.N_Head,
		"N_Face" => AiAccessoryParent.N_Face,
		"N_Earring_L" => AiAccessoryParent.N_Earring_L,
		"N_Earring_R" => AiAccessoryParent.N_Earring_R,
		"N_Megane" => AiAccessoryParent.N_Megane,
		"N_Nose" => AiAccessoryParent.N_Nose,
		"N_Mouth" => AiAccessoryParent.N_Mouth,
		"N_Neck" => AiAccessoryParent.N_Neck,
		"N_Chest_f" => AiAccessoryParent.N_Chest_f,
		"N_Chest" => AiAccessoryParent.N_Chest,
		"N_Tikubi_L" => AiAccessoryParent.N_Tikubi_L,
		"N_Tikubi_R" => AiAccessoryParent.N_Tikubi_R,
		"N_Back" => AiAccessoryParent.N_Back,
		"N_Back_L" => AiAccessoryParent.N_Back_L,
		"N_Back_R" => AiAccessoryParent.N_Back_R,
		"N_Waist" => AiAccessoryParent.N_Waist,
		"N_Waist_f" => AiAccessoryParent.N_Waist_f,
		"N_Waist_b" => AiAccessoryParent.N_Waist_b,
		"N_Waist_L" => AiAccessoryParent.N_Waist_L,
		"N_Waist_R" => AiAccessoryParent.N_Waist_R,
		"N_Leg_L" => AiAccessoryParent.N_Leg_L,
		"N_Knee_L" => AiAccessoryParent.N_Knee_L,
		"N_Ankle_L" => AiAccessoryParent.N_Ankle_L,
		"N_Foot_L" => AiAccessoryParent.N_Foot_L,
		"N_Leg_R" => AiAccessoryParent.N_Leg_R,
		"N_Knee_R" => AiAccessoryParent.N_Knee_R,
		"N_Ankle_R" => AiAccessoryParent.N_Ankle_R,
		"N_Foot_R" => AiAccessoryParent.N_Foot_R,
		"N_Shoulder_L" => AiAccessoryParent.N_Shoulder_L,
		"N_Elbo_L" => AiAccessoryParent.N_Elbo_L,
		"N_Arm_L" => AiAccessoryParent.N_Arm_L,
		"N_Wrist_L" => AiAccessoryParent.N_Wrist_L,
		"N_Shoulder_R" => AiAccessoryParent.N_Shoulder_R,
		"N_Elbo_R" => AiAccessoryParent.N_Elbo_R,
		"N_Arm_R" => AiAccessoryParent.N_Arm_R,
		"N_Wrist_R" => AiAccessoryParent.N_Wrist_R,
		"N_Hand_L" => AiAccessoryParent.N_Hand_L,
		"N_Index_L" => AiAccessoryParent.N_Index_L,
		"N_Middle_L" => AiAccessoryParent.N_Middle_L,
		"N_Ring_L" => AiAccessoryParent.N_Ring_L,
		"N_Hand_R" => AiAccessoryParent.N_Hand_R,
		"N_Index_R" => AiAccessoryParent.N_Index_R,
		"N_Middle_R" => AiAccessoryParent.N_Middle_R,
		"N_Ring_R" => AiAccessoryParent.N_Ring_R,
		"N_Dan" => AiAccessoryParent.N_Dan,
		"N_Kokan" => AiAccessoryParent.N_Kokan,
		"N_Ana" => AiAccessoryParent.N_Ana,
		_ => throw new ArgumentException("Unknown accessory parent key.")
	};
}