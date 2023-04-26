using LibMai.Cards.AI.Chara.Friendly.Hair;

namespace LibMai.Cards.AI.Chara.Friendly;

public readonly record struct AiHairData
{
	public bool MatchBackHairAndBangs { get; init; }
	public bool AutoSetRootAndTipColors { get; init; }
	public bool MatchHairAxisSettings { get; init; }
	public HairSettingsData BackHair { get; init; }
	public HairSettingsData Bangs { get; init; }
	public HairSettingsData SideHair { get; init; }
	public HairSettingsData HairExtensions { get; init; }
	public HairRenderType RenderType { get; init; }
}