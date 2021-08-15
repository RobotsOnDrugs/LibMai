
using MessagePack;

namespace IllusionCards.FakeUnity
{
	public static class Helpers
	{
		public static float[] UnpackFloats(ref MessagePackReader reader, int expectedLength)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			int count = reader.ReadArrayHeader();
			if (count != expectedLength) throw new InvalidOperationException($"Got a float array with an unexpected length. Expected {expectedLength}, got {count}");
			float[] _a = expectedLength switch
			{
				3 => new float[] { 0f, 0f, 0f },
				4 => new float[] { 0f, 0f, 0f, 0f },
				_ => throw new InvalidOperationException($"Arrays must contain only 3 or 4 elements, not {expectedLength}"),
			};
			for (int i = 0; i < count; i++)
			{
				_a[i] = reader.ReadSingle();
			}
			return _a;
		}
	}
}
