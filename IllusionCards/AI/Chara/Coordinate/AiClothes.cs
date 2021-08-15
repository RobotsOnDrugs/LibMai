﻿using System.Diagnostics.CodeAnalysis;

using IllusionCards.AI.Cards;
using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiClothes
	{
		public Version version { get => _version; init => _version = value; }
		private Version _version = null!;
		public PartsInfo[] parts { get; init; } = null!;
		public AiClothes() { }
		internal void ComplementWithVersion() { _version = AiCharaCardDefinitions.AiClothesVersion; }
		public object? ExtendedSaveData { get; init; }
		[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
		public record PartsInfo
		{
			public int id { get; init; }
			public ColorInfo[] colorInfo { get; init; } = null!;
			public float breakRate { get; init; }
			public bool[] hideOpt { get; init; } = null!;
			public PartsInfo() { }
			public object? ExtendedSaveData { get; init; }
			[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
			public record ColorInfo
			{
				public Color baseColor { get; init; }
				public int pattern { get; init; }
				public Vector4 layout { get; init; }
				public float rotation { get; init; }
				public Color patternColor { get; init; }
				public float glossPower { get; init; }
				public float metallicPower { get; init; }
				public ColorInfo() { }
				public object? ExtendedSaveData { get; init; }
			}
		}
	}
}