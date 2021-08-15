using IllusionCards.AI.Cards;
using IllusionCards.Cards;
using IllusionCards.Util;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	public record AiCoordinate
	{
		public const string BlockName = "Coordinate";
		public AiClothes clothes;
		public AiAccessory accessory;
		public AiCoordinate(byte[] coordinateData)
		{
			byte[][] _dataChunks = Helpers.GetDataChunks(coordinateData, 2);
			clothes = MessagePackSerializer.Deserialize<AiClothes>(_dataChunks[0]);
			accessory = MessagePackSerializer.Deserialize<AiAccessory>(_dataChunks[1]);
			if (clothes.version < AiCharaCardDefinitions.AiClothesVersion) { throw new InternalCardException("Clothes data for this card is too old."); }
			if (accessory.version < AiCharaCardDefinitions.AiAccessoryVersion) { throw new InternalCardException("Accessory data for this card is too old."); }
		}
	}
}
