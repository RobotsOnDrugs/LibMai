// Properties are assigned by MessagePack
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

#pragma warning disable CS8618 // Get-only properties are assigned by MessagePack and have to be null-checked later anyway

namespace IllusionCards.AI.Chara.Raw.Custom;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention.")]
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Uses MessagePack convention.")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "MessagePack requires setters to initialize the values.")]
public readonly record struct AiRawFaceData
{
	public Version version { get; init; }
	public float[] shapeValueFace { get; init; }
	public int headId { get; init; }
	public int skinId { get; init; }
	public int detailId { get; init; }
	public float detailPower { get; init; }
	public int eyebrowId { get; init; }
	public Color eyebrowColor { get; init; }
	public Vector4 eyebrowLayout { get; init; }
	public float eyebrowTilt { get; init; }
	public EyesInfo[] pupil { get; init; }

	public bool pupilSameSetting { get; init; }
	public float pupilY { get; init; }
	public int hlId { get; init; }
	public Color hlColor { get; init; }
	public Vector4 hlLayout { get; init; }
	public float hlTilt { get; init; }
	public float whiteShadowScale { get; init; }
	public int eyelashesId { get; init; }
	public Color eyelashesColor { get; init; }
	public int moleId { get; init; }
	public Color moleColor { get; init; }
	public Vector4 moleLayout { get; init; }
	public MakeupInfo makeup { get; init; }
	public int beardId { get; init; }
	public Color beardColor { get; init; }
	
	[MessagePackObject(true)]
	public readonly record struct EyesInfo
	{
		public Color whiteColor { get; init; }
		public int pupilId { get; init; }
		public Color pupilColor { get; init; }
		public float pupilW { get; init; }
		public float pupilH { get; init; }
		public float pupilEmission { get; init; }
		public int blackId { get; init; }
		public Color blackColor { get; init; }
		public float blackW { get; init; }
		public float blackH { get; init; }
	}
	
	[MessagePackObject(true)]
	public readonly record struct MakeupInfo
	{
		public int eyeshadowId { get; init; }
		public Color eyeshadowColor { get; init; }
		public float eyeshadowGloss { get; init; }
		public int cheekId { get; init; }
		public Color cheekColor { get; init; }
		public float cheekGloss { get; init; }
		public int lipId { get; init; }
		public Color lipColor { get; init; }
		public float lipGloss { get; init; }
		
		[Key("paintInfo")]
		private AiRawPaintInfo[] _paintInfo { init => paintInfo = value.ToImmutableArray(); }
		
		[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "MessagePack cannot initialize the property if the setter is private.")]
		public ImmutableArray<AiRawPaintInfo> paintInfo { get; init; }
	}
}