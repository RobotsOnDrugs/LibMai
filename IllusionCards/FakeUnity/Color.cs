using System;
using System.Diagnostics.CodeAnalysis;

using MessagePack;
using MessagePack.Formatters;

namespace IllusionCards.FakeUnity
{

	[MessagePackFormatter(typeof(ColorFormatter))]
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public struct Color
	{
		public float r;
		public float g;
		public float b;
		public float a;
		public Color(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}
		public Color(float r, float g, float b) : this(r, g, b, 1f) { }
		public Color(float[] values)
		{
			if (values.Length != 4) throw new ArgumentException($"Values array must contain 4 items, but {values.Length} were supplied.");
			r = values[0];
			g = values[1];
			b = values[2];
			a = values[3];
		}
		public static Color white => new(1f, 1f, 1f, 1f);
		public static Color black => new(0f, 0f, 0f, 1f);
		public static Color red => new(1f, 0f, 0f, 1f);
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
