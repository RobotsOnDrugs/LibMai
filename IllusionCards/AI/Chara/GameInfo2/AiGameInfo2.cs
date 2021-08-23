using System.Diagnostics.CodeAnalysis;

using IllusionCards.AI.Cards;

using MessagePack;
namespace IllusionCards.AI.Chara
{
	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly struct AiGameInfo2
	{
		public int Favor { get; init; }
		public int Enjoyment { get; init; }
		public int Aversion { get; init; }
		public int Slavery { get; init; }
		public int Broken { get; init; }
		public int Dependence { get; init; }
		public AiCharaCardDefinitions.State nowState { get; init; }
		public AiCharaCardDefinitions.State nowDrawState { get; init; }
		public bool lockNowState { get; init; }
		public bool lockBroken { get; init; }
		public bool lockDependence { get; init; }
		public int Dirty { get; init; }
		public int Tiredness { get; init; }
		public int Toilet { get; init; }
		public int Libido { get; init; }
		public int alertness { get; init; }
		public AiCharaCardDefinitions.State calcState { get; init; }
		public byte escapeFlag { get; init; }
		public bool escapeExperienced { get; init; }
		public bool firstHFlag { get; init; }
		public bool[][] genericVoice { get; init; } = null!;
		public bool genericBrokenVoice { get; init; }
		public bool genericDependencepVoice { get; init; }
		public bool genericAnalVoice { get; init; }
		public bool genericPainVoice { get; init; }
		public bool genericFlag { get; init; }
		public bool genericBefore { get; init; }
		public bool[] inviteVoice { get; init; } = null!;
		public int hCount { get; init; }
		public HashSet<int> map { get; init; } = null!;
		public bool arriveRoom50 { get; init; }
		public bool arriveRoom80 { get; init; }
		public bool arriveRoomHAfter { get; init; }
		public int resistH { get; init; }
		public int resistPain { get; init; }
		public int resistAnal { get; init; }
		public int usedItem { get; init; }
		public bool isChangeParameter { get; init; }
		public bool isConcierge { get; init; }
		public object? ExtendedSaveData { get; init; }
	}
}
