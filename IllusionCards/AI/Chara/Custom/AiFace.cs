using System;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiFace
	{
		public Version version { get; set; } = null!;
		public float[] shapeValueFace { get; set; } = null!;
		public int headId { get; set; }
		public int skinId { get; set; }
		public int detailId { get; set; }
		public float detailPower { get; set; }
		public int eyebrowId { get; set; }
		public Color eyebrowColor { get; set; }
		public Vector4 eyebrowLayout { get; set; }
		public float eyebrowTilt { get; set; }
		public EyesInfo[] pupil { get; set; } = null!;
		public bool pupilSameSetting { get; set; }
		public float pupilY { get; set; }
		public int hlId { get; set; }
		public Color hlColor { get; set; }
		public Vector4 hlLayout { get; set; }
		public float hlTilt { get; set; }
		public float whiteShadowScale { get; set; }
		public int eyelashesId { get; set; }
		public Color eyelashesColor { get; set; }
		public int moleId { get; set; }
		public Color moleColor { get; set; }
		public Vector4 moleLayout { get; set; }
		public MakeupInfo makeup { get; set; } = null!;
		public int beardId { get; set; }
		public Color beardColor { get; set; }
		public AiFace() { }
		public object? ExtendedSaveData { get; set; }
	}
}