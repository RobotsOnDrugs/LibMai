namespace IllusionCards.AI.Chara.Friendly;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Use MessagePack convention")]
public readonly record struct HS2GameData // GameInfo2 and Parameter2
{
	public SexTraitType SexTrait { get; init; }
	public MentalityType Mentality { get; init; }
	public TraitType Trait { get; init; }
	public int FavorLevel { get; init; }
	public int EnjoymentLevel { get; init; }
	public int AversionLevel { get; init; }
	public int SlaveryLevel { get; init; }
	public int BrokenLevel { get; init; }
	public int DependenceLevel { get; init; }
	public bool StateLocked { get; init; }
	public bool BrokenLevelLocked { get; init; }
	public bool DependenceLevelLocked { get; init; }
	public HS2CharaStatus State { get; init; } // The dominant state, which is the highest priority state for the character's personality (must be >= 20)
	public HS2CharaStatus DisplayedState { get; init; } // The dominant state, but only if the stat is >= 50 - this determines the girl's displayed state in the lobby/H scenes/whatever
	public int DirtyLevel { get; init; }
	public int TirednessLevel { get; init; }
	public int ToiletLevel { get; init; }
	public int LibidoLevel { get; init; }
	public int AlertnessLevel { get; init; } // This doesn't seem to actually be used for anything, and all of my characters have this set to 0
	public bool arriveRoom50 { get; init; } // Something to do with bath events
	public bool arriveRoom80 { get; init; } // ?
	public bool arriveRoomHAfter { get; init; } // ?
	public int SexExperience { get; init; } // resistH
	public int BDSMExperience { get; init; } // resistPain
	public int AnalExperience { get; init; } // resistAnal
	public SexItemType ActiveItem { get; init; } // usedItem
	public bool isChangeParameter { get; init; }
	public bool IsConcierge { get; init; }

	public enum SexTraitType // hAttribute
	{
		None,
		Horny,
		Sadist,
		Masochist,
		SensitiveBreasts,
		SensitiveAss,
		SensitivePussy,
		LoveKisses,
		CleanFreak,
		SexHater,
		Lonely
	}
	public enum MentalityType // mind
	{
		None,
		Curious,
		Affectionate,
		Lovestruck,
		Awkward,
		Reluctant,
		Loathing,
		Cooperative,
		Obedient,
		Submissive,
		Interested,
		Charmed,
		Aroused,
	}
	public enum TraitType // trait
	{
		None,
		CleanLover,
		Lazy,
		Fragile,
		Tough,
		WeakBladder,
		Patient,
		GlassHeart,
		Brave,
		Perverted,
		SelfControl,
		AtWill,
		Sensitive
	}
	public enum SexItemType { }

	public enum HS2CharaStatus
	{
		Blank,
		Favor,
		Enjoyment,
		Aversion,
		Slavery,
		Broken,
		Dependence
	}
}