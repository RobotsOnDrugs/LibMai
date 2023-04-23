// ReSharper disable InconsistentNaming // All enum member names reflect the names given by Illusion 

namespace IllusionCards.AI.Chara.Friendly.MasterDictionaryLookup;

// Please note: these include vanilla items only. The constantly changing hentai-titty-sized modpack will have to be dealt with separately.
// If you're reviewing this, I highly suggest opening it in an IDE to collapse the enums.

// There are multiple accessories named "0". They are omitted here, but are defined in MasterItemDictionaries.HeadAccessoryLookup so that you can, e.g., lookup 1 and get "0" back.
// TODO: Double check head accessories in dnSpy to see if there was an error in extracting the names and values.
// TODO: Investigate duplicate items in ao_back, ao_hand, and ao_leg.

/// <summary>
/// The index of head accessories as defined by Illusion.
/// Category index: 351. Illusion name: ao_head.
/// </summary>
public enum AiHeadAccessories // 351 ao_head
{
	Hairpin = 0,
	HairClip = 3,
	JeweledOrnament = 32,
	WingOrnament = 26,
	FlowerCorsage = 34,
	PonytailClip = 27,
	Ribbon = 7,
	Hairband = 4,
	Headphones = 5,
	SunVisor = 6,
	BunnyEarBow = 38,
	CatEars = 39,
	SafetyHelmet = 33,
	StrawHat = 8,
	Crown = 9,
	SilkHat = 35,
	Hibiscus = 10,
	Flower = 11,
	Shell = 13,
	Mushroom = 12,
	Eel = 14,
	Crab = 15,
	Watermelon = 36,
	WatermelonHead = 37,
	BasicShapeCube = 16,
	BasicShapeSphere = 17,
	BasicShapeCylinder = 18,
	BasicShapeCapsule = 19,
	BasicShapeCone = 20,
	BasicShapePyramid = 21,
	BasicShapeCrystal = 22,
	BasicShapeRing = 23,
	BasicShapeStar = 24,
	BasicShapeHeart = 25,
	HairBun = 40,
	HairFlick = 41,
	DoubleHairFlick = 42,
	Braid = 43,
	BraidedCrown = 44,
	Extension = 45,
	CurlyExtension = 46,
	LooseTuft = 47,
	LooseTuftNarrow = 48,
	BunnyEarBand = 49,
	DroopyBunnyEarBand = 50,
	WitchHat = 51,
	PumpkinLantern = 52,
	FloppingFish = 54,
	ChickonBoard = 55,
	Butterfly = 56,
	HatCat = 57,
	CubieHead = 58,
	RamHorns = 59,
	CowHorns = 60,
	SingleHorn = 61,
	MechaArmor1 = 62,
	MechaArmor2 = 63,
	MechaArmor3 = 64,
	MechaArmor4 = 65,
	MechaPod = 66,
	MechaShield = 67,
	MechaGoggles = 68,
	MechaVisor = 69,
	MechaBall = 70,
	MechaPole = 71,
	MechaBeamPole = 72,
	MechaDelta = 73,
	MechaBox = 74,
	MechaCircle = 75,
	MechaWing = 76,
	MechaBooster = 77,
	MechaTube = 78,
	MechaScissors = 79,
	MechaDrill = 80,
	MechaAntenna = 81,
	MechaWingII = 82,
	MechaVisorII = 83,
	MechaTriNeedle = 84,
	MechaLion = 85,
	MechaWheel = 86,
	MechaReceiver = 87,
	MechaHair = 88,
	MechaWingRing = 89,
	MechaLoop = 90,
	ModelBattleship = 91,
	ModelTorpedoTube = 92,
	ModelDualTurret = 93,
	KnightsVisor = 94,
	SlimeD = 95,
	SlimeE = 96,
	MechaTank = 97,
	MechaBarrel = 98,
	MechaBlock = 99,
	MechaPump = 100,
	MechaTriPole = 101,
	MechaDragon = 102,
	MechaAntennaSingle = 103,
	HangingJewels = 107,
	WingHairOrnamentLeft = 108,
	WingHairOrnamentRight = 109,
	RoyalCrown = 110,
	SteelHelm = 111,
	Thorn = 112,
	HollyBrooch = 104,
	SantaHat = 105,
	Snowflake = 106,
	ValentineChocolate = 114,
	Present = 115,
	玉かんざし = 222,
	星のかんざし = 226,
}

/// <summary>
/// The index of ear accessories as defined by Illusion.
/// Category index: 352. Illusion name: ao_ear.
/// </summary>
public enum AiEarrings // 352 ao_ear
{
	StarEarring = 0,
	OpenStarEarring = 1,
	CrystalEarring = 2,
	PendulumEarring = 3,
	TripleDropEarring = 4,
	FlowerEarring = 5,
	PearlEarring = 6,
	SnowflakeEarring = 7,
}


