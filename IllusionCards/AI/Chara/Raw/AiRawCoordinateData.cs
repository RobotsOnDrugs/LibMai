using IllusionCards.AI.Chara.Raw.Coordinate;

namespace IllusionCards.AI.Chara.Raw;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawCoordinateData
{
	public Version LoadVersion { get; init; }
	public int Language { get; init; }
	public AiRawClothesData clothes { get; init; }
	public AiRawAccessoriesData accessory { get; init; }

	[IgnoreMember]
	internal bool IsInitialized { get; init; } = false;
	public AiRawCoordinateData(in byte[] coordinateData, Version loadVersion, int language)
	{
		MessagePackSerializer.DefaultOptions = WithMathTypes;
		byte[][] _dataChunks = Helpers.GetDataChunks(coordinateData, 2);
		clothes = MessagePackSerializer.Deserialize<AiRawClothesData>(_dataChunks[0]);
		accessory = MessagePackSerializer.Deserialize<AiRawAccessoriesData>(_dataChunks[1]);
		if (clothes.version < AiClothesVersion) { throw new InternalCardException("Clothes data for this card is too old."); }
		if (accessory.version < AiAccessoryVersion) { throw new InternalCardException("Accessory data for this card is too old."); }
		IsInitialized = true;
		LoadVersion = loadVersion;
		Language = language;
	}
}
