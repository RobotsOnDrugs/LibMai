
using IllusionCards.FakeUnity;

namespace IllusionCards.AI.Studio
{
	public abstract record AiStudioObject
	{
		public Vector3 Position { get; init; }
		public Vector3 Rotation { get; init; }
		public Vector3 Scale { get; init; }
		public TreeNode.TreeState TreeState { get; init; }
		public bool IsVisible { get; init; }
		internal AiStudioObject(BinaryReader binaryReader)
		{
			_ = binaryReader.ReadInt32();
			Position = new()
			{
				x = binaryReader.ReadSingle(),
				y = binaryReader.ReadSingle(),
				z = binaryReader.ReadSingle()
			};
			Rotation = new()
			{
				x = binaryReader.ReadSingle(),
				y = binaryReader.ReadSingle(),
				z = binaryReader.ReadSingle()
			};
			Scale = new()
			{
				x = binaryReader.ReadSingle(),
				y = binaryReader.ReadSingle(),
				z = binaryReader.ReadSingle()
			};
			TreeState = (TreeNode.TreeState)binaryReader.ReadInt32();
			IsVisible = binaryReader.ReadBoolean();
		}
	}
}
