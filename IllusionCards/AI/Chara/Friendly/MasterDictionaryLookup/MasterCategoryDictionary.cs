namespace IllusionCards.AI.Chara.Friendly.MasterDictionaryLookup;

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
	
	// // TODO: Look up what all these are
	// // Also TODO: See if Illusion mixed up pupil and iris here
	public static string GetFriendlyCategoryName(CategoryIndex index) => index switch
	{
		CategoryIndex.unknown => "Unknown",
		CategoryIndex.cha_sample_m => string.Empty,
		CategoryIndex.cha_sample_f => string.Empty,
		CategoryIndex.init_type_param => string.Empty,
		CategoryIndex.init_wish_param => string.Empty,
		CategoryIndex.cha_sample_voice => string.Empty,
		CategoryIndex.mole_layout => "Mole Layout",
		CategoryIndex.facepaint_layout => "Facepaint Layout",
		CategoryIndex.bodypaint_layout => "Bodypaint Layout",
		CategoryIndex.mo_head => string.Empty,
		CategoryIndex.mt_skin_f => string.Empty,
		CategoryIndex.mt_detail_f => string.Empty,
		CategoryIndex.mt_beard => string.Empty,
		CategoryIndex.mt_skin_b => string.Empty,
		CategoryIndex.mt_detail_b => string.Empty,
		CategoryIndex.mt_sunburn => string.Empty,
		CategoryIndex.mo_top => "Male Tops",
		CategoryIndex.mo_bot => "Male Bottoms",
		CategoryIndex.mo_gloves => "Male Gloves",
		CategoryIndex.mo_shoes => "Male Shoes",
		CategoryIndex.fo_head => string.Empty,
		CategoryIndex.ft_skin_f => string.Empty,
		CategoryIndex.ft_detail_f => string.Empty,
		CategoryIndex.ft_skin_b => string.Empty,
		CategoryIndex.ft_detail_b => string.Empty,
		CategoryIndex.ft_sunburn => string.Empty,
		CategoryIndex.fo_top => "Female Tops",
		CategoryIndex.fo_bot => "Female Bottoms",
		CategoryIndex.fo_inner_t => "Bras",
		CategoryIndex.fo_inner_b => string.Empty,
		CategoryIndex.fo_gloves => "Female Gloves",
		CategoryIndex.fo_panst => string.Empty,
		CategoryIndex.fo_socks => "Female Socks",
		CategoryIndex.fo_shoes => "Female Shoes",
		CategoryIndex.so_hair_b => "Back Hair",
		CategoryIndex.so_hair_f => "Front Hair",
		CategoryIndex.so_hair_s => "Side Hair",
		CategoryIndex.so_hair_o => string.Empty,
		CategoryIndex.preset_hair_color => string.Empty,
		CategoryIndex.st_paint => "Body Paint",
		CategoryIndex.st_eyebrow => "Eyebrows",
		CategoryIndex.st_eyelash => "Eyelashes",
		CategoryIndex.st_eyeshadow => "Eyeshadows",
		CategoryIndex.st_eye => "Eyes",
		CategoryIndex.st_eyeblack => string.Empty,
		CategoryIndex.st_eye_hl => "",
		CategoryIndex.st_cheek => "",
		CategoryIndex.st_lip => "",
		CategoryIndex.st_mole => "",
		CategoryIndex.st_nip => string.Empty,
		CategoryIndex.st_underhair => "",
		CategoryIndex.preset_skin_color => "",
		CategoryIndex.st_pattern => "",
		CategoryIndex.ao_none => "No Accessories",
		CategoryIndex.ao_head => "Head Accessories",
		CategoryIndex.ao_ear => "Earrings",
		CategoryIndex.ao_glasses => "Glasses",
		CategoryIndex.ao_face => "Face Accessories",
		CategoryIndex.ao_neck => "Neck Accessories",
		CategoryIndex.ao_shoulder => "Shoulder Accessories",
		CategoryIndex.ao_chest => "Breast Accessories",
		CategoryIndex.ao_waist => "Waist  Accessories",
		CategoryIndex.ao_back => "Back Accessories",
		CategoryIndex.ao_arm => "Arm Accessories",
		CategoryIndex.ao_hand => "Hand Accessories",
		CategoryIndex.ao_leg => "Leg Accessories",
		CategoryIndex.ao_kokan => "Crotch Accessories",
		CategoryIndex.custom_pose_m => "",
		CategoryIndex.custom_pose_f => "",
		CategoryIndex.custom_eyebrow_m => "",
		CategoryIndex.custom_eyebrow_f => "",
		CategoryIndex.custom_eye_m => "",
		CategoryIndex.custom_eye_f => "",
		CategoryIndex.custom_mouth_m => "",
		CategoryIndex.custom_mouth_f => "",
		_ => throw new ArgumentException("Invalid category index.")
	};
}