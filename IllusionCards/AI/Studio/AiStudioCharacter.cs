using System.Collections.Immutable;

using IllusionCards.AI.Chara;

using static IllusionCards.Chara.IIllusionChara;

namespace IllusionCards.AI.Studio
{
	public record AiStudioCharacter : AiStudioObject
	{
		private CharaSex Sex { get => (CharaSex)Chara.Parameter.sex; }
		private int Index { get; init; }
		public override int Kind { get => 0; }
		public AiChara Chara { get; init; }
		public ImmutableDictionary<int, AiStudioBone> Bones { get; init; }
		public ImmutableDictionary<int, IKTarget> IKTargets { get; init; }
		public ImmutableDictionary<int, List<AiStudioObject>> Children { get; init; }
		public AiStudioLookAtTarget LookAtTarget { get; init; }
		public float WetRate { get => Chara.Status.wetRate; }
		public float SkinTuyaRate { get => Chara.Status.skinTuyaRate; }
		public KinematicMode KinematicModeStatus { get; init; }
		public AnimeInfo AnimeInfoStatus { get; init; }
		private ImmutableArray<int> HandPosition { get; init; } = new int[2] { 0, 0 }.ToImmutableArray();
		public int LeftHandPosition { get => HandPosition[0]; }
		public int RightHandPosition { get => HandPosition[1]; }
		public float MouthOpen { get; init; }
		public bool LipSync { get; init; } = true;
		public bool IKEnabled { get; init; }
		private ImmutableArray<bool> ActiveIKArray { get; init; } = new bool[5] { false, false, false, false, false, }.ToImmutableArray();
		public readonly struct ActiveIKStruct
		{
			public bool Body { get; init; }
			public bool RightLeg { get; init; }
			public bool LeftLeg { get; init; }
			public bool RightArm { get; init; }
			public bool LeftArm { get; init; }
		}
		public ActiveIKStruct ActiveIK { get; init; }
		public bool FKEnabled { get; init; }
		private ImmutableArray<bool> ActiveFKArray { get; init; } = new bool[7] { false, false, false, false, false, false, false, }.ToImmutableArray();
		public readonly struct ActiveFKStruct
		{
			public bool Hair { get; init; }
			public bool Neck { get; init; }
			public bool Breast { get; init; }
			public bool Body { get; init; }
			public bool RightHand { get; init; }
			public bool LeftHand { get; init; }
			public bool Skirt { get; init; }
		}
		public AiStudioCharacter(BinaryReader binaryReader) : base(binaryReader)
		{
			int _sex = binaryReader.ReadInt32();
			Chara = AiChara.ParseAiCharaData(binaryReader);
			if ((CharaSex)_sex != Sex)
				throw new InvalidDataException($"Sex data from the scene card {(CharaSex)_sex} does not match character data {Sex}");
			int _numBones = binaryReader.ReadInt32();
			Dictionary<int, AiStudioBone> _bones = new();
			for (int i = 0; i < _numBones; i++)
			{
				int key = binaryReader.ReadInt32();
				_bones[key] = new AiStudioBone(binaryReader);
			}

			Bones = _bones.ToImmutableDictionary();
		}
		public enum IKTargetEN
		{
			Body,
			LeftShoulder,
			LeftArmChain,
			LeftHand,
			RightShoulder,
			RightArmChain,
			RightHand,
			LeftThigh,
			LeftLegChain,
			LeftFoot,
			RightThigh,
			RightLegChain,
			RightFoot
		}
		public enum KinematicMode { None, IK, FK }
		public readonly struct AnimeInfo
		{
			public int Group { get; init; } = -1;
			public int Category { get; init; } = -1;
			public int Number { get; init; } = -1;
			public bool Exists { get => Group != -1 && Category != -1 && Number != -1; }
		}
	}
}
