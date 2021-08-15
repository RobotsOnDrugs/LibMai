using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{

	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiBody
	{
		public Version version { get; init; } = null!;
		public float[] shapeValueBody { get; init; } = null!;
		public float bustSoftness { get; init; }
		public float bustWeight { get; init; }
		public int skinId { get; init; }
		public int detailId { get; init; }
		public float detailPower { get; init; }
		public Color skinColor { get; init; }
		public float skinGlossPower { get; init; }
		public float skinMetallicPower { get; init; }
		public int sunburnId { get; init; }
		public Color sunburnColor { get; init; }
		public PaintInfo[] paintInfo { get; init; } = null!;
		public int nipId { get; init; }
		public Color nipColor { get; init; }
		public float nipGlossPower { get; init; }
		public float areolaSize { get; init; }
		public int underhairId { get; init; }
		public Color underhairColor { get; init; }
		public Color nailColor { get; init; }
		public float nailGlossPower { get; init; }
		public AiBody() { }
		public object? ExtendedSaveData { get; init; }
	}
}