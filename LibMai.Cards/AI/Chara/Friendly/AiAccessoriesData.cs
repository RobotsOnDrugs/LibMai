namespace LibMai.Cards.AI.Chara.Friendly;

public readonly record struct AiAccessoriesData
{
	public Version Version { get; init; }
	public ImmutableArray<AiAccessoryData> Accessories { get; init; }
}

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Use MessagePack convention")]
public readonly record struct AiAccessoryData
{
	public AiAccessoryData() { }
	public AiAccessoryType AccessoryType { get; init; }
	public int ID { get; init; }
	public string Name { get; init; } = null!;
	public AiAccessoryParent Parent { get; init; }
	//public Vector3[,] addmove { get; init; } = new Vector3[,] { };
	public ImmutableArray<AiAccessoryAdjustmentData> Adjustments { get; init; }
	public ImmutableArray<AiAccessoryColorInfo> ColorInfos { get; init; }
	public int hideCategory { get; init; } // Always 0?
	public int hideTiming { get; init; } // Always 1?
	public bool IsRigid { get; init; }
}

public enum AiAccessoryType
{
	None = 350,
	Head = 351,
	Ear = 352,
	Glasses = 353,
	Face = 354,
	Neck = 355,
	Shoulder = 356,
	Chest = 357,
	Waist = 358,
	Back = 359,
	Arm = 360,
	Hand = 361,
	Leg = 362,
	Crotch = 363
}

public enum AiAccessoryParent
{
	None,
	N_Hair_pony,
	N_Hair_twin_L,
	N_Hair_twin_R,
	N_Hair_pin_L,
	N_Hair_pin_R,
	N_Head_top,
	N_Hitai,
	N_Head,
	N_Face,
	N_Earring_L,
	N_Earring_R,
	N_Megane,
	N_Nose,
	N_Mouth,
	N_Neck,
	N_Chest_f,
	N_Chest,
	N_Tikubi_L,
	N_Tikubi_R,
	N_Back,
	N_Back_L,
	N_Back_R,
	N_Waist,
	N_Waist_f,
	N_Waist_b,
	N_Waist_L,
	N_Waist_R,
	N_Leg_L,
	N_Knee_L,
	N_Ankle_L,
	N_Foot_L,
	N_Leg_R,
	N_Knee_R,
	N_Ankle_R,
	N_Foot_R,
	N_Shoulder_L,
	N_Elbo_L,
	N_Arm_L,
	N_Wrist_L,
	N_Shoulder_R,
	N_Elbo_R,
	N_Arm_R,
	N_Wrist_R,
	N_Hand_L,
	N_Index_L,
	N_Middle_L,
	N_Ring_L,
	N_Hand_R,
	N_Index_R,
	N_Middle_R,
	N_Ring_R,
	N_Dan,
	N_Kokan,
	N_Ana
}
public readonly record struct AiAccessoryColorInfo
{
	public Color Color { get; init; }
	public float Shine { get; init; }
	public float Texture { get; init; }
	public float Smoothness { get; init; }
}

public readonly record struct AiAccessoryAdjustmentData
{
	public Vector3 Position { get; init; }
	public Vector3 Rotation { get; init; }
	public Vector3 Scale { get; init; }
}