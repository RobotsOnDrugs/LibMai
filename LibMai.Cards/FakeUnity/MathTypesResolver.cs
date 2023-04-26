namespace LibMai.Cards.FakeUnity;

// Mostly copy-pasted from MessagePack-CSharp's readme. MP is pretty much voodoo, but it's awesome when it works.
internal sealed class MathTypesResolver : IFormatterResolver
{
	private static readonly IFormatterResolver instance = new MathTypesResolver();

	private MathTypesResolver() { }
	public IMessagePackFormatter<T>? GetFormatter<T>() => FormatterCache<T>.Formatter;

	private static class FormatterCache<T>
	{
		public static readonly IMessagePackFormatter<T>? Formatter;
		static FormatterCache() => Formatter = (IMessagePackFormatter<T>?)MathTypesResolverGetFormatterHelper.GetFormatter(typeof(T));
	}
	
	public static readonly IFormatterResolver MathResolver = CompositeResolver.Create(instance, StandardResolver.Instance);
	public static readonly MessagePackSerializerOptions WithMathTypes = MessagePackSerializerOptions.Standard.WithResolver(MathResolver);
}

internal static class MathTypesResolverGetFormatterHelper
{
	private static readonly ImmutableDictionary<Type, object> formatter_map = new Dictionary<Type, object>()
	{
		{ typeof(Vector4), new Vector4Formatter() },
		{ typeof(Vector3), new Vector3Formatter() },
		{ typeof(Vector2), new Vector2Formatter() }
	}.ToImmutableDictionary();

	internal static object? GetFormatter(Type t) => formatter_map.TryGetValue(t, out object? formatter) ? formatter : null;
}
