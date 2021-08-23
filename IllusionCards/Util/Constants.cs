
using System.Collections.Immutable;

using IllusionCards.Cards;

namespace IllusionCards.Util
{
	public readonly struct Constants
	{
		public static readonly ImmutableArray<byte> pngHeader = new byte[5] { 0x89, 0x50, 0x4E, 0x47, 0x0D }.ToImmutableArray();
		public static readonly ImmutableArray<byte> pngFooter = new byte[8] { 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 }.ToImmutableArray();


		public const string AiCustomBlockName = "Custom";
		public const string AiCoordinateBlockName = "Coordinate";
		public const string AiParameterBlockName = "Parameter";
		public const string AiParameter2BlockName = "Parameter2";
		public const string AiGameInfoBlockName = "GameInfo";
		public const string AiGameInfo2BlockName = "GameInfo2";
		public const string AiStatusBlockName = "Status";
		public const string AiPluginDataBlockName = "KKEx";

		public const string AICharaIdentifier = "【AIS_Chara】";
		public const string AIClothesIdentifier = "【AIS_Clothes】";
		public const string KKCharaIdentifier = "【KoiKatuChara】";
		public const string KKPartyCharaIdentifier = "【KoiKatuCharaS】";
		public const string KKPartySPCharaIdentifier = "【KoiKatuCharaSP】";
		public const string ECCharaIdentifier = "【EroMakeChara】";
		public const string PHFemaleCharaIdentifier = "【PlayHome_FemaleCoordinate】";
		public const string PHFemaleClothesIdentifier = "【PlayHome_Female】";

		public static readonly ImmutableDictionary<CardType, string> CardTypeNames = new Dictionary<CardType, string>()
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
		}.ToImmutableDictionary();

	}
}
