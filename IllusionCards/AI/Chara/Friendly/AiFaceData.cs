using IllusionCards.AI.Chara.Friendly.Face;

namespace IllusionCards.AI.Chara.Friendly;

public readonly record struct AiFaceData
{
	public FaceTypeData FaceType { get; init; }
	public OverallData Overall { get; init; }
	public JawData Jaw { get; init; }
	public CheeksData Cheeks { get; init; }
	public EyebrowsData Eyebrows { get; init; }
	public EyeData Eye { get; init; }
	public NoseData Nose { get; init; }
	public MouthData Mouth { get; init; }
	public EarsData Ears { get; init; }
	public MolesData Moles { get; init; }
	public bool SetBothLeftAndRightEyes { get; init; }
	public EyeInfo LeftEye { get; init; }
	public EyeInfo RightEye { get => SetBothLeftAndRightEyes ? LeftEye : RightEye_ ?? throw new NullReferenceException(); }
	internal EyeInfo? RightEye_ { get; init; }
	public IrisData IrisSettings { get; init; }
	public EyeHighlightsData EyeHighlights { get; init; }
	public EyebrowTypeData EyebrowType { get; init; }
	public EyelashTypeData EyelashType { get; init; }
	public EyeshadowData Eyeshadow { get; init; }
	public BlushData Blush { get; init; } // It's called "Cheeks" for both the structure and the makeup, so this is "Blush" to avoid a naming conflict
	public LipstickData Lipstick { get; init; } // "Lipstick" to avoid confusion with structure
	public AiPaintInfo Paint1 { get; init; }
	public AiPaintInfo Paint2 { get; init; }
}