namespace LibMai.Cards.AI.Chara.Friendly;

public interface IAiCharacterPartData
{
	public int Category { get; }
	public int Type { get; init; }
	// public string Name => GetFriendlyNameByCategoryID(Category, Type);
}
