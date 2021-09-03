using System.Diagnostics.CodeAnalysis;

namespace IllusionCards.FakeUnity
{
	[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Lower case is the convention for math objects")]
	public readonly struct Quarternion
	{
		public float x { get; init; }
		public float y { get; init; }
		public float z { get; init; }
		public float w { get; init; }
		public Quarternion(BinaryReader binaryReader)
		{
			x = binaryReader.ReadSingle();
			y = binaryReader.ReadSingle();
			z = binaryReader.ReadSingle();
			w = binaryReader.ReadSingle();
		}
	}
}
