namespace IllusionCards.Chara
{
	public abstract partial class IllusionChara
	{
		public enum CharaSex
		{
			Male,
			Female,
			Futa,
			Unknown
		}
		public abstract string Name { get; init; }
		public abstract CharaSex Sex { get; init; }
		public bool IsFemale { get { return ((Sex == CharaSex.Female) || (Sex == CharaSex.Futa)); } }
		public bool IsMale { get { return (Sex == CharaSex.Male); } }
		
	}
}
