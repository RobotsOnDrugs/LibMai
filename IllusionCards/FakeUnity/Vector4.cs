
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using MessagePack;
using MessagePack.Formatters;

namespace IllusionCards.FakeUnity
{
	[MessagePackFormatter(typeof(Vector4Formatter))]
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention, mirrors original variable names")]
	public readonly struct Vector4
	{

		public const float kEpsilon = 1E-05f;
		public float x { get; init; } = 0f;
		public float y { get; init; } = 0f;
		public float z { get; init; } = 0f;
		public float w { get; init; } = 0f;
		public Vector4(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
		public Vector4(float x, float y, float z) : this(x, y, z, 0f) { }
		public Vector4(float x, float y) : this(x, y, 0f, 0f) { }
		public Vector4(ImmutableArray<float> values)
		{
			if (values.Length != 4) throw new ArgumentException($"Values array must contain 4 items, but {values.Length} were supplied.");
			x = values[0];
			y = values[1];
			z = values[2];
			w = values[3];
		}
	}
	public sealed class Vector4Formatter : IMessagePackFormatter<Vector4>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Vector4 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.Write(value.x);
			writer.Write(value.y);
			writer.Write(value.z);
			writer.Write(value.w);
		}
		public Vector4 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return new Vector4(Helpers.UnpackFloats(ref reader, 4));
		}
	}
}
