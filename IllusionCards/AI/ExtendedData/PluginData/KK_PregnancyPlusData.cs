namespace IllusionCards.AI.ExtendedData.PluginData;

	public record KK_PregnancyPlusData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "KK_PregnancyPlus";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("4.7");
			internal readonly Version ClassVersion = new("3.16");
			internal const string RepoURL = "https://github.com/thojmr/KK_PregnancyPlus";
			internal const string ClassDefinitionsURL = "https://github.com/thojmr/KK_PregnancyPlus/blob/5a912edc4b09a2195d2e44d7c08627644f0ebb30/PregnancyPlus/PregnancyPlus.Core/Data/PPData.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; } = typeof(KK_PregnancyPlusOptions);
		public KK_PregnancyPlusOptions Data { get; }
		[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Mirrors original variable names")]
		public readonly struct KK_PregnancyPlusOptions
		{
			public float inflationSize { get; init; }
			public float inflationMoveY { get; init; }
			public float inflationMoveZ { get; init; }
			public float inflationStretchX { get; init; }
			public float inflationStretchY { get; init; }
			public float inflationShiftY { get; init; }
			public float inflationShiftZ { get; init; }
			public float inflationTaperY { get; init; }
			public float inflationTaperZ { get; init; }
			public float inflationMultiplier { get; init; }
			public float inflationClothOffset { get; init; }
			public float inflationFatFold { get; init; }
			public float inflationFatFoldHeight { get; init; }
			public bool GameplayEnabled { get; init; }
			public float inflationRoundness { get; init; }
			public float inflationDrop { get; init; }
			public int clothingOffsetVersion { get; init; }
			public byte[] meshBlendShape { get; init; } = Array.Empty<byte>();
			public ImmutableArray<MeshBlendShape> meshBlendShapes { get; init; } = ImmutableArray<MeshBlendShape>.Empty;
			public Version? pluginVersion { get; init; }
		}
		public record MeshBlendShape
		{
			public string MeshName { get; init; } = null!;
			public int VertCount { get; init; }
			public string UncensorGUID { get; init; } = null!;
			public BlendShapeController.BlendShape BlendShape { get; init; } = null!;
		}
		[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Mirrors original variable names")]
		public record BlendShapeController
		{
			public BlendShape blendShape { get; init; } = null!;
			public SkinnedMeshRenderer smr { get; init; } = null!;

			[MessagePackObject(keyAsPropertyName: true)]
			public record BlendShape
			{
				public string name { get; init; } = null!;
				private float _frameWeight = 100;
				public float frameWeight
				{
					set => _frameWeight = Clamp(value, 0, 100);
					get => _frameWeight <= 0 ? 100 : _frameWeight;
				}
				public float weight { set; get; } = 100;
				public Vector3[] verticies { get; init; } = null!;
				public Vector3[] normals { get; init; } = null!;
				public Vector3[] tangents { get; init; } = null!;
			}
			public class SkinnedMeshRenderer
			{
				public SkinnedMeshRenderer() => throw new NotImplementedException();
			}
		}

		public KK_PregnancyPlusData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		{
			FieldInfo[] _fields = typeof(KK_PregnancyPlusOptions).GetFields();
			object? _tryval;
			for (int i = 0; i < _fields.Length; i++)
			{
				FieldInfo _field = _fields[i];
				switch (_field.FieldType)
				{
					case var x when x == typeof(float):
						_field.SetValue(this, dataDict.TryGetValue(_field.Name, out _tryval) ? (float)_tryval : 0);
						break;
					case var x when x == typeof(bool):
						_field.SetValue(this, !dataDict.TryGetValue(_field.Name, out _tryval) || (bool)_tryval);
						break;
					case var x when x == typeof(int):
						_field.SetValue(this, dataDict.TryGetValue(_field.Name, out _tryval) ? (int)_tryval : 0);
						break;
					case var x when x == typeof(byte[]):
						_field.SetValue(this, dataDict.TryGetValue(_field.Name, out _tryval) ? (byte[])_tryval : 0);
						break;
					case var x when x == typeof(Version):
						_field.SetValue(this, dataDict.TryGetValue(_field.Name, out _tryval) ? new Version((string)_tryval) : null);
						break;
					case var x when x == typeof(ImmutableArray<MeshBlendShape>):
						// Not implementing the logic to deserialize meshBlendShapes yet
						_field.SetValue(this, null);
						break;
					default:
						break;
				}
			}
		}
	}
