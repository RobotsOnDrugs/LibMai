namespace IllusionCards.AI.Scene;

public readonly record struct AiScene
{
	public AiScene() { }
	public Version Version { get; init; } = new(1, 1, 1);
	//private HashSet<int> HashIndex { get; init; } = new();
	public ImmutableDictionary<int, AiStudioObject> DicObject { get; init; } = ImmutableDictionary<int, AiStudioObject>.Empty;
	public MapInfo MapInfoData { get; init; }
	public int CGLookupTexture { get; init; }
	public float CGBlend { get; init; }
	public int CGSaturation { get; init; }
	public int CGBrightness { get; init; }
	public int CGContrast { get; init; }
	public bool EnableAmbientOcclusion { get; init; }
	public float AOIntensity { get; init; }
	public float AOThicknessModeifier { get; init; }
	public Color AOColor { get; init; }
	public bool EnableBloom { get; init; }
	public float BloomIntensity { get; init; }
	public float BloomThreshold { get; init; }
	public float BloomSoftKnee { get; init; }
	public bool BloomClamp { get; init; }
	public float BloomDiffusion { get; init; }
	public Color BloomColor { get; init; }
	public bool EnableDepth { get; init; }
	public int DepthForcus { get; init; }
	public float DepthFocalSize { get; init; }
	public float DepthAperture { get; init; }
	public bool EnableVignette { get; init; }
	public float VignetteIntensity { get; init; }
	public bool EnableSSR { get; init; }
	public bool EnableReflectionProbe { get; init; }
	public int ReflectionProbeCubemap { get; init; }
	public float ReflectionProbeIntensity { get; init; }
	public bool EnableFog { get; init; }
	public bool FogExcludeFarPixels { get; init; }
	public float FogHeight { get; init; }
	public float FogHeightDensity { get; init; }
	public Color FogColor { get; init; }
	public float FogDensity { get; init; }
	public bool EnableSunShafts { get; init; }
	public int SunCaster { get; init; }
	public Color SunThresholdColor { get; init; }
	public Color SunColor { get; init; }
	public float SunDistanceFallOff { get; init; }
	public float SunBlurSize { get; init; }
	public float SunIntensity { get; init; }
	public bool EnableShadow { get; init; }
	public Color EnvironmentLightingSkyColor { get; init; }
	public Color EnvironmentLightingEquatorColor { get; init; }
	public Color EnvironmentLightingGroundColor { get; init; }
	public SkyInfo SkyInfoData { get; init; } = new();
	public CameraControl.CameraData CameraSaveData { get; init; } = null!;
	public CameraControl.CameraData[] CameraData { get; init; } = null!;
	public CameraLightCtrl.LightInfo CharaLight { get; init; } = new();
	public CameraLightCtrl.MapLightInfo MapLight { get; init; } = new();
	public BGMCtrl BgmCtrl { get; init; } = new();
	public ENVCtrl EnvCtrl { get; init; } = new();
	public OutsideSoundCtrl OutsideSoundCtrl { get; init; } = new();
	public string Background { get; init; } = null!;
	public string Frame { get; init; } = null!;

	public readonly record struct SkyInfo
	{
	}

	public readonly record struct MapInfo
	{
	}
}
