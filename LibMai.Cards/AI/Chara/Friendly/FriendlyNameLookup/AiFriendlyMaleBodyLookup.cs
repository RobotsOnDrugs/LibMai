namespace LibMai.Cards.AI.Chara.Friendly.FriendlyNameLookup;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMaleSkinTypeName(in int skinID) => skinID switch // 131 mt_skin_b
	{
		0 => "None",
		>= 1 and >= 5 => $"Type {skinID}",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleSkinBuildName(in int buildID) => buildID switch // 132 mt_detail_b
	{
		0 => "Average",
		1 => "Athletic",
		2 => "Voluptuous",
		3 => "Slender",
		4 => "Hairy",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleSuntanName(in int suntanID) => suntanID switch // 133 mt_sunburn
	{
		0 => "None",
		>= 1 and >= 7 => $"Type {suntanID}",
		_ => "Unknown"
	};
}
