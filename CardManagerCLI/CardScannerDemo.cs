using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.Security;

using IllusionCards.Cards;
using IllusionCards.AI.Cards;

using NLog;
using NLog.Config;
using NLog.Targets;
using IllusionCards.AI.Plugins;

namespace CardScannerDemo;

public static class CardScannerDemo
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static void Main(string[] args)
	{
		LoggingConfiguration _logconfig = LogManager.Configuration;
		if (_logconfig.LoggingRules.Count != 0)
		{
#if DEBUG
			const string _debugLayout = "[${longdate}][${logger}][${callsite-fileName:includeSourcePath=false}:${callsite-linenumber}] ${level:uppercase=true}: ${message}";
			_logconfig.FindTargetByName<ColoredConsoleTarget>("logcolors").Layout = _debugLayout;
			_logconfig.FindRuleByName("console").SetLoggingLevels(LogLevel.Error, LogLevel.Fatal);
#else
			_logconfig.FindRuleByName("console").SetLoggingLevels(LogLevel.Warn, LogLevel.Fatal);
#endif
		}
		LogManager.Configuration = _logconfig;

		List<FileInfo> CardFiles = new();
		Option<string> cardsOption = new("--cards", "Cards to process") { Arity = ArgumentArity.OneOrMore };
		Option<string> cardListOption = new("--card-list", "Cards to process") { Arity = ArgumentArity.ExactlyOne };
		Option<string> gameDirectoryOption = new("--game-dir", "Game directory") { Arity = ArgumentArity.ExactlyOne };
		Option<bool> scanCharaOption = new("--chara", getDefaultValue: () => false, description: "Scan character cards") { Arity = ArgumentArity.ExactlyOne, IsRequired = false };
		Option<bool> scanCoordinateOption = new("--coordinate", getDefaultValue: () => false, description: "Scan coordinate cards") { Arity = ArgumentArity.ExactlyOne, IsRequired = false };
		Option<bool> scanSceneOption = new("--scene", getDefaultValue: () => false, description: "Scan scene cards") { Arity = ArgumentArity.ExactlyOne, IsRequired = false };
		RootCommand RootCommand = new() { cardsOption, cardListOption, gameDirectoryOption, scanCharaOption, scanCoordinateOption, scanSceneOption };
		RootCommand.Description = "Illusion Card CLI Utility";
		RootCommand.Handler = CommandHandler.Create<string[], string, string, bool, bool, bool>((cards, cardList, gameDir, chara, coordinate, scene) =>
		{
			if (cards.Length != 0)
			{
				Logger.Info("Adding cards from the command line.");
				bool _successArgList = QueueCardsFromArgList(cards, ref CardFiles);
				// if (!_success) { return; }
			}
			if (cardList.Length != 0)
			{
				Logger.Info("Adding cards from the text file.");
				bool _successFileList = QueueCardsFromFile(cardList, ref CardFiles);
				// if (!_success) { return; }
			}
			if (gameDir.Length != 0)
			{
				Logger.Info("Adding cards from the game directory.");
				bool _successGameDir = QueueCardsFromGameDir(gameDir, ref CardFiles, chara, coordinate, scene);
				// if (!_success) { return; }
			}
		});
		RootCommand.Invoke(args);

		ConcurrentBag<IllusionCard> Cards = new();
		ConcurrentBag<string> UnknownPlugins = new();
		Parallel.ForEach(CardFiles, (CardFile) =>
		{
			IllusionCard _card;
			//GC.Collect();
			Logger.Info("Processing {cardfile:l}.", CardFile.Name);
			try
			{
				_card = IllusionCard.NewCard(CardFile);
				Cards.Add(_card);
				if (_card.GetType() == typeof(AiCharaCard))
				{
					AiCharaCard __card = (AiCharaCard)_card;
					ImmutableHashSet<AiPluginData>? _extendedData = __card.Chara.ExtendedData;
					if (_extendedData is not null)
						foreach (AiPluginData pluginData in _extendedData)
							if (pluginData.GetType() == typeof(UnknownPluginData))
								UnknownPlugins.Add(pluginData.GUID);
				}
			}
			catch (UnsupportedCardException ex) { Logger.Error(ex, "Could not parse card: {card}: {reason:l}", ex.CardPath, ex.Message); }
		});
		foreach (string unknownPlugin in UnknownPlugins)
		{
			Logger.Warn(unknownPlugin);
		}
		DevSandbox.Sandbox(Cards); // For internal development use
		LogManager.Shutdown();
		Debugger.Break(); // All done, take a look at the Cards variable
	}

	private static bool QueueCardsFromArgList(string[] args, ref List<FileInfo> cards)
	{
		bool _success = true;
		foreach (string cardPath in args)
		{
			TestFileAccess(cardPath, out FileInfo? _card);
			if (_card is null) { _success = false; break; }
			Logger.Debug("Added {cardPath} to list of cards.", _card.FullName);
			cards.Add(_card);
		}
		return _success;
	}

	private static bool QueueCardsFromFile(string cardList, ref List<FileInfo> cards)
	{
		TestFileAccess(cardList, out FileInfo? _cardListFile);
		if (_cardListFile is null) { return false; }
		using StreamReader _sr = new(cardList);
		string? _line;
		while ((_line = _sr.ReadLine()) is not null)
		{
			TestFileAccess(_line, out FileInfo? _cardFile);
			if (_cardFile is null) { return false; }
			Logger.Debug("Added {cardPath} to list of cards.", _line);
			cards.Add(_cardFile);
		}
		return true;
	}
	private static bool QueueCardsFromGameDir(in string dirPath, ref List<FileInfo> cards, bool chara, bool coordinate, bool scene)
	{
		if (!Directory.Exists(dirPath)) { return false; }
		string _cardsPath;
		List<string> _potentialCardFiles = new();
		List<string> _paths = new();
		if (!chara && !coordinate && !scene)
		{
			_cardsPath = Path.Join(dirPath, "UserData");
			_potentialCardFiles.AddRange(Directory.EnumerateFiles(_cardsPath, "*.png", enumerationOptions: new() { AttributesToSkip = FileAttributes.Device | FileAttributes.System, RecurseSubdirectories = true, IgnoreInaccessible = true }));
		}
		if (chara)
			_paths.Add(Path.Join(dirPath, "UserData", "chara", "female", ".testing"));
		if (coordinate)
			_paths.Add(Path.Join(dirPath, "UserData", "coordinate"));
		if (scene)
			_paths.Add(Path.Join(dirPath, "UserData", "studio", "scene"));
		foreach (string path in _paths)
		{
			_potentialCardFiles.AddRange(Directory.EnumerateFiles(path, "*.png", enumerationOptions: new() { AttributesToSkip = FileAttributes.Device | FileAttributes.System, RecurseSubdirectories = true, IgnoreInaccessible = true }));
		}
		foreach (string potentialCardFile in _potentialCardFiles)
		{
			Logger.Debug("Added {cardPath} to list of cards.", potentialCardFile);
			cards.Add(new FileInfo(potentialCardFile));
		}
		return true;
	}

	private static void TestFileAccess(in string filePath, out FileInfo? fileInfo)
	{
		FileInfo? _fileInfo = default;
		try
		{
			if (!File.Exists(filePath)) { throw new FileNotFoundException(); }
			_fileInfo = new(filePath);
		}
		catch (Exception ex) when (ex is SecurityException
			or UnauthorizedAccessException
			or NotSupportedException
			or FileNotFoundException)
		{ Logger.Error(ex, "{filePath} could not be accessed: {reason:l}", filePath, ex.Message); }
		fileInfo = _fileInfo;
	}
}
