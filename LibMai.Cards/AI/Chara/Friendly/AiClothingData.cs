using LibMai.Cards.AI.Chara.Friendly.Clothing;

namespace LibMai.Cards.AI.Chara.Friendly;

public readonly record struct AiClothingData
{
	public AiClothingSettingsData Top { get; init; }
	public AiClothingSettingsData Bottom { get; init; }
	public AiClothingSettingsData InnerTop { get; init; }
	public AiClothingSettingsData InnerBottom { get; init; }
	public AiClothingSettingsData Gloves { get; init; }
	public AiClothingSettingsData Pantyhose { get; init; }
	public AiClothingSettingsData Socks { get; init; }
	public AiClothingSettingsData Shoes { get; init; }
}