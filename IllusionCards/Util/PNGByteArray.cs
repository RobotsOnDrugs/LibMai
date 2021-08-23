using System.Collections.Immutable;

namespace IllusionCards.Util
{
	public readonly struct PNGByteArray
	{
		public ImmutableArray<byte> ByteData { get; init; }
	}
}
