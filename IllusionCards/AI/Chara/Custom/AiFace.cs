using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiFace
	{
		public Version version { get; init; } = null!;
		public float[] shapeValueFace { get; init; } = null!;
		public int headId { get; init; }
		public int skinId { get; init; }
		public int detailId { get; init; }
		public float detailPower { get; init; }
		public int eyebrowId { get; init; }
		public Color eyebrowColor { get; init; }
		public Vector4 eyebrowLayout { get; init; }
		public float eyebrowTilt { get; init; }
		public EyesInfo[] pupil { get; init; } = null!;
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
		public MakeupInfo makeup { get; init; } = null!;
		public int beardId { get; init; }
		public Color beardColor { get; init; }
		public AiFace() { }
		public object? ExtendedSaveData { get; init; }
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public record EyesInfo
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
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public record MakeupInfo
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
			public PaintInfo[] paintInfo { get; init; } = null!;
		}
	}
}