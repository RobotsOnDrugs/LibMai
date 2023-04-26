namespace LibMai.Cards.AI.Chara.Friendly.FriendlyNameLookup;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyFemaleFaceContourName(in int headID) => headID switch //fo_head = 210
	{
		0 => "Type 1",
		1 => "Type 2",
		2 => "Type 3",
		3 => "Type 4",
		_ => "Unknown",
	};
	public static string GetFriendlyFemaleFaceSkinName(in int skinID) => skinID switch //ft_skin_f = 211
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
	public static string GetFriendlyFemaleFaceWrinklesName(in int itemID) => itemID switch // 212 ft_detail_f
	{
		0 => "None",
		1 => "Laugh Lines",
		2 => "Crow's Feet",
		3 => "Mouth Lines",
		4 => "Face 1",
		5 => "Face 2",
		12 => "Gaunt Cheeks",
		13 => "Full Cheeks",
		6 => "Eye Effect 1",
		7 => "Eye Effect 2",
		14 => "Eye Effect 3",
		15 => "Eye Effect 4",
		16 => "Eye Effect 5",
		17 => "Eye Effect 6",
		18 => "Eye Effect 7",
		8 => "Lip Emphasis",
		9 => "Bone Structure 1",
		10 => "Bone Structure 2",
		11 => "Bone Structure 3",
		_ => "Unknown"
	};
}
