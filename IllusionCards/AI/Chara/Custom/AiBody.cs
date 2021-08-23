using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{

	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly struct AiBody
	{
		public Version version { get; init; } = null!;
		[Key("shapeValueBody")]
		[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Required for MessagePack initialization")]
		private float[] _shapeValueBody { init { shapeValueBody = value.ToImmutableArray(); } }
		public ImmutableArray<float> shapeValueBody { get; init; }
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
		[Key("paintInfo")]
		[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Required for MessagePack initialization")]
		private PaintInfo[] _paintInfo { init { paintInfo = value.ToImmutableArray(); } }
		public ImmutableArray<PaintInfo> paintInfo { get; init; }
		public int nipId { get; init; }
		public Color nipColor { get; init; }
		public float nipGlossPower { get; init; }
		public float areolaSize { get; init; }
		public int underhairId { get; init; }
		public Color underhairColor { get; init; }
		public Color nailColor { get; init; }
		public float nailGlossPower { get; init; }
		public object? ExtendedSaveData { get; init; }
	}
}