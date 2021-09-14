using IllusionCards.AI.Chara.Raw.Custom;

namespace IllusionCards.AI.Chara.Raw;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly record struct AiRawCustomData
{
	public AiRawFaceData face { get; init; }
	public AiRawBodyData body { get; init; }
	public AiRawHairData hair { get; init; }

	[IgnoreMember]
	internal bool IsInitialized { get; init; } = false;

	// In case it's important:
	// BustSizeKind is determined by body.shapeValueBody[1] - 0 if =< 0.33f, 2 if >= 0.66f, 1 if in between
	// HeightKind is determined by body.shapeValueBody[0] - 0 if =< 0.33f, 2 if >= 0.66f, 1 if in between
	public AiRawCustomData(in byte[] customData)
	{
		MessagePackSerializer.DefaultOptions = WithMathTypes;
		byte[][] _dataChunks = Helpers.GetDataChunks(customData, 3);
		face = MessagePackSerializer.Deserialize<AiRawFaceData>(_dataChunks[0]);
		body = MessagePackSerializer.Deserialize<AiRawBodyData>(_dataChunks[1]);
		hair = MessagePackSerializer.Deserialize<AiRawHairData>(_dataChunks[2]);
		if (face.version < AiFaceVersion) { throw new InternalCardException("Face data for this card is too old."); }
		if (body.version < AiBodyVersion) { throw new InternalCardException("Body data for this card is too old."); }
		if (hair.version < AiHairVersion) { throw new InternalCardException("Hair data for this card is too old."); }
		IsInitialized = true;
	}
}
