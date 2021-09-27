namespace IllusionCards;

public static class GenChaListDataLookupMethods
{
	// This is a quick-and-dirtyish program to deserialize extracted data to ChaListData objects and generate C Sharp static methods for IllusionCards.AI.Chara.Friendly.AiFriendlyNameLookup
	// The data can be extracted from abdata\list\characustom unity3d files using uTinyRipper
	public static void Main()
	{

		Dictionary<AI.Chara.Raw.CategoryNo, Dictionary<int, string>> chaListData = new();
		const string fpath = "/path/AiFriendlyItemLookup.cs";
		using StreamWriter outputFile = new(Path.Combine(fpath));
		outputFile.WriteLine("namespace IllusionCards.AI.Chara.Friendly;");
		outputFile.WriteLine();
		outputFile.WriteLine("public static partial class AiFriendlyNameLookup");
		outputFile.WriteLine("{");
		var list1 = Directory.EnumerateFiles("/path1", "*.bytes");
		var list2 = Directory.EnumerateFiles("/path2", "*.bytes");
		var allBytes = list1.Concat(list2);
		foreach (string listPath in allBytes)
		{
			using FileStream _fstream = new(listPath, FileMode.Open);
			byte[] rawlist = new byte[_fstream.Length];
			_fstream.Read(rawlist);
			var data = MessagePack.MessagePackSerializer.Deserialize<AI.Chara.Raw.AiRawListData>(rawlist);
			foreach (int ID in data.dictList.Keys)
			{
				var cat = (AI.Chara.Raw.CategoryNo)data.categoryNo;
				int enusKey = 1000;
				int jpKey = 1000;
				for (int i = 0; i < data.lstKey.Count; i++)
				{
					if (data.lstKey[i] == "EN_US") enusKey = i;
					if (data.lstKey[i] == "Name") jpKey = i;
				}
				string _nameEn = data.dictList[ID][enusKey];
				string _nameJp = data.dictList[ID][jpKey];
				if (chaListData.ContainsKey(cat))
				{
					if (chaListData[cat].ContainsKey(ID))
						chaListData[cat][ID] = int.TryParse(_nameEn, out _) ? _nameJp : _nameEn;
					else chaListData[(AI.Chara.Raw.CategoryNo)data.categoryNo].Add(ID, _nameEn);
				}
				else chaListData.Add((AI.Chara.Raw.CategoryNo)data.categoryNo, new() { { ID, data.dictList[ID][enusKey] } });
			}
		}
		var catList = chaListData.Keys.ToList();
		catList.Sort();
		foreach (AI.Chara.Raw.CategoryNo cat in catList)
		{
			outputFile.WriteLine($"\tpublic static string Get_{cat}(in int itemID) => itemID switch // {(int)cat} {cat}");
			outputFile.WriteLine("\t{");
			foreach (KeyValuePair<int, string> kvp in chaListData[cat])
				outputFile.WriteLine($"\t\t{kvp.Key} => \"{kvp.Value}\",");
			outputFile.WriteLine("\t\t_ => \"Unknown\"");
			outputFile.WriteLine("\t};");
		}
		outputFile.WriteLine("}");
	}
}