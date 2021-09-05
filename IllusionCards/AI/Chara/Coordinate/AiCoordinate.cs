namespace IllusionCards.AI.Chara;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly struct AiCoordinate
{
	public Version LoadVersion { get; init; }
	public int Language { get; init; }
	public AiClothes clothes { get; init; }
	public AiAccessory accessory { get; init; }
	[IgnoreMember]
	internal bool IsInitialized { get; init; } = false;
	public AiCoordinate(byte[] coordinateData, Version loadVersion, int language)
	{
		MessagePackSerializer.DefaultOptions = WithMathTypes;
		byte[][] _dataChunks = Helpers.GetDataChunks(coordinateData, 2);
		clothes = MessagePackSerializer.Deserialize<AiClothes>(_dataChunks[0]);
		accessory = MessagePackSerializer.Deserialize<AiAccessory>(_dataChunks[1]);
		if (clothes.version < AiCharaCardDefinitions.AiClothesVersion) { throw new InternalCardException("Clothes data for this card is too old."); }
		if (accessory.version < AiCharaCardDefinitions.AiAccessoryVersion) { throw new InternalCardException("Accessory data for this card is too old."); }
		IsInitialized = true;
		LoadVersion = loadVersion;
		Language = language;
	}
}
