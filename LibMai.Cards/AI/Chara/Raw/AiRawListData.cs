namespace LibMai.Cards.AI.Chara.Raw;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public class AiRawListData
{
	public AiRawListData()
	{
		mark = string.Empty;
		categoryNo = 0;
		distributionNo = 0;
		filePath = string.Empty;
		lstKey = new List<string>();
		dictList = new Dictionary<int, List<string>>();
	}
	public string mark { get; set; }
	public int categoryNo { get; set; }
	public int distributionNo { get; set; }
	public string filePath { get; set; }
	public List<string> lstKey { get; set; }
	public Dictionary<int, List<string>> dictList { get; set; }
}
public enum CategoryIndex
{
	unknown = -1,
	cha_sample_m,
	cha_sample_f,
	init_type_param = 3,
	init_wish_param,
	cha_sample_voice,
	mole_layout,
	facepaint_layout,
	bodypaint_layout,
	mo_head = 110,
	mt_skin_f,
	mt_detail_f,
	mt_beard = 121,
	mt_skin_b = 131,
	mt_detail_b,
	mt_sunburn,
	mo_top = 140,
	mo_bot,
	mo_gloves = 144,
	mo_shoes = 147,
	fo_head = 210,
	ft_skin_f,
	ft_detail_f,
	ft_skin_b = 231,
	ft_detail_b,
	ft_sunburn,
	fo_top = 240,
	fo_bot,
	fo_inner_t,
	fo_inner_b,
	fo_gloves,
	fo_panst,
	fo_socks,
	fo_shoes,
	so_hair_b = 300,
	so_hair_f,
	so_hair_s,
	so_hair_o,
	preset_hair_color = 305,
	st_paint = 313,
	st_eyebrow,
	st_eyelash,
	st_eyeshadow,
	st_eye,
	st_eyeblack,
	st_eye_hl,
	st_cheek,
	st_lip = 322,
	st_mole,
	st_nip = 334,
	st_underhair,
	preset_skin_color,
	st_pattern = 348,
	ao_none = 350,
	ao_head,
	ao_ear,
	ao_glasses,
	ao_face,
	ao_neck,
	ao_shoulder,
	ao_chest,
	ao_waist,
	ao_back,
	ao_arm,
	ao_hand,
	ao_leg,
	ao_kokan,
	custom_pose_m = 500,
	custom_pose_f,
	custom_eyebrow_m,
	custom_eyebrow_f,
	custom_eye_m,
	custom_eye_f,
	custom_mouth_m,
	custom_mouth_f
}