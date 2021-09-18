namespace IllusionCards.FakeUnity;

public static class Mathf
{
	public static float Lerp(in float a, in float b, in float t) => ((1 - t) * a) + (Clamp(t, 0f, 1f) * b);
	public static float InverseLerp(in float a, in float b, in float value) => (value - a) / (b - a);
}
