namespace IllusionCards.AI.Scene;
internal static class SceneHelpers
{
	public static Color JsonBytesToColor(byte[] jsonBytes)
	{
		Utf8JsonReader _colorJsonReader = new(jsonBytes, new() { MaxDepth = 64 });
		float? _r = null; float? _g = null; float? _b = null; float? _a = null;
		while (_colorJsonReader.Read())
		{
			Console.WriteLine(_colorJsonReader.TokenType);
			string? _prop;
			switch (_colorJsonReader.TokenType)
			{
				case JsonTokenType.PropertyName:
					_prop = _colorJsonReader.GetString();
					_colorJsonReader.Read();
					switch (_prop)
					{
						case "r":
							_r = _colorJsonReader.GetSingle();
							break;
						case "g":
							_g = _colorJsonReader.GetSingle();
							break;
						case "b":
							_b = _colorJsonReader.GetSingle();
							break;
						case "a":
							_a = _colorJsonReader.GetSingle();
							break;
					}
					break;
				case JsonTokenType.StartObject:
				case JsonTokenType.EndObject:
					break;
				default:
					throw new InvalidCardException("Could not read color JSON.");
			}
		}
		return _r is not null && _g is not null && _b is not null && _a is not null
			? (new() { r = (float)_r, g = (float)_g, b = (float)_b, a = (float)_a })
			: throw new InvalidCardException("Could not read color JSON.");
	}
}
