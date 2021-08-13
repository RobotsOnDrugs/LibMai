using System.IO;

using IllusionCards.AI.Cards;
using IllusionCards.Cards;

using MessagePack;

namespace IllusionCards.AI.Chara
{
	public class AiCustom
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
			using MemoryStream _mstream = new(customData);
			using BinaryReader _reader = new(_mstream);
			int _count = _reader.ReadInt32();
			byte[] _bytes = _reader.ReadBytes(_count);
			//face = new(_bytes);
			face = MessagePackSerializer.Deserialize<AiFace>(_bytes);
			_count = _reader.ReadInt32();
			_bytes = _reader.ReadBytes(_count);
			body = MessagePackSerializer.Deserialize<AiBody>(_bytes);
			_count = _reader.ReadInt32();
			_bytes = _reader.ReadBytes(_count);
			hair = MessagePackSerializer.Deserialize<AiHair>(_bytes);
			if (face.version < AiCharaCardDefinitions.AiFaceVersion) { throw new InternalCardException("Face data for this card is too old."); }
			if (body.version < AiCharaCardDefinitions.AiBodyVersion) { throw new InternalCardException("Body data for this card is too old."); }
			if (hair.version < AiCharaCardDefinitions.AiHairVersion) { throw new InternalCardException("Hair data for this card is too old."); }
		}
	}
}
