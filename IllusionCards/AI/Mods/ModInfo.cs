namespace IllusionCards.AI.Mods;

[MessagePackObject]
public record ModInfo
{
	[Key("ModID")]
	public string GUID { get; init; } = null!;
	[Key("Slot")]
	public int Slot { get; init; }
	[Key("LocalSlot")]
	public int LocalSlot { get; init; }
	[Key("Property")]
	public string Property { get; init; } = null!;
	[Key("CategoryNo")]
	public int CategoryNo { get; init; }

	internal static ModInfo Deserialize(byte[] data) => MessagePackSerializer.Deserialize<ModInfo>(data);
	internal byte[] Serialize() => MessagePackSerializer.Serialize(this);
}
