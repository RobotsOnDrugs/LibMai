using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using MessagePack;
using MessagePack.Formatters;

namespace IllusionCards.FakeUnity
{
	[MessagePackFormatter(typeof(Vector2Formatter))]
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention, mirrors original variable names")]
	public readonly struct Vector2
	{
		public const float kEpsilon = 1E-05f;
		public const float kEpsilonNormalSqrt = 1E-15f;
		public float x { get; init; } = 0f;
		public float y { get; init; } = 0f;
		public Vector2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		public Vector2(ImmutableArray<float> values)
		{
			if (values.Length != 2) throw new ArgumentException($"Values array must contain 2 items, but {values.Length} were supplied.");
			x = values[0];
			y = values[1];
		}

		public static Vector2 zero => new(0f, 0f);
	}
	public sealed class Vector2Formatter : IMessagePackFormatter<Vector2>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Vector2 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.x);
			writer.Write(value.y);
		}
		public Vector2 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return new Vector2(Helpers.UnpackFloats(ref reader, 2));
		}
	}
}
