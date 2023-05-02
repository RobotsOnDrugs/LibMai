namespace LibMai.Cards.AI.Cards;

public record AiSceneCard : IllusionCard
{
	public Version CardVersion { get; init; }
	public ImmutableArray<AiStudioObject> StudioObjects { get; init; }
	public AiSceneCard(in AiCardStructure cs, BinaryReader binary_reader) : base(cs, binary_reader)
	{
#if RELEASE
		throw new UnsupportedCardException("Scene cards are not supported yet");
#endif
		CardVersion = new(ReadString(binary_reader));
		ImmutableDictionary<int, AiStudioObject> StudioObjects = GetStudioObjects(binary_reader);
	}

	internal static ImmutableDictionary<int, AiStudioObject> GetStudioObjects(BinaryReader binary_reader, bool uses_common_id = false)
	{
		ImmutableDictionary<int, AiStudioObject>.Builder studio_objects = ImmutableDictionary.CreateBuilder<int, AiStudioObject>();
		int num_objects = binary_reader.ReadInt32();
		int obj_id = -1;
		if (uses_common_id)
			obj_id = binary_reader.ReadInt32();
		for (int i = 0; i < num_objects; i++)
		{
			if (!uses_common_id)
				obj_id = binary_reader.ReadInt32();
			int _objType = binary_reader.ReadInt32();
			AiStudioObject _obj = _objType switch
			{
				0 => new AiStudioCharacter(binary_reader),
				1 => new AiStudioItem(binary_reader),
				2 => new AiStudioLight(binary_reader),
				3 => new AiStudioFolder(binary_reader),
				4 => new AiStudioRoute(binary_reader),
				5 => new AiStudioCamera(binary_reader),
				_ => throw new InvalidCardException("Could not parse what seemed to be a Studio NEO V2 card.")
			};
			studio_objects.Add(obj_id, _obj);
		}
		return studio_objects.ToImmutable();
	}
}
