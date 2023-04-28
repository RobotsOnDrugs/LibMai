global using System.Collections.Immutable;
global using System.Diagnostics.CodeAnalysis;
global using System.Numerics;
global using System.Reflection;
global using System.Text;
global using System.Text.Json;
global using System.Xml;

global using LibMai.Cards.AI.Chara;
global using LibMai.Cards.AI.Chara.Friendly;
global using LibMai.Cards.AI.Chara.Raw;
global using LibMai.Cards.AI.Plugins;
global using LibMai.Cards.AI.Mods;
global using LibMai.Cards.AI.Scene;
global using LibMai.Cards.Illusion;
global using LibMai.Cards.FakeUnity;
global using LibMai.Cards.Illusion;
global using LibMai.Cards.Util;

global using MessagePack;
global using MessagePack.Formatters;
global using MessagePack.Resolvers;

global using NLog;

global using static System.Math;

global using static LibMai.Cards.AI.Cards.AiCharaCardDefinitions;
global using static LibMai.Cards.AI.Cards.AiSceneCard;
global using static LibMai.Cards.AI.Chara.AiCharaVersion;
global using static LibMai.Cards.AI.Chara.Friendly.AiFriendlyCharaDataConverters;
// global using static LibMai.Cards.AI.Chara.Friendly.AiFriendlyNameLookup;
global using static LibMai.Cards.AI.Scene.SceneHelpers;
global using static LibMai.Cards.Illusion.IllusionCard;
global using static LibMai.Cards.FakeUnity.MathTypesResolver;
