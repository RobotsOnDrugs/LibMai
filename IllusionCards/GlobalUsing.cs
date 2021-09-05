global using System.Diagnostics.CodeAnalysis;
global using System.Collections.Immutable;
global using System.Numerics;
global using System.Text;
global using System.Text.Json;
global using System.Xml;
global using System.Reflection;
global using static System.Math;

global using MessagePack;
global using MessagePack.Formatters;
global using MessagePack.Resolvers;
global using NLog;

global using IllusionCards.Util;
global using IllusionCards.FakeUnity;
global using IllusionCards.Cards;
global using IllusionCards.Chara;
global using IllusionCards.AI.Cards;
global using IllusionCards.AI.Chara;
global using IllusionCards.AI.Studio;
global using IllusionCards.AI.ExtendedData.PluginData;
global using static IllusionCards.Util.MathTypesResolver;
global using static IllusionCards.Cards.IllusionCard;
global using static IllusionCards.Chara.IIllusionChara;
global using static IllusionCards.AI.Cards.AiSceneCard;
global using static IllusionCards.AI.Chara.AiCharaType;
global using static IllusionCards.AI.Chara.FriendlyNameLookup;
global using static IllusionCards.AI.Chara.AiFace;