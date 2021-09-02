using IllusionCards.FakeUnity;

namespace IllusionCards.AI.Studio
{
	public abstract record AiStudioObject
	{
		public int Key { get; init; }
		public ChangeAmount ChangeAmount { get; init; } = new();
		public TreeNode.TreeState TreeState { get; init; } = TreeNode.TreeState.Closed;
		public bool Visible { get; init; } = true;
		public virtual int Kind { get; init; }
		internal Dictionary<int, ChangeAmount> ChangeAmounts { get; init; } = new();
		public Vector3 Position { get; init; }
		public Vector3 Rotation { get; init; }
		public Vector3 Scale { get; init; }
		internal AiStudioObject(BinaryReader binaryReader, bool hasTreeStateAndVisiblity = true, int key = -1)
		{
			Key = key;
			_ = binaryReader.ReadInt32();
			Position = new(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			Rotation = new(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			Scale = new(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			if (!hasTreeStateAndVisiblity)
				return;
			TreeState = (TreeNode.TreeState)binaryReader.ReadInt32();
			Visible = binaryReader.ReadBoolean();
		}
	}
}
