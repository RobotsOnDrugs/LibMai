using System.Collections.Immutable;

using IllusionCards.AI.Studio;
using IllusionCards.Cards;

namespace IllusionCards.AI.Cards
{
	public record AiSceneCard : IllusionCard
	{
		public Version CardVersion { get; init; }
		public ImmutableArray<AiStudioObject> StudioObjects { get; init; }
		public AiSceneCard(CardStructure cs, BinaryReader binaryReader) : base(cs, binaryReader)
		{
			//throw new UnsupportedCardException("Scene cards are not supported yet");
			CardVersion = new(ReadString(binaryReader));
			ImmutableDictionary<int, AiStudioObject> StudioObjects = GetStudioObjects(binaryReader);
		}

		internal static ImmutableDictionary<int, AiStudioObject> GetStudioObjects(BinaryReader binaryReader, bool usesCommonId = false)
		{
			ImmutableDictionary<int, AiStudioObject>.Builder _studioObjects = ImmutableDictionary.CreateBuilder<int, AiStudioObject>();
			int _numObjects = binaryReader.ReadInt32();
			int _objId = -1;
			if (usesCommonId)
				_objId = binaryReader.ReadInt32();
			for (int i = 0; i < _numObjects; i++)
			{
				if (!usesCommonId)
					_objId = binaryReader.ReadInt32();
				int _objType = binaryReader.ReadInt32();
				AiStudioObject _obj = _objType switch
				{
					0 => new AiStudioCharacter(binaryReader),
					1 => new AiStudioItem(binaryReader),
					2 => new AiStudioLight(binaryReader),
					3 => new AiStudioFolder(binaryReader),
					4 => new AiStudioRoute(binaryReader),
					5 => new AiStudioCamera(binaryReader),
					_ => throw new InvalidCardException("Could not parse what seemed to be a Studio NEO V2 card.")
				};
				_studioObjects.Add(_objId, _obj);
			}
			return _studioObjects.ToImmutable();
		}
	}
}