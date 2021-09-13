namespace IllusionCards.AI.Chara.Friendly;

public readonly record struct AiCharaStatusData // Status
{
	public Version Version { get; init; } = null!;
	//public byte[] clothesState { get; init; } = null!;
	public ClothingState Top { get; init; }
	public ClothingState Bottom { get; init; }
	public ClothingState InnerTop { get; init; }
	public ClothingState InnerBottom { get; init; }
	public ClothingState Pantyhose { get; init; }
	public ClothingState Gloves { get; init; }
	public ClothingState Socks { get; init; }
	public ClothingState Shoes { get; init; }
	public ImmutableArray<bool> AccessoryIsVisible { get; init; }
	public int EyebrowPosition { get; init; }
	public float EyebrowOpenMax { get; init; }
	public int EyesPosition { get; init; }
	public float EyesMaximumOpenAmount { get; init; }
	public bool BlinkingEnabled { get; init; }
	public bool eyesYure { get; init; }
	public int MouthPosition { get; init; }
	public float MouthMinimumOpenAmount { get; init; }
	public float MouthMaximumOpenAmount { get; init; }
	public bool MouthIsFixed { get; init; }
	public bool mouthAdjustWidth { get; init; }
	public byte TongueState { get; init; }
	public EyeLookType EyesLookPosition { get; init; }
	public int EyesTargetType { get; init; }
	public float EyesTargetAngle { get; init; }
	public float EyesTargetRange { get; init; }
	public float EyesTargetRate { get; init; }
	public NeckLookType NeckLookPosition { get; init; }
	public int neckTargetType { get; init; }
	public float neckTargetAngle { get; init; }
	public float neckTargetRange { get; init; }
	public float neckTargetRate { get; init; }
	public bool disableMouthShapeMask { get; init; }
	public bool[,] disableBustShapeMask { get; init; } = null!;
	public float NippleStiffness { get; init; }
	public float SkinGloss { get; init; }
	public float BlushingAmount { get; init; }
	public float TearsAmount { get; init; }
	public bool hideEyesHighlight { get; init; }
	public byte[] siruLv { get; init; }
	public float Wetness { get; init; }
	public bool PenisIsVisible { get; init; }
	public bool PenisIsAlwaysVisible { get; init; }
	public bool HeadIsAlwaysVisible { get; init; }
	public bool BodyIsAlwaysVisible { get; init; }
	public bool IsMonochrome { get; init; } // visibleSimple
	public bool visibleGomu { get; init; } // Condom?
	public Color MonochromeColor { get; init; } // simpleColor
	public ImmutableArray<bool> enableShapeHand { get; init; }
	public int[,] shapeHandPtn { get; init; }
	public ImmutableArray<float> shapeHandBlendValue { get; init; }
	public float siriAkaRate { get; init; }
	public enum ClothingState
	{
		None = 0b00,
		Half = 0b01,
		Full = 0b10
	}
	public enum EyeLookType
	{
		NO_LOOK,
		TARGET,
		AWAY,
		FORWARD,
		CONTROL
	}
	public enum NeckLookType
	{
		NO_LOOK,
		TARGET,
		AWAY,
		FORWARD,
		FIX,
		CONTROL
	}
}