namespace IllusionCards.AI.Chara.Raw;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawStatusData
{
	public AiRawStatusData() { }
	public Version version { get; init; } = null!;
	public byte[] clothesState { get; init; } = null!;
	public bool[] showAccessory { get; init; } = null!;
	public int eyebrowPtn { get; init; }
	public float eyebrowOpenMax { get; init; }
	public int eyesPtn { get; init; }
	public float eyesOpenMax { get; init; }
	public bool eyesBlink { get; init; }
	public bool eyesYure { get; init; }
	public int mouthPtn { get; init; }
	public float mouthOpenMin { get; init; }
	public float mouthOpenMax { get; init; }
	public bool mouthFixed { get; init; }
	public bool mouthAdjustWidth { get; init; }
	public byte tongueState { get; init; }
	public int eyesLookPtn { get; init; }
	public int eyesTargetType { get; init; }
	public float eyesTargetAngle { get; init; }
	public float eyesTargetRange { get; init; }
	public float eyesTargetRate { get; init; }
	public int neckLookPtn { get; init; }
	public int neckTargetType { get; init; }
	public float neckTargetAngle { get; init; }
	public float neckTargetRange { get; init; }
	public float neckTargetRate { get; init; }
	public bool disableMouthShapeMask { get; init; }
	public bool[,] disableBustShapeMask { get; init; } = null!;
	public float nipStandRate { get; init; }
	public float skinTuyaRate { get; init; }
	public float hohoAkaRate { get; init; }
	public float tearsRate { get; init; }
	public bool hideEyesHighlight { get; init; }
	public byte[] siruLv { get; init; } = null!;
	public float wetRate { get; init; }
	public bool visibleSon { get; init; }
	public bool visibleSonAlways { get; init; }
	public bool visibleHeadAlways { get; init; }
	public bool visibleBodyAlways { get; init; }
	public bool visibleSimple { get; init; }
	public bool visibleGomu { get; init; }
	public Color simpleColor { get; init; }
	public bool[] enableShapeHand { get; init; } = null!;
	public int[,] shapeHandPtn { get; init; } = null!;
	public float[] shapeHandBlendValue { get; init; } = null!;
	public float siriAkaRate { get; init; }
}
