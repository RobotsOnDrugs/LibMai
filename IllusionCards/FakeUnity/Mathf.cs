namespace IllusionCards.FakeUnity;

public static class Mathf
{
	public static float Lerp(float a, float b, float t) => (1 - t) * a + Clamp(t, 0f, 1f) * b;
	public static float InverseLerp(float a, float b, float value) => (value - a) / (b - a);
}
