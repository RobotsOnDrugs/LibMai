using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using MessagePack;
using MessagePack.Formatters;

namespace IllusionCards.FakeUnity
{
	[MessagePackFormatter(typeof(Vector3Formatter))]
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention, mirrors original variable names")]
	public readonly struct Vector3
	{
		public const float kEpsilon = 1E-05f;
		public const float kEpsilonNormalSqrt = 1E-15f;
		public float x { get; init; } = 0f;
		public float y { get; init; } = 0f;
		public float z { get; init; } = 0f;
		public Vector3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public Vector3(float x, float y) : this(x, y, 0f) { }
		public Vector3(ImmutableArray<float> values)
		{
			if (values.Length != 3) throw new ArgumentException($"Values array must contain 3 items, but {values.Length} were supplied.");
			x = values[0];
			y = values[1];
			z = values[2];
		}

		public static Vector3 zero => new(0f, 0f, 0f);
	}
	public sealed class Vector3Formatter : IMessagePackFormatter<Vector3>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Vector3 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.x);
			writer.Write(value.y);
			writer.Write(value.z);
		}
		public Vector3 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return new Vector3(Helpers.UnpackFloats(ref reader, 3));
		}
	}
}
