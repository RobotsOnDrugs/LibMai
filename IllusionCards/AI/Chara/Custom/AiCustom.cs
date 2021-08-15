using IllusionCards.AI.Cards;
using IllusionCards.Cards;
using IllusionCards.Util;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	public record AiCustom
	{
		public const string BlockName = "Custom";
		public AiFace face;
		public AiBody body;
		public AiHair hair;

		// In case it's important:
		// BustSizeKind is determined by body.shapeValueBody[1] - 0 if =< 0.33f, 2 if >= 0.66f, 1 if in between
		// HeightKind is determined by body.shapeValueBody[0] - 0 if =< 0.33f, 2 if >= 0.66f, 1 if in between
		public AiCustom(byte[] customData)
		{
			byte[][] _dataChunks = Helpers.GetDataChunks(customData, 3);
			face = MessagePackSerializer.Deserialize<AiFace>(_dataChunks[0]);
			body = MessagePackSerializer.Deserialize<AiBody>(_dataChunks[1]);
			hair = MessagePackSerializer.Deserialize<AiHair>(_dataChunks[2]);
			if (face.version < AiCharaCardDefinitions.AiFaceVersion) { throw new InternalCardException("Face data for this card is too old."); }
			if (body.version < AiCharaCardDefinitions.AiBodyVersion) { throw new InternalCardException("Body data for this card is too old."); }
			if (hair.version < AiCharaCardDefinitions.AiHairVersion) { throw new InternalCardException("Hair data for this card is too old."); }
		}
	}
}
