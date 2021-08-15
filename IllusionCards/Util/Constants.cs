
using IllusionCards.Cards;

namespace IllusionCards.Util
{
	public record Constants
	{
		public static readonly byte[] pngHeader = { 0x89, 0x50, 0x4E, 0x47, 0x0D };
		public static readonly byte[] pngFooter = { 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 };

		public const string AICharaIdentifier = "【AIS_Chara】";
		public const string AIClothesIdentifier = "【AIS_Clothes】";
		public const string KKCharaIdentifier = "【KoiKatuChara】";
		public const string KKPartyCharaIdentifier = "【KoiKatuCharaS】";
		public const string KKPartySPCharaIdentifier = "【KoiKatuCharaSP】";
		public const string ECCharaIdentifier = "【EroMakeChara】";
		public const string PHFemaleCharaIdentifier = "【PlayHome_FemaleCoordinate】";
		public const string PHFemaleClothesIdentifier = "【PlayHome_Female】";

		public static readonly Dictionary<CardType, string> CardTypeNames = new()
		{
			[CardType.AIChara] = "AI Shoujo/Honey Select 2 Character",
			[CardType.AICoordinate] = "AI Shoujo/Honey Select 2 Outfit",
			[CardType.AIScene] = "Studio NEO v2 Scene",
			[CardType.KKChara] = "Koikatsu Character",
			[CardType.KKPartyChara] = "Koikatsu Party Character",
			[CardType.KKPartySPChara] = "Koikatsu Party SP Character",
			[CardType.KKScene] = "Chara Studio Scene",
			[CardType.PHFemaleChara] = "PlayHome Female Character",
			[CardType.PHFemaleClothes] = "PlayHome Female Clothes",
			[CardType.PHScene] = "PlayHome Studio Scene",
			[CardType.ECChara] = "Emotion Creators Character"
		};

	}
}
