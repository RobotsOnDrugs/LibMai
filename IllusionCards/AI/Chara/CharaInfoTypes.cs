using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record EyesInfo
	{
		public Color whiteColor { get; set; }
		public int pupilId { get; set; }
		public Color pupilColor { get; set; }
		public float pupilW { get; set; }
		public float pupilH { get; set; }
		public float pupilEmission { get; set; }
		public int blackId { get; set; }
		public Color blackColor { get; set; }
		public float blackW { get; set; }
		public float blackH { get; set; }
	}
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record MakeupInfo
	{
		public int eyeshadowId { get; set; }
		public Color eyeshadowColor { get; set; }
		public float eyeshadowGloss { get; set; }
		public int cheekId { get; set; }
		public Color cheekColor { get; set; }
		public float cheekGloss { get; set; }
		public int lipId { get; set; }
		public Color lipColor { get; set; }
		public float lipGloss { get; set; }
		public PaintInfo[] paintInfo { get; set; } = null!;
	}
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record PaintInfo
	{
		public int id { get; set; }
		public Color color { get; set; }
		public float glossPower { get; set; }
		public float metallicPower { get; set; }
		public int layoutId { get; set; }
		public Vector4 layout { get; set; }
		public float rotation { get; set; }
	}
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public class PartsInfo
	{
		public int id { get; set; }
		public Color baseColor { get; set; }
		public Color topColor { get; set; }
		public Color underColor { get; set; }
		public Color specular { get; set; }
		public float metallic { get; set; }
		public float smoothness { get; set; }
		public ColorInfo[] acsColorInfo { get; set; } = null!;
		public int bundleId { get; set; }
		public Dictionary<int, BundleInfo> dictBundle { get; set; } = null!;
		public int meshType { get; set; }
		public Color meshColor { get; set; }
		public Vector4 meshLayout { get; set; }
		public PartsInfo() { }
		public object? ExtendedSaveData { get; set; }
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public class BundleInfo
		{
			public Vector3 moveRate { get; set; }
			public Vector3 rotRate { get; set; }
			public bool noShake { get; set; }
			public BundleInfo() { }
			public object ExtendedSaveData { get; set; } = null!;
		}
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public record ColorInfo
		{
			public Color color { get; set; }
			public ColorInfo() { }
			public object ExtendedSaveData { get; set; } = null!;
		}
	}
}
