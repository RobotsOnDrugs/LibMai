//https://github.com/ManlyMarco/ABMX
//LGPL 3.0

using System.Collections.Immutable;

using IllusionCards.FakeUnity;

using MessagePack;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record AdvancedBoneModData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "KKABMX.Core";
			internal const string DataKey = "KKABMPlugin.ABMData";
			internal readonly Version PluginVersion = new("4.4.2");
			internal const string RepoURL = "https://github.com/ManlyMarco/ABMX";
			internal const string ClassDefinitionsURL = "https://github.com/ManlyMarco/ABMX/blob/master/Shared/Core/BoneModifierData.cs";
			internal const string License = "LGPL 3.0";
		}
		public override Type DataType { get; init; } = typeof(List<BoneModifier>);
		public ImmutableList<BoneModifier>? Data { get; init; }
		[MessagePackObject]
		public record BoneModifierData
		{
			[Key(0)]
			public Vector3 ScaleModifier;
			[Key(1)]
			public float LengthModifier;
			[Key(2)]
			public Vector3 PositionModifier;
			[Key(3)]
			public Vector3 RotationModifier;
		}
		[MessagePackObject]
		public record BoneModifier
		{
			/// <summary>
			/// Name of the targetted bone
			/// </summary>
			[Key(0)]
			public string BoneName { get; init; } = null!;

			/// <summary>
			/// Actual modifier values, split for different coordinates if required
			/// </summary>
			[Key(1)]
			// Needs a public set to make serializing work
			public BoneModifierData[] CoordinateModifiers { get; init; } = null!;
		}
		public AdvancedBoneModData(Dictionary<object, object> dataDict) : base(dataDict)
		{
			MessagePackSerializerOptions _lz4Option = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);
			Data = dataDict.TryGetValue((object)"boneData", out object? _rawData)
				? MessagePackSerializer.Deserialize<List<BoneModifier>>((byte[])_rawData, _lz4Option).ToImmutableList()
				: null;
		}
	}
}
