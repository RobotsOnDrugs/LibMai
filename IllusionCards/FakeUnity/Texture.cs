namespace IllusionCards.FakeUnity;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Mirrors original variable names")]
public readonly struct Texture
{
	public int anisoLevel { get; init; }
	public AnisotropicFiltering anisotropicFiltering { get; init; }
	public ulong currentTextureMemory { get; init; }
	public ulong desiredTextureMemory { get; init; }
	public TextureDimension dimension { get; init; }
	public FilterMode filterMode { get; init; }
	public int height { get; init; }
	public bool isReadable { get; init; }
	public int masterTextureLimit { get; init; }
	public float mipMapBias { get; init; }
	public ulong nonStreamingTextureCount { get; init; }
	public ulong nonStreamingTextureMemory { get; init; }
	public ulong streamingMipmapUploadCount { get; init; }
	public ulong streamingRendererCount { get; init; }
	public ulong streamingTextureCount { get; init; }
	public bool streamingTextureDiscardUnusedMips { get; init; }
	public bool streamingTextureForceLoadAll { get; init; }
	public ulong streamingTextureLoadingCount { get; init; }
	public ulong streamingTexturePendingLoadCount { get; init; }
	public ulong targetTextureMemory { get; init; }
	public Vector2 texelSize { get; init; }
	public ulong totalTextureMemory { get; init; }
	public uint updateCount { get; init; }
	public int width { get; init; }
	public TextureWrapMode wrapMode { get; init; }
	public TextureWrapMode wrapModeU { get; init; }
	public TextureWrapMode wrapModeV { get; init; }
	public TextureWrapMode wrapModeW { get; init; }
}
