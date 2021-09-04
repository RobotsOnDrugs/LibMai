using System.Collections.Immutable;
using System.Numerics;

using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

namespace IllusionCards.Util
{
	// Mostly copy-pasted from MessagePack-CSharp's readme. MP is pretty much voodoo, but it's awesome when it works.
	public class MathTypesResolver : IFormatterResolver
	{
		public static readonly IFormatterResolver Instance = new MathTypesResolver();

		private MathTypesResolver() { }
		public IMessagePackFormatter<T>? GetFormatter<T>() => FormatterCache<T>.Formatter;

		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T>? Formatter;
			static FormatterCache() => Formatter = (IMessagePackFormatter<T>?)MathTypesResolverGetFormatterHelper.GetFormatter(typeof(T));
		}
		public static readonly IFormatterResolver MathResolver = CompositeResolver.Create(Instance, StandardResolver.Instance);
		public static readonly MessagePackSerializerOptions WithMathTypes = MessagePackSerializerOptions.Standard.WithResolver(MathResolver);
	}

	internal static class MathTypesResolverGetFormatterHelper
	{
		static readonly ImmutableDictionary<Type, object> formatterMap = new Dictionary<Type, object>()
		{
			{ typeof(Vector4), new Vector4Formatter() },
			{ typeof(Vector3), new Vector3Formatter() },
			{ typeof(Vector2), new Vector2Formatter() }
		}.ToImmutableDictionary();

		internal static object? GetFormatter(Type t) => formatterMap.TryGetValue(t, out object? formatter) ? formatter : null;
	}
}
