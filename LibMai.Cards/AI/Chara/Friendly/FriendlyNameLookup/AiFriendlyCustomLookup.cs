namespace LibMai.Cards.AI.Chara.Friendly.FriendlyNameLookup;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMaleCustomPoseName(in int itemID) => itemID switch // 500 custom_pose_m
	{
		0 => "Mannequin",
		>= 1 and <= 7 => $"Pose {itemID}",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleCustomPoseName(in int itemID) => itemID switch // 501 custom_pose_f
	{
		0 => "Mannequin",
		>= 1 and <= 24 => $"Pose {itemID}",
		25 => "0",
		26 => "0",
		27 => "0",
		28 => "0",
		29 => "0",
		30 => "0",
		31 => "0",
		32 => "0",
		33 => "0",
		34 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleCustomEyebrowName(in int itemID) => itemID switch // 502 custom_eyebrow_m
	{
		(>= 0 and <= 6) or 10 or 11 or 14 or 15 => $"{itemID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleCustomEyebrowName(in int itemID) => itemID switch // 503 custom_eyebrow_f
	{
		(>= 0 and <= 3) or 5 or 6 or 10 or 11 or 14 or 15 => $"{itemID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyCustomEyeName(in int itemID) => itemID switch // 504 custom_eye_m, 505 custom_eye_f
	{
		(>= 0 and <= 2) or (>= 7 and <= 9) or (>= 11 and <= 13) => $"{itemID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyCustomMouthName(in int itemID) => itemID switch // 506 custom_mouth_m, 507 custom_mouth_f
	{
		(>= 0 and <= 9) or 12 or (>= 17 and <= 23) => itemID.ToString(),
		_ => "Unknown"
	};
}