/// <summary>
/// The index of glasses as defined by Illusion.
/// Category index: 353. Illusion name: ao_glasses.
/// </summary>
public enum AiGlasses // 353 ao_glasses
{
	SquareGlasses = 0,
	OvalGlasses = 1,
	WellingtonGlasses = 2,
	BostonGlasses = 3,
	BrowlineGlasses = 4,
	UnderrimGlasses = 5,
	Pincenez = 6,
	RoundGlassesMetal = 7,
	OvalGlassesMetal = 8,
	UnderrimGlassesMetal = 9,
	SportsGlasses = 10,
	SwimmingGoggles = 11,
	Goggles = 12,
	LightGoggles = 21,
	Blindfold = 13,
	EyeMaskA = 14,
	EyeMaskB = 15,
	ButterflyMask = 16,
	MedicalEyepatchRight = 17,
	MedicalEyepatchLeft = 18,
	EyepatchRight = 19,
	EyepatchLeft = 20,
	ハートサングラス = 22,
}


/// <summary>
/// The index of face accessories as defined by Illusion.
/// Category index: 354. Illusion name: ao_face.
/// </summary>
public enum AiFaceAccessories // 354 ao_face
{
	ClownNose = 0,
	TenguNose = 1,
	Rose = 2,
	Recorder = 3,
	EyeBandageRight = 4,
	EyeBandageLeft = 5,
	BandanaMask = 6,
	PlagueMask = 7,
	SkeletonMaskTopJaw = 8,
	SkeletonMaskBottomJaw = 9,
	BirdMask = 10,
	WarriorsFaceGuard = 11,
	ChocolateDonut = 12,
}


/// <summary>
/// The index of neck accessories as defined by Illusion.
/// Category index: 355. Illusion name: ao_neck.
/// </summary>
public enum AiNeckAccessories // 355 ao_neck
{
	HeartNecklace = 0,
	StoneNecklace = 1,
	RingNecklace = 2,
	HookNecklace = 3,
	TribalNecklace = 4,
	ColoredStoneNecklace = 5,
	FlowerNecklace = 6,
	SilverHeartNecklace = 7,
	NecktieRibbon = 8,
	Tie = 9,
	LooseTieA = 22,
	LooseTieB = 23,
	NeckBandana = 10,
	LeatherCollar = 11,
	SlaveCollar = 12,
	LaceChoker = 13,
	SimpleChoker = 17,
	FlowerLei = 14,
	MerchantsScarf = 15,
	MerchantsNecklace = 16,
	CoreCubeNecklace = 18,
	CrystalNecklace = 19,
	GoldChoker = 20,
	ChainNecklace = 21,
	BunnyRibbonTie = 24,
	MechaTie = 26,
	RoyalRibbon = 32,
	ChristmasChoker = 27,
	FluffyChoker = 28,
	ChristmasRibbonLarge = 29,
	ChristmasRibbonSmall = 30,
	ChristmasBell = 31,
}


/// <summary>
/// The index of shoulder accessories as defined by Illusion.
/// Category index: 356. Illusion name: ao_shoulder.
/// </summary>
public enum AiShoulderAccessories // 356 ao_shoulder
{
	ToteBag = 0,
	ShoulderBag = 1,
	ToyParrot = 2,
	Purse = 3,
	TangleguardShoulders = 4,
	ArmoredDressShoulders = 5,
	BerserkersShoulderGuard = 6,
	ArmoredShoulderGuard = 7,
	WarriorsShoulderGuard = 8,
	KunoichiShoulderGuard = 9,
	KnightsShoulderPlate = 10,
	OniLordShoulderGuard = 11,
}


/// <summary>
/// The index of breast accessories as defined by Illusion.
/// Category index: 357. Illusion name: ao_chest.
/// </summary>
public enum AiBreastAccessories // 357 ao_chest
{
	SimpleNippleRing = 0,
	JeweledNippleRing = 1,
	LaundryClip = 2,
	MiniVibrator = 3,
	BinderClip = 4,
	SlimeA = 5,
	SlimeB = 6,
	SlimeC = 7,
}


/// <summary>
/// The index of waist accessories as defined by Illusion.
/// Category index: 358. Illusion name: ao_waist.
/// </summary>
public enum AiWaistAccessories // 358 ao_waist
{
	WaistBag = 0,
	SwimRingA = 1,
	SwimRingB = 2,
	KeyRing = 3,
	Handcuffs = 4,
	Whip = 7,
	CatTail = 8,
	MerchantsBelt = 5,
	BunnyTail = 9,
	PortableLamp = 11,
	MechaAmp = 12,
	ArmoredDressGuard = 13,
	BerserkersWaistguard = 14,
	DemonTail = 15,
	KnightsWaistPlate = 16,
	OniLordWaistguardRight = 17,
}


