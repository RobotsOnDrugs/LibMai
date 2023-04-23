// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace IllusionCards.AI.Chara.Friendly.Body;

// Indicies in comments refer to a float array in the raw body data and are provided for convenience
// See also AiFriendlyCharaDataConverters.GetAllFriendlyBodyData and AiRawBodyData
public readonly record struct OverallData
{
	public float Height { get; internal init; } // 0
	public float HeadSize { get; init; } // 9
}

public readonly record struct BreastData
{
	public float Size { get; init; } // 1
	public float Height { get; init; } // 2
	public float Direction { get; init; } // 3
	public float Spacing { get; init; } // 4
	public float Angle { get; init; } // 5
	public float Length { get; init; } // 6
	public float Softness { get; init; } // bustSoftness
	public float Weight { get; init; } // bustWeight
	public float AreolaDepth { get; init; } // 7
	public float AreolaSize { get; init; } // areolaSize
	public float NippleWidth { get; init; } // 8
	public float NippleDepth { get; init; } // 32
}

public readonly record struct UpperBodyData
{
	public float NeckWidth { get; init; } // 10
	public float NeckThickness { get; init; } // 11
	public float ShoulderWidth { get; init; } // 12
	public float ShoulderThickness { get; init; } // 13
	public float ChestWidth { get; init; } // 14
	public float ChestThickness { get; init; } // 15
	public float WaistWidth { get; init; } // 16
	public float WaistThickness { get; init; } // 17
}

public readonly record struct LowerBodyData
{
	public float WaistHeight { get; init; } // 18
	public float PelvisWidth { get; init; } // 19
	public float PelvisThickness { get; init; } // 20
	public float HipsWidth { get; init; } // 21
	public float HipsThickness { get; init; } // 22
	public float Butt { get; init; } // 23
	public float ButtAngle { get; init; } // 24
}

public readonly record struct ArmsData
{
	public float Shoulder { get; init; } // 29
	public float UpperArms { get; init; } // 30
	public float Forearm { get; init; } // 31
}

public readonly record struct LegsData
{
	public float UpperThighs { get; init; } // 25
	public float LowerThighs { get; init; } // 26
	public float Calves { get; init; } // 27
	public float Ankles { get; init; } // 28
}

public readonly record struct SkinTypeData
{

}

public readonly record struct SuntanData
{

}

public readonly record struct NipplesData
{

}

public readonly record struct PubicHairData
{

}

public readonly record struct NailColorData
{

}