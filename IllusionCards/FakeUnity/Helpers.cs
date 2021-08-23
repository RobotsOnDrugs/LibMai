
using System.Collections.Immutable;

using MessagePack;

namespace IllusionCards.FakeUnity
{
	public static class Helpers
	{
		public static ImmutableArray<float> UnpackFloats(ref MessagePackReader reader, int expectedLength)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			int count = reader.ReadArrayHeader();
			if (count != expectedLength) throw new InvalidOperationException($"Got a float array with an unexpected length. Expected {expectedLength}, got {count}");
			float[] _a = new float[expectedLength];
			for (int i = 0; i < count; i++)
			{
				_a[i] = reader.ReadSingle();
			}
			return _a.ToImmutableArray();
		}
	}
}
