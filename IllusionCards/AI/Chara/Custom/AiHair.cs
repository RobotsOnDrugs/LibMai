using System;
using System.Diagnostics.CodeAnalysis;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public record AiHair
	{
		public Version version { get; set; } = null!;
		public bool sameSetting { get; set; }
		public bool autoSetting { get; set; }
		public bool ctrlTogether { get; set; }
		public PartsInfo[] parts { get; set; } = null!;
		public int kind { get; set; }
		public int shaderType { get; set; }
		public AiHair() { }
		public object? ExtendedSaveData { get; set; }
	}
}