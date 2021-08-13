using System;

using IllusionCards.AI.Cards;

namespace IllusionCards.AI.Chara
{
	public record AiCoordinate
	{
		public string CoordinateFileName { get; private set; } = null!;
		public const string BlockName = "Coordinate";
		public int loadProductNo;
		public Version loadVersion = new(AiCharaCardDefinitions.AiCoordinateVersion.ToString());
		public int language;
		//public AiClothes clothes;
		//public AiAccessory accessory;
		public string coordinateName = "";
		public byte[] pngData = null!;
	}
}
