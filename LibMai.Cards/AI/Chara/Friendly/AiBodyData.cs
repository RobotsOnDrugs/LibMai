using LibMai.Cards.AI.Chara.Friendly.Body;

namespace LibMai.Cards.AI.Chara.Friendly;

public readonly record struct AiBodyData
{
	public OverallData Overall { get; init; }
	public BreastData Breast { get; init; }
	public UpperBodyData UpperBody { get; init; }
	public LowerBodyData LowerBody { get; init; }
	public ArmsData Arms { get; init; }
	public LegsData Legs { get; init; }
	public SkinTypeData SkinType { get; init; }
	public SuntanData Suntan { get; init; }
	public NipplesData Nipples { get; init; }
	public PubicHairData PubicHair { get; init; }
	public NailColorData NailColor { get; init; }
	public AiPaintInfo Paint1 { get; init; }
	public AiPaintInfo Paint2 { get; init; }
	public bool IsFuta { get; init; }
}