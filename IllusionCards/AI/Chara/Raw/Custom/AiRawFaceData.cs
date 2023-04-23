// ReSharper disable UnassignedGetOnlyAutoProperty - Properties are assigned by MessagePack

#pragma warning disable CS8618 // Get-only properties are assigned by MessagePack and have to be null-checked later anyway

namespace IllusionCards.AI.Chara.Raw.Custom;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawFaceData
{
	public Version version { get; }
	public float[] shapeValueFace { get; }
	public int headId { get; }
	public int skinId { get; }
	public int detailId { get; }
	public float detailPower { get; init; }
	public int eyebrowId { get; }
	public Color eyebrowColor { get; }
	public Vector4 eyebrowLayout { get; }
	public float eyebrowTilt { get; }
	public EyesInfo[] pupil { get; }

	public bool pupilSameSetting { get; }
	public float pupilY { get; }
	public int hlId { get; }
	public Color hlColor { get; }
	public Vector4 hlLayout { get; }
	public float hlTilt { get; }
	public float whiteShadowScale { get; }
	public int eyelashesId { get; }
	public Color eyelashesColor { get; }
	public int moleId { get; }
	public Color moleColor { get; init; }
	public Vector4 moleLayout { get; }
	public MakeupInfo makeup { get; }
	public int beardId { get; init; }
	public Color beardColor { get; init; }
	
	[MessagePackObject(true)]
	public readonly record struct EyesInfo
	{
		public Color whiteColor { get; }
		public int pupilId { get; }
		public Color pupilColor { get; }
		public float pupilW { get; }
		public float pupilH { get; }
		public float pupilEmission { get; }
		public int blackId { get; }
		public Color blackColor { get; }
		public float blackW { get; }
		public float blackH { get; }
	}
	
	[MessagePackObject(true)]
	public readonly record struct MakeupInfo
	{
		public int eyeshadowId { get; }
		public Color eyeshadowColor { get; }
		public float eyeshadowGloss { get; }
		public int cheekId { get; }
		public Color cheekColor { get; }
		public float cheekGloss { get; }
		public int lipId { get; }
		public Color lipColor { get; }
		public float lipGloss { get; }
		
		[Key("paintInfo")]
		private AiRawPaintInfo[] _paintInfo { init => paintInfo = value.ToImmutableArray(); }
		
		public ImmutableArray<AiRawPaintInfo> paintInfo { get; private init; }
	}
}