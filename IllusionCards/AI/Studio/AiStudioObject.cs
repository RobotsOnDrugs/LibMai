
using IllusionCards.FakeUnity;

namespace IllusionCards.AI.Studio
{
	public abstract record AiStudioObject
	{
		public int Key { get; init; }
		public ChangeAmount ChangeAmount { get; init; } = new();
		public TreeNode.TreeState TreeState { get; init; } = TreeNode.TreeState.Closed;
		public bool IsVisible { get; init; } = true;
		public virtual int Kind { get; init; }
		internal Dictionary<int, ChangeAmount> ChangeAmounts { get; init; } = new();
		public Vector3 Position { get; init; }
		public Vector3 Rotation { get; init; }
		public Vector3 Scale { get; init; }
		internal AiStudioObject(BinaryReader binaryReader, int key = -1)
		{
			Key = key;
			Load(binaryReader, out int _dicKey, out Vector3 _pos, out Vector3 _rot, out Vector3 _scale, out TreeNode.TreeState _treeState, out bool _visible);
			_ = _dicKey;
			Position = _pos;
			Rotation = _rot;
			Scale = _scale;
			TreeState = _treeState;
			IsVisible = _visible;
		}
		internal virtual void Load(BinaryReader binaryReader, out int _dicKey, out Vector3 _pos, out Vector3 _rot, out Vector3 _scale, out TreeNode.TreeState _treeState, out bool _visible)
		{
			_dicKey = binaryReader.ReadInt32();
			_pos = new(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			_rot = new(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			_scale = new(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			_treeState = (TreeNode.TreeState)binaryReader.ReadInt32();
			_visible = binaryReader.ReadBoolean();
		}
	}
}
