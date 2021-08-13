using System;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{

	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiBody
	{
		public Version version { get; set; } = null!;
		public float[] shapeValueBody { get; set; } = null!;
		public float bustSoftness { get; set; }
		public float bustWeight { get; set; }
		public int skinId { get; set; }
		public int detailId { get; set; }
		public float detailPower { get; set; }
		public Color skinColor { get; set; }
		public float skinGlossPower { get; set; }
		public float skinMetallicPower { get; set; }
		public int sunburnId { get; set; }
		public Color sunburnColor { get; set; }
		public PaintInfo[] paintInfo { get; set; } = null!;
		public int nipId { get; set; }
		public Color nipColor { get; set; }
		public float nipGlossPower { get; set; }
		public float areolaSize { get; set; }
		public int underhairId { get; set; }
		public Color underhairColor { get; set; }
		public Color nailColor { get; set; }
		public float nailGlossPower { get; set; }
		public AiBody() { }
		public object? ExtendedSaveData { get; set; }
	}
}