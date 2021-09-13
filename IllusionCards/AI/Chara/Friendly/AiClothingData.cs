using IllusionCards.AI.Chara.Friendly.Clothing;

namespace IllusionCards.AI.Chara.Friendly;

public readonly record struct AiClothingData
{
	public ClothingSettingsData Top { get; init; }
	public ClothingSettingsData Bottom { get; init; }
	public ClothingSettingsData InnerTop { get; init; }
	public ClothingSettingsData InnerBottom { get; init; }
	public ClothingSettingsData Gloves { get; init; }
	public ClothingSettingsData Pantyhose { get; init; }
	public ClothingSettingsData Socks { get; init; }
	public ClothingSettingsData Shoes { get; init; }
}