namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyFemaleSkinTypeName(in int itemID) => itemID switch // 231 ft_skin_b
	{
		>= 0 and <= 3 => $"Type {itemID + 1}",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleSkinBuildName(in int itemID) => itemID switch // 232 ft_detail_b
	{
		0 => "Average",
		1 => "Athletic",
		2 => "Voluptuous",
		3 => "Slender",
		4 => "0",
		_ => "Unknown"
	};
	public static string GetFriendlyFemaleSuntanName(in int itemID) => itemID switch // 233 ft_sunburn
	{
		0 => "None",
		1 => "Swimsuit 1",
		2 => "Swimsuit 2",
		3 => "Sporty",
		4 => "School Swimsuit",
		5 => "Bikini",
		6 => "Micro Bikini 1",
		7 => "Micro Bikini 2",
		8 => "Tube Top",
		9 => "Lingerie",
		10 => "Camisole",
		11 => "Athletic",
		12 => "Workout",
		13 => "Natural 1",
		14 => "Natural 2",
		_ => "Unknown"
	};
}