/// <summary>
/// The index of back accessories as defined by Illusion.
/// Category index: 359. Illusion name: ao_back.
/// </summary>
public enum AiBackAccessories // 359 ao_back
{
	Backpack = 0,
	LeatherBag = 1,
	InflatableOrca = 3,
	CardboardBox = 2,
	MerchantsPack = 4,
	Birdcage = 6,
	FairyWings = 7,
	CatRucksack = 8,
	MiniRucksack = 9,
	// MerchantsPack = 10,
	ImpWingRight = 11,
	ImpWingLeft = 12,
	CupidWingRight = 13,
	CupidWingLeft = 14,
	DemonWingRight = 15,
	DemonWingLeft = 16,
	AngelWingRight = 17,
	AngelWingLeft = 18,
	MechaWingIII = 19,
	羽衣 = 20,
}


/// <summary>
/// The index of arm accessories as defined by Illusion.
/// Category index: 360. Illusion name: ao_arm.
/// </summary>
public enum AiArmAccessories // 360 ao_arm
{
	ArmbandA = 0,
	ArmbandB = 1,
	LeatherArmband = 2,
	Armlet = 3,
	BandanaArmband = 4,
	MechaShoulders = 7,
	MechaArmor5 = 8,
	MechaArmor6 = 9,
	MechaArmor6x3 = 10,
	MechaBoosterII = 11,
	MechaShieldII = 12,
	MechaShieldIII = 13,
	MechaArmor = 14,
	SuccubusBangle = 15,
	BerserkersArmGuard = 16,
	TatteredCloakRight = 17,
	TatteredCloakLeft = 18,
}


/// <summary>
/// The index of hand accessories as defined by Illusion.
/// Category index: 361. Illusion name: ao_hand.
/// </summary>
public enum AiHandAccessories // 361 ao_hand
{
	SimpleRing = 0,
	TwinRing = 1,
	JeweledRingA = 2,
	JeweledRingB = 3,
	SkullRing = 4,
	CheerleaderPompom = 5,
	LeatherBangle = 6,
	StoneBraceletwDolphin = 7,
	Wristwatch = 8,
	WristwatchBand = 9,
	MetalBracelet = 10,
	Scrunchie = 11,
	BraceletwStones = 12,
	WristbandA = 13,
	WristbandB = 14,
	WristHalo = 15,
	SmartWatch = 17,
	SportsBracelet = 18,
	TwistBracelet = 19,
	AlchemistsWristband = 20,
	BunnyCuffLeft = 21,
	BunnyCuffRight = 22,
	Hologram = 23,
	FlowerBracelet = 24,
	DemonFist = 25,
	CubieCuff = 26,
	Pistol = 27,
	Knife = 28,
	Staff = 29,
	MagicWand = 30,
	HerosRapier = 31,
	HerosBlade = 32,
	RustySword = 33,
	LegendarySword = 34,
	Katana = 35,
	MysticBlade = 36,
	Chainsaw = 37,
	BambooSword = 38,
	Boken = 39,
	PoliceBaton = 40,
	StunGun = 41,
	BopHammer = 42,
	Sabre = 43,
	Axe = 44,
	CombatKnife = 45,
	ChineseBroadsword = 46,
	Scythe = 47,
	BastardSword = 48,
	OgreBane = 49,
	Rapier = 50,
	Dagger = 51,
	Kodachi = 52,
	Claymore = 53,
	RuneSword = 54,
	RuneShield = 55,
	Buckler = 56,
	VintagePistol = 57,
	VintageRifle = 58,
	AssaultRifle = 59,
	MagazineBullet = 60,
	ShellFired = 61,
	Bullet = 62,
	Longbow = 63,
	IronArrow = 64,
	KunaiBundle = 65,
	Kunai = 66,
	MysticTalismanSetRight = 67,
	MysticTalismanSetLeft = 68,
	MysticTalisman = 69,
	DruidStaff = 70,
	MariannesGrimoire = 71,
	MagicMirror = 72,
	Halberd = 73,
	Warhammer = 74,
	Barbatos = 75,
	Belial = 76,
	HolyLance = 77,
	MechaHandFistRight = 78,
	MechaHandOpenRight = 79,
	MechaHandFistLeft = 80,
	MechaHandOpenLeft = 81,
	SnowflakeWand = 82,
	縄左 = 206,
	縄右 = 207,
}


/// <summary>
/// The index of leg accessories as defined by Illusion.
/// Category index: 362. Illusion name: ao_leg.
/// </summary>
public enum AiLegAccessories // 362 ao_leg
{
	LaceGarterBeltLeft = 0,
	LaceGarterBeltRight = 1,
	TeardropAnklet = 2,
	GarterBeltLeft = 4,
	GarterBeltRight = 5,
	MissangaALeft = 6,
	MissangaARight = 7,
	MissangaBLeft = 8,
	MissangaBRight = 9,
	MechaFootLeft = 10,
	MechaFootRight = 11,
	足縄左 = 201,
	足縄右 = 202,
}


/// <summary>
/// The index of crotch accessories as defined by Illusion.
/// Category index: 363. Illusion name: ao_kokan.
/// </summary>
public enum AiCrotchAccessories // 363 ao_kokan
{
	Dildo = 0,
	Vibrator = 1,
	AnalVibrator = 2,
}