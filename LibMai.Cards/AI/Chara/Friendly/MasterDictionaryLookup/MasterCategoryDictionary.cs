namespace LibMai.Cards.AI.Chara.Friendly.MasterDictionaryLookup;

public static class MasterCategoryDictionary
{
	/// <summary>
	/// Returns the name of the item in a given category.
	/// </summary>
	/// <param name="category_index">The category index.</param>
	/// <param name="item_index">The ID of the item to look up.</param>
	/// <returns></returns>
	public static string GetFriendlyItemName(CategoryIndex category_index, int item_index) => MasterLookup[category_index][item_index];

	private static Dictionary<CategoryIndex, ImmutableDictionary<int, string>> MasterLookupInternal { get; } = new()
	{
		// { CategoryIndex.unknown, null },
		{ CategoryIndex.ao_head, MasterItemDictionaries.HeadAccessories },
		{ CategoryIndex.ao_ear, MasterItemDictionaries.Earrings },
		{ CategoryIndex.ao_glasses, MasterItemDictionaries.Glasses },
		{ CategoryIndex.ao_face, MasterItemDictionaries.FaceAccessories },
		{ CategoryIndex.ao_neck, MasterItemDictionaries.NeckAccessories },
		{ CategoryIndex.ao_shoulder, MasterItemDictionaries.ShoulderAccessories },
		{ CategoryIndex.ao_chest, MasterItemDictionaries.BreastAccessories },
		{ CategoryIndex.ao_waist, MasterItemDictionaries.WaistAccessories },
		{ CategoryIndex.ao_back, MasterItemDictionaries.BackAccessories },
		{ CategoryIndex.ao_arm, MasterItemDictionaries.ArmAccessories },
		{ CategoryIndex.ao_hand, MasterItemDictionaries.HandAccessories },
		{ CategoryIndex.ao_leg, MasterItemDictionaries.LegAccessories },
		{ CategoryIndex.ao_kokan, MasterItemDictionaries.CrotchAccessories }
	};
	
	/// <summary>
	/// The master dictionary containing the names of all vanilla items.
	/// </summary>
	public static ImmutableDictionary<CategoryIndex, ImmutableDictionary<int, string>> MasterLookup { get; } = MasterLookupInternal.ToImmutableDictionary();

	private const string ph = "<not implemented>";
	public static string GetFriendlyCategoryName(CategoryIndex index) => index switch
	{
		CategoryIndex.unknown => "Unknown",
		CategoryIndex.cha_sample_m => ph,
		CategoryIndex.cha_sample_f => ph,
		CategoryIndex.init_type_param => ph,
		CategoryIndex.init_wish_param => ph,
		CategoryIndex.cha_sample_voice => ph,
		CategoryIndex.mole_layout => "Mole Layout",
		CategoryIndex.facepaint_layout => "Facepaint Layout",
		CategoryIndex.bodypaint_layout => "Bodypaint Layout",
		CategoryIndex.mo_head => ph,
		CategoryIndex.mt_skin_f => ph,
		CategoryIndex.mt_detail_f => ph,
		CategoryIndex.mt_beard => ph,
		CategoryIndex.mt_skin_b => ph,
		CategoryIndex.mt_detail_b => ph,
		CategoryIndex.mt_sunburn => ph,
		CategoryIndex.mo_top => "Male Tops",
		CategoryIndex.mo_bot => "Male Bottoms",
		CategoryIndex.mo_gloves => "Male Gloves",
		CategoryIndex.mo_shoes => "Male Shoes",
		CategoryIndex.fo_head => ph,
		CategoryIndex.ft_skin_f => ph,
		CategoryIndex.ft_detail_f => ph,
		CategoryIndex.ft_skin_b => ph,
		CategoryIndex.ft_detail_b => ph,
		CategoryIndex.ft_sunburn => ph,
		CategoryIndex.fo_top => "Female Tops",
		CategoryIndex.fo_bot => "Female Bottoms",
		CategoryIndex.fo_inner_t => "Bras",
		CategoryIndex.fo_inner_b => ph,
		CategoryIndex.fo_gloves => "Female Gloves",
		CategoryIndex.fo_panst => ph,
		CategoryIndex.fo_socks => "Female Socks",
		CategoryIndex.fo_shoes => "Female Shoes",
		CategoryIndex.so_hair_b => "Back Hair",
		CategoryIndex.so_hair_f => "Front Hair",
		CategoryIndex.so_hair_s => "Side Hair",
		CategoryIndex.so_hair_o => ph,
		CategoryIndex.preset_hair_color => ph,
		CategoryIndex.st_paint => "Body Paint",
		CategoryIndex.st_eyebrow => "Eyebrows",
		CategoryIndex.st_eyelash => "Eyelashes",
		CategoryIndex.st_eyeshadow => "Eyeshadows",
		CategoryIndex.st_eye => "Eyes",
		CategoryIndex.st_eyeblack => ph,
		CategoryIndex.st_eye_hl => ph,
		CategoryIndex.st_cheek => ph,
		CategoryIndex.st_lip => ph,
		CategoryIndex.st_mole => ph,
		CategoryIndex.st_nip => ph,
		CategoryIndex.st_underhair => ph,
		CategoryIndex.preset_skin_color => ph,
		CategoryIndex.st_pattern => ph,
		CategoryIndex.ao_none => "No Accessories",
		CategoryIndex.ao_head => "Head Accessories",
		CategoryIndex.ao_ear => "Earrings",
		CategoryIndex.ao_glasses => "Glasses",
		CategoryIndex.ao_face => "Face Accessories",
		CategoryIndex.ao_neck => "Neck Accessories",
		CategoryIndex.ao_shoulder => "Shoulder Accessories",
		CategoryIndex.ao_chest => "Breast Accessories",
		CategoryIndex.ao_waist => "Waist Accessories",
		CategoryIndex.ao_back => "Back Accessories",
		CategoryIndex.ao_arm => "Arm Accessories",
		CategoryIndex.ao_hand => "Hand Accessories",
		CategoryIndex.ao_leg => "Leg Accessories",
		CategoryIndex.ao_kokan => "Crotch Accessories",
		CategoryIndex.custom_pose_m => ph,
		CategoryIndex.custom_pose_f => ph,
		CategoryIndex.custom_eyebrow_m => ph,
		CategoryIndex.custom_eyebrow_f => ph,
		CategoryIndex.custom_eye_m => ph,
		CategoryIndex.custom_eye_f => ph,
		CategoryIndex.custom_mouth_m => ph,
		CategoryIndex.custom_mouth_f => ph,
		_ => throw new ArgumentException("Invalid category index.")
	};
}