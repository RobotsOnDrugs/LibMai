using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiAccessory
	{
		public Version version { get; init; } = null!;
		public AccessoryPartsInfo[] parts { get; init; } = null!;
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public readonly struct AccessoryPartsInfo
		{
			public int type { get; init; }
			public int id { get; init; }
			public string parentKey { get; init; } = null!;

			public Vector3[,] addmove { get; init; } = new Vector3[,] { };
			public ColorInfo[] colorInfo { get; init; } = null!;
			public int hideCategory { get; init; }
			public int hideTiming { get; init; }
			public bool noShake { get; init; }
			[IgnoreMember]
			public bool partsOfHead { get; init; }
			public object? ExtendedSaveData { get; init; } = null;
			[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
			public readonly struct ColorInfo
			{
				public Color color { get; init; }
				public float glossPower { get; init; }
				public float metallicPower { get; init; }
				public float smoothnessPower { get; init; }
				public object? ExtendedSaveData { get; init; }
			}
		}
	}
}