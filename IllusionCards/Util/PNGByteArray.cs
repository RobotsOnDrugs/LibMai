namespace IllusionCards.Util;

public readonly record struct PNGByteArray
{
	public ImmutableArray<byte> ByteData { get; init; }
}
