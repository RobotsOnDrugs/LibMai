namespace IllusionCards.Util;

public sealed class Vector2Formatter : IMessagePackFormatter<Vector2>, IMessagePackFormatter
{
	public void Serialize(ref MessagePackWriter writer, Vector2 value, MessagePackSerializerOptions options)
	{
		writer.WriteArrayHeader(2);
		writer.Write(value.X);
		writer.Write(value.Y);
	}
	public Vector2 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		ImmutableArray<float> _values = Helpers.UnpackFloats(ref reader, 2);
		return new Vector2(_values[0], _values[1]);
	}
}
public sealed class Vector3Formatter : IMessagePackFormatter<Vector3>, IMessagePackFormatter
{
	public void Serialize(ref MessagePackWriter writer, Vector3 value, MessagePackSerializerOptions options)
	{
		writer.WriteArrayHeader(3);
		writer.Write(value.X);
		writer.Write(value.Y);
		writer.Write(value.Z);
	}
	public Vector3 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		ImmutableArray<float> _values = Helpers.UnpackFloats(ref reader, 3);
		return new Vector3(_values[0], _values[1], _values[2]);
	}
}

public sealed class Vector4Formatter : IMessagePackFormatter<Vector4>, IMessagePackFormatter
{
	public void Serialize(ref MessagePackWriter writer, Vector4 value, MessagePackSerializerOptions options)
	{
		writer.WriteArrayHeader(4);
		writer.Write(value.X);
		writer.Write(value.Y);
		writer.Write(value.Z);
		writer.Write(value.W);
	}
	public Vector4 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		ImmutableArray<float> _values = Helpers.UnpackFloats(ref reader, 4);
		return new Vector4(_values[0], _values[1], _values[2], _values[3]);
	}
}
