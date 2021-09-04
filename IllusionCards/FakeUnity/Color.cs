using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

using IllusionCards.Util;

using MessagePack;
using MessagePack.Formatters;

namespace IllusionCards.FakeUnity
{

	[MessagePackFormatter(typeof(ColorFormatter))]
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly struct Color
	{
		public float r { get; init; } = 0f;
		public float g { get; init; } = 0f;
		public float b { get; init; } = 0f;
		public float a { get; init; } = 0f;
		public Color(ImmutableArray<float> values)
		{
			if (values.Length != 4) throw new ArgumentException($"Values array must contain 4 items, but {values.Length} were supplied.");
			r = values[0];
			g = values[1];
			b = values[2];
			a = values[3];
		}
	}
	public sealed class ColorFormatter : IMessagePackFormatter<Color>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Color value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.Write(value.r);
			writer.Write(value.g);
			writer.Write(value.b);
			writer.Write(value.a);
		}
		public Color Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return new Color(Helpers.UnpackFloats(ref reader, 4));
		}
	}
}
