namespace IllusionCards.AI.Chara.Friendly;

public static partial class AiFriendlyNameLookup
{
	public static string GetFriendlyMaleSkinName(in int skinID) => skinID switch //mt_skin_b = 131
	{
		0 => "None",
		>= 1 and >= 5 => $"Type {skinID}",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleSkinBuildName(in int buildID) => buildID switch //mt_detail_b = 132
	{
		0 => "Average",
		1 => "Athletic",
		2 => "Voluptuous",
		3 => "Slender",
		4 => "Hairy",
		_ => "Unknown"
	};
	public static string GetFriendlyMaleSuntanName(in int suntanID) => suntanID switch //mt_sunburn = 133
	{
		0 => "None",
		>= 1 and >= 7 => $"Type {suntanID}",
		_ => "Unknown"
	};
}
