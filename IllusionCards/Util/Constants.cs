namespace IllusionCards.Util;

public readonly record struct Constants
{
	public static readonly ImmutableArray<byte> PNGHeader = new byte[5] { 0x89, 0x50, 0x4E, 0x47, 0x0D }.ToImmutableArray();
	public static readonly ImmutableArray<byte> PNGFooter = new byte[8] { 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 }.ToImmutableArray();
}
