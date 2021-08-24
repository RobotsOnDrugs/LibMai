using System.Collections.Immutable;

using IllusionCards.AI.Cards;
using IllusionCards.AI.ExtendedData.PluginData;
using IllusionCards.Chara;

namespace IllusionCards.AI.Chara
{
	public readonly struct AiChara : IIllusionChara
	{
		public IIllusionChara.CharaSex Sex { get {
			return Parameter.sex switch {
				0b0 => IIllusionChara.CharaSex.Male,
				0b1 => IIllusionChara.CharaSex.Female,
				_ => IIllusionChara.CharaSex.Unknown
			}; } }
		public string Name { get => Parameter.fullname; }

		public AiCustom Custom { get; init; }
		public AiCoordinate Coordinate { get; init; }
		public AiParameter Parameter { get; init; }
		public AiParameter2? Parameter2 { get; init; }
		public AiGameInfo GameInfo { get; init; }
		public AiGameInfo2? GameInfo2 { get; init; }
		public AiStatus Status { get; init; }
		public ImmutableHashSet<AiPluginData>? ExtendedData { get; init; }
		public ImmutableHashSet<NullPluginData>? NullData { get; init; }
	}
}
