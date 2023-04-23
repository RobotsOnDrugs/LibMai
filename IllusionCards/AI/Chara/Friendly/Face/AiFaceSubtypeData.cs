// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace IllusionCards.AI.Chara.Friendly.Face;

public readonly record struct FaceTypeData
{
	public string Contour { get; init; }
	public string Skin { get; init; }
	public string Wrinkles { get; init; }
}

public readonly record struct OverallData
{
	public float HeadWidth { get; init; }
	public float UpperDepth { get; init; }
	public float UpperHeight { get; init; }
	public float LowerDepth { get; init; }
	public float LowerWidth { get; init; }
}

public readonly record struct JawData
{
	public float JawWidth { get; init; }
	public float JawHeight { get; init; }
	public float JawDepth { get; init; }
	public float JawAngle { get; init; }
	public float NeckDroop { get; init; }
	public float ChinSize { get; init; }
	public float ChinHeight { get; init; }
	public float ChinDepth { get; init; }
}

public readonly record struct CheeksData
{
	public float LowerHeight { get; init; }
	public float LowerDepth { get; init; }
	public float LowerWidth { get; init; }
	public float UpperHeight { get; init; }
	public float UpperDepth { get; init; }
	public float UpperWidth { get; init; }
}

public readonly record struct EyebrowsData
{
	public float Width { get; init; }
	public float Height { get; init; }
	public float PositionX { get; init; }
	public float PositionY { get; init; }
	public float AngleTilt { get; init; }
}

public readonly record struct EyeData
{
	public float Height { get; init; }
	public float Spacing { get; init; }
	public float Depth { get; init; }
	public float Width { get; init; }
	public float VerticalPosition { get; init; }
	public float AngleZ { get; init; }
	public float AngleY { get; init; }
	public float OuterHeight { get; init; }
	public float OuterWidth { get; init; }
	public float InnerHeight { get; init; }
	public float InnerWidth { get; init; }
	public float EyelidShape1 { get; init; }
	public float EyelidShape2 { get; init; }
}

public readonly record struct NoseData
{
	public float NoseHeight { get; init; }
	public float NoseDepth { get; init; }
	public float NoseAngle { get; init; }
	public float NoseSize { get; init; }
	public float BridgeHeight { get; init; }
	public float BridgeWidth { get; init; }
	public float BridgeShape { get; init; }
	public float NostrilWidth { get; init; }
	public float NostrilHeight { get; init; }
	public float NostrilLength { get; init; }
	public float NostrilInnerWidth { get; init; }
	public float NostrilOuterWidth { get; init; }
	public float NoseTipLength { get; init; }
	public float NoseTipHeight { get; init; }
	public float NoseTipSize { get; init; }
}

public readonly record struct MouthData
{
	public float Height { get; init; }
	public float Width { get; init; }
	public float LipThickness { get; init; }
	public float Depth { get; init; }
	public float UpperLipThickness { get; init; }
	public float LowerLipThickness { get; init; }
	public float CornerShape { get; init; }
}

public readonly record struct EarsData
{
	public float Size { get; init; }
	public float Angle { get; init; }
	public float Rotation { get; init; }
	public float UpperEarShape { get; init; }
	public float LowerEarShape { get; init; }
}

public readonly record struct MolesData
{
	// ReSharper disable once InconsistentNaming
	public int ID { get; init; }
	// public string Name => GetFriendlyMoleName(ID);
	public Color Color { get; init; }
	public float Width { get; init; }
	public float Height { get; init; }
	public float PositionX { get; init; }
	public float PositionY { get; init; }
}

// Illusion got "pupil" and "iris" mixed up in their variable names - pupilX refers to the iris and blackX refers to the pupil
// The friendly version here refers to the correct eye parts
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Make it easier to see the switched variable names")]
public readonly record struct EyeInfo
{
	public Color ScleraColor { get; init; }
	public int Iris { get; init; } 
	public Color IrisColor { get; init; }
	public float IrisWidth { get; init; }
	public float IrisHeight { get; init; }
	public float IrisGlow { get; init; }
	public int Pupil { get; init; }
	public Color PupilColor { get; init; }
	public float PupilWidth { get; init; }
	public float PupilHeight { get; init; }
}

public readonly record struct IrisData
{
	public float AdjustHeight { get; init; }
	public float ShadowRange { get; init; }
}

public readonly record struct EyeHighlightsData
{
	public int Type { get; init; }
	public Color Color { get; init; }
	public float Width { get; init; }
	public float Height { get; init; }
	public float PositionX { get; init; }
	public float PositionY { get; init; }
	public float Tilt { get; init; }
}

public readonly record struct EyebrowTypeData : IAiCharacterPartData
{
	public int Type { get; init; }
	public int Category => -1;
	public Color Color { get; init; }
}

public readonly record struct EyelashTypeData
{
	public int Type { get; init; }
	public Color Color { get; init; }
}

public readonly record struct EyeshadowData
{
	public int Type { get; init; }
	public Color Color { get; init; }
	public float Shine { get; init; }
}

public readonly record struct BlushData
{
	public int Type { get; init; }
	public Color Color { get; init; }
	public float Shine { get; init; }
}

public readonly record struct LipstickData
{
	public int Type { get; init; }
	public Color Color { get; init; }
	public float Shine { get; init; }
}