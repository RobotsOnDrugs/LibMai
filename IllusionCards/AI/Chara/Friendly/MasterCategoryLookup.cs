using IllusionCards.AI.Chara.Friendly.MasterDictionaryLookup;

namespace IllusionCards.AI.Chara.Friendly;

public static class MasterCategoryLookup
{
	private static Dictionary<CategoryIndex, ImmutableDictionary<int, string>> MasterLookupInternal { get; } = new()
	{
		{ CategoryIndex.ao_head, MasterItemDictionaries.HeadAccessoryLookup }
	};
	public static ImmutableDictionary<CategoryIndex, ImmutableDictionary<int, string>> MasterLookup { get; } = MasterLookupInternal.ToImmutableDictionary();
}