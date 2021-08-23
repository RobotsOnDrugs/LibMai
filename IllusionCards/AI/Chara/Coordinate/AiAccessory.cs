using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly struct AiAccessory
	{
		public Version version { get; init; } = null!;
		public AccessoryPartsInfo[] parts { get; init; } = null!;
		public object? ExtendedSaveData { get; init; } = null;
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public readonly struct AccessoryPartsInfo
		{
			public int type { get; init; } = 0;
			public int id { get; init; } = 0;
			public string parentKey { get; init; } = null!;
			//public Vector3[,] addMove { get; init; } = null!;
			[IgnoreMember]
			public ImmutableArray<ImmutableArray<Vector3>> addMove { get; init; }
			[Key("addMove")]
			[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Required for MessagePack initialization")]
			private Vector3[,] _addmove { init { addMove = Util.Helpers.GetImmutable2DVector3(ref value); } }
			public ColorInfo[] colorInfo { get; init; } = null!;
			public int hideCategory { get; init; } = 0;
			public int hideTiming { get; init; } = 0;
			public bool noShake { get; init; } = false;
			[IgnoreMember]
			public bool partsOfHead { get; init; } = false;
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