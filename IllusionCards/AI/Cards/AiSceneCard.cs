using System.Collections.Immutable;

using IllusionCards.AI.Studio;
using IllusionCards.Cards;

namespace IllusionCards.AI.Cards
{
	public record AiSceneCard : IllusionCard
	{
		public Version CardVersion { get; init; }
		public ImmutableArray<AiStudioObject> StudioObjects { get; init; }
		public AiSceneCard(CardStructure cs) : base(cs)
		{
			ImmutableArray<AiStudioObject>.Builder _studioObjects = ImmutableArray.CreateBuilder<AiStudioObject>();
			CardVersion = new(CardBinaryReader.ReadString());
			int _numObjects = CardBinaryReader.ReadInt32();
			for (int i = 0; i < _numObjects; i++)
			{
				int _objId = CardBinaryReader.ReadInt32();
				int _objType = CardBinaryReader.ReadInt32();
				AiStudioObject _obj = _objType switch
				{
					0 => new AiStudioCharacter(CardBinaryReader),
					1 => new AiStudioItem(CardBinaryReader),
					2 => new AiStudioLight(CardBinaryReader),
					3 => new AiStudioFolder(CardBinaryReader),
					4 => new AiStudioRoute(CardBinaryReader),
					5 => new AiStudioCamera(CardBinaryReader),
					_ => throw new InvalidCardException(CardPath, "Could not parse what seemed to be a Studio NEO V2 card.")
				};
				_studioObjects.Add(_obj);
			}

			StudioObjects = _studioObjects.ToImmutable();
			CardStructure.CleanupStreams();
		}
	}
}