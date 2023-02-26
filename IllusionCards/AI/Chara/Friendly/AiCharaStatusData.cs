namespace IllusionCards.AI.Chara.Friendly;

[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public readonly record struct AiCharaStatusData // Status
{
	public AiCharaStatusData() { }
	public Version Version { get; init; } = null!;
	//public byte[] clothesState { get; init; } = null!;
	public ClothingState Top { get; init; }
	public ClothingState Bottom { get; init; }
	public ClothingState InnerTop { get; init; }
	public ClothingState InnerBottom { get; init; }
	public ClothingState Pantyhose { get; init; }
	public ClothingState Gloves { get; init; }
	public ClothingState Socks { get; init; }
	public ClothingState Shoes { get; init; }
	public ImmutableArray<bool> AccessoryIsVisible { get; init; }
	public int EyebrowsExpression { get; init; }
	public float EyebrowsMaximumOpenAmount { get; init; }
	public int EyesExpression { get; init; }
	public float EyesMaximumOpenAmount { get; init; }
	public bool BlinkingEnabled { get; init; }
	public bool Ahegao { get; init; } // eyesYure - not 100% sure if this is the tired/ahagao status
	public int MouthExpression { get; init; }
	public float MouthMinimumOpenAmount { get; init; }
	public float MouthMaximumOpenAmount { get; init; }
	public bool MouthIsFixed { get; init; }
	public bool mouthAdjustWidth { get; init; }
	public byte tongueState { get; init; }
	public EyeLookType EyesLookPosition { get; init; }
	public int eyesTargetType { get; init; }
	public float EyesTargetAngle { get; init; }
	public float EyesTargetRange { get; init; }
	public float EyesTargetRate { get; init; }
	public NeckLookType NeckLookPosition { get; init; }
	public int neckTargetType { get; init; }
	public float neckTargetAngle { get; init; }
	public float neckTargetRange { get; init; }
	public float neckTargetRate { get; init; }
	public bool disableMouthShapeMask { get; init; }
	public bool[,] disableBustShapeMask { get; init; } = null!;
	public float NippleStiffness { get; init; }
	public float SkinGloss { get; init; } // skinTuyaRate
	public float BlushingAmount { get; init; } // hohoAkaRate
	public float TearsAmount { get; init; }
	public bool hideEyesHighlight { get; init; }
	public CumSplatterStatus CumSplatter { get; init; } // siruLv
	public float Wetness { get; init; }
	public bool PenisIsVisible { get; init; } //visibleSon
	public bool PenisIsAlwaysVisible { get; init; } //visibleSonAlways
	public bool HeadIsAlwaysVisible { get; init; }
	public bool BodyIsAlwaysVisible { get; init; }
	public bool IsMonochrome { get; init; } // visibleSimple
	public bool CondomIsVisible { get; init; } // visibleGomu - seems to be for a condom feature that was never implemented, but not 100% sure
	public Color MonochromeColor { get; init; } // simpleColor
	public ImmutableArray<bool> enableShapeHand { get; init; }
	public int[,] shapeHandPtn { get; init; } = null!;
	public ImmutableArray<float> shapeHandBlendValue { get; init; }
	public float AssRednessAmount { get; init; }

	public enum ClothingState
	{
		Full = 0b00,
		Half = 0b01,
		None = 0b10
	}
	public enum EyeLookType
	{
		NO_LOOK,
		TARGET,
		AWAY,
		FORWARD,
		CONTROL
	}
	public enum NeckLookType
	{
		NO_LOOK,
		TARGET,
		AWAY,
		FORWARD,
		FIX,
		CONTROL
	}
}

public readonly record struct CumSplatterStatus
{
	public CumSplatterState Face { get; init; }
	public CumSplatterState Chest { get; init; }
	public CumSplatterState Stomach { get; init; }
	public CumSplatterState Back { get; init; }
	public CumSplatterState Ass { get; init; }
	public enum CumSplatterState
	{
		None = 0b00,
		Half = 0b01,
		Full = 0b10
	}

	public CumSplatterStatus(byte[] cumBytes)
	{
		if (cumBytes.Length != 5) throw new ArgumentException($"Cum splatter array must have exactly 5 bytes, but {cumBytes.Length} were provided.");
		Face = (CumSplatterState)cumBytes[0];
		Chest = (CumSplatterState)cumBytes[1];
		Stomach = (CumSplatterState)cumBytes[2];
		Back = (CumSplatterState)cumBytes[3];
		Ass = (CumSplatterState)cumBytes[4];
	}
}