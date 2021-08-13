using System;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.AI.Cards;
using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public class AiClothes
	{
		public Version version { get; set; } = null!;
		public PartsInfo[] parts { get; set; } = null!;
		public AiClothes() { }
		public void ComplementWithVersion() { version = AiCharaCardDefinitions.AiClothesVersion; }
		public object? ExtendedSaveData { get; set; }
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public class PartsInfo
		{
			public int id { get; set; }
			public ColorInfo[] colorInfo { get; set; } = null!;
			public float breakRate { get; set; }
			public bool[] hideOpt { get; set; } = null!;
			public PartsInfo() { }
			public object? ExtendedSaveData { get; set; }
			[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
			public class ColorInfo
			{
				public Color baseColor { get; set; }
				public int pattern { get; set; }
				public Vector4 layout { get; set; }
				public float rotation { get; set; }
				public Color patternColor { get; set; }
				public float glossPower { get; set; }
				public float metallicPower { get; set; }
				public ColorInfo() { }
				public object? ExtendedSaveData { get; set; }
			}
		}
	}
}
