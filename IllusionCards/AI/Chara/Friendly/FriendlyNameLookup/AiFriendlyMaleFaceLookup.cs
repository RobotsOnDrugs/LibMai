namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMaleFaceContourName(in int headID) => headID switch //mo_head = 110
	{
		0 => "Type 1",
		_ => "Unknown",
	};
	public static string GetFriendlyMaleFaceSkinName(in int skinID) => skinID switch //mt_skin_f = 111
	{
		>= 0 and < 8 => $"Type {skinID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleFaceWrinklesName(in int buildID) => buildID switch //mt_detail_f = 112
	{
		0 => "None",
		1 => "Laugh Lines",
		2 => "Crow's Feet",
		3 => "Mouth Lines",
		4 => "Face 1",
		5 => "Face 2",
		6 => "Gaunt Cheeks",
		7 => "Full Cheeks",
		8 => "Lip Emphasis",
		9 => "Bone Structure 1",
		10 => "Bone Structure 2",
		11 => "Bone Structure 3",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleBeardName(in int beardID) => beardID switch //mt_beard = 121
	{
		0 => "None",
		_ => "Unknown"
	};
}
