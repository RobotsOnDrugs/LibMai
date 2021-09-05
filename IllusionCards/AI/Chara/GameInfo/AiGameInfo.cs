namespace IllusionCards.AI.Chara;

[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
public readonly struct AiGameInfo
{
	public Version version { get; init; } = null!;
	public bool gameRegistration { get; init; }
	public MinMaxInfo tempBound { get; init; }
	public MinMaxInfo moodBound { get; init; }
	public Dictionary<int, int> flavorState { get; init; } = null!;
	public int totalFlavor { get; init; }
	public Dictionary<int, float> desireDefVal { get; init; } = null!;
	public Dictionary<int, float> desireBuffVal { get; init; } = null!;
	public int phase { get; init; }
	public Dictionary<int, int> normalSkill { get; init; } = null!;
	public Dictionary<int, int> hSkill { get; init; } = null!;
	public int favoritePlace { get; init; }
	public int lifestyle { get; init; }
	public int morality { get; init; }
	public int motivation { get; init; }
	public int immoral { get; init; }
	public bool isHAddTaii0 { get; init; }
	public bool isHAddTaii1 { get; init; }
	public object? ExtendedSaveData { get; init; }

	[MessagePackObject(true), SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Uses MessagePack convention")]
	public readonly struct MinMaxInfo
	{
		public float lower { get; init; }
		public float upper { get; init; }
		public object? ExtendedSaveData { get; init; }
	}
}
