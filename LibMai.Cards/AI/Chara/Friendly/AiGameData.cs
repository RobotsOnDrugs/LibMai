// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedType.Global
// Properties are part of a public API

namespace LibMai.Cards.AI.Chara.Friendly;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Uses MessagePack convention")]
public readonly record struct AiGameData // GameInfo
{
	public AiGameData() { }
	public ImmutableArray<int> Wishes { get; init; } = ImmutableArray.CreateBuilder<int>().ToImmutable(); // This comes from Parameter and seems to be AIS-specific
	public bool IsRegistered { get; init; }
	public float LowerTempBound { get; init; }
	public float UpperTempBound { get; init; }
	public float LowerMoodBound { get; init; }
	public float UpperMoodBound { get; init; }
	public ImmutableDictionary<FlavorType, int> FlavorState { get; init; } = null!;
	public int totalFlavor { get; init; }
	public ImmutableDictionary<Desires, DesireData> Desire { get; init; } = null!;
	public int Hearts { get; init; } // phase
	public Dictionary<int, int> normalSkill { get; init; } = null!;
	public Dictionary<int, int> hSkill { get; init; } = null!;
	public int favoritePlace { get; init; }
	public LifestyleType Lifestyle { get; init; }
	public int morality { get; init; }
	public int motivation { get; init; }
	public int immoral { get; init; }
	public bool isHAddTaii0 { get; init; }
	public bool isHAddTaii1 { get; init; }

	public enum FlavorType
	{
		Pheromone,
		Reliability,
		Reason,
		Instinct,
		Dirty,
		Wariness,
		Darkness,
		Sociability
	}
	
	[Flags]
	public enum DesireFlags
	{
		None = 0,
		Toilet = 1,
		Bath = 2,
		Sleep = 4,
		Eat = 8,
		Break = 16,
		Gift = 32,
		Want = 64,
		Lonely = 128,
		H = 256,
		Dummy = 512,
		Hunt = 1024,
		Game = 2048,
		Cook = 4096,
		Animal = 8192,
		Location = 16384,
		Drink = 32768
	}
	
	public enum Desires
	{
		Toilet,
		Bath,
		Sleep,
		Eat,
		Break,
		Gift,
		Want,
		Lonely,
		H,
		Dummy,
		Hunt,
		Game,
		Cook,
		Animal,
		Location,
		Drink
	}
	
	public enum StatusType
	{
		Temperature,
		Mood,
		Hunger,
		Physical,
		Life,
		Motivation,
		Immoral,
		Morality
	}
	
	public enum LifestyleType
	{
		Getter,
		Baby,
		Driver,
		Controller,
		ExcitementSeeker,
		Armchair
	}
	
	public enum SkillType
	{
		None = -1,
		CookingLover,
		CleanLover,
		AnimalLover,
		SleepingPrincess,
		PriestessBloodline,
		Achiever,
		Simple,
		ReactionLover,
		Dear,
		DevotedPartner,
		FishingLover,
		Klutz,
		CropKnowledge,
		Avarice,
		Tireless,
		Glutton,
		RainLover,
		Wild,
		GoodsSupplier,
		Beastmaster,
		Moody,
		LovesToPlay,
		SexualDesire,
		Curiosity,
		CursedBody,
		Sensitive,
		Distrustful,
		HeartWall,
		BodyManagement,
		Endurance,
		Lonely,
		GoodTalker,
		Chatty,
		Doer,
		SuperSense,
		Slacker,
		Fastidious,
		Misfortune,
		WeakConstitution,
		DeepDarkness,
		Unkempt,
		Lucky,
		DiggingManiac,
		BugCollector,
		Hunter,
		Courage,
		Collector,
		TerrainGrasp,
		Guts,
		GoodLuck
	}
	
	public readonly record struct DesireData
	{
		public float BaseDesire { get; init; }
		public float DesireBuff { get; init; }
	}
}