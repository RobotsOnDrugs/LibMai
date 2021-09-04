using System.Collections.Immutable;
using System.Numerics;

using IllusionCards.FakeUnity;

using MessagePack;

using static IllusionCards.Util.MathTypesResolver;

namespace IllusionCards.AI.ExtendedData.PluginData
{
	public record MaterialEditorData : ExtendedPluginData
	{
		public const string DataKey = DefinitionMetadata.DataKey;
		private readonly struct DefinitionMetadata
		{
			internal const string PluginGUID = "com.deathweasel.bepinex.materialeditor";
			internal const string DataKey = PluginGUID;
			internal readonly Version PluginVersion = new("1.0");
			internal const string RepoURL = "https://github.com/IllusionMods/KK_Plugins";
			internal const string recordDefinitionsURL = "https://github.com/IllusionMods/KK_Plugins/blob/master/src/MaterialEditor.Core/Core.MaterialEditor.CharaController.cs";
			internal const string License = "GPL 3.0";
		}
		public override Type DataType { get; } = typeof(MaterialEditorOptions);
		public readonly struct MaterialEditorOptions
		{
			public readonly ImmutableArray<RendererProperty> RendererPropertyList { get; init; }
			public readonly ImmutableArray<MaterialFloatProperty> MaterialFloatPropertyList { get; init; }
			public readonly ImmutableArray<MaterialColorProperty> MaterialColorPropertyList { get; init; }
			public readonly ImmutableArray<MaterialTextureProperty> MaterialTexturePropertyList { get; init; }
			public readonly ImmutableArray<MaterialShader> MaterialShaderList { get; init; }
			public readonly ImmutableArray<MaterialCopy> MaterialCopyList { get; init; }
			public readonly ImmutableDictionary<int, TextureContainer> TextureDictionary { get; init; }
		}

		public MaterialEditorOptions Data { get; init; }

		/// <summary>
		/// Type of object, used for saving MaterialEditor data.
		/// </summary>
		public enum ObjectType
		{
			/// <summary>
			/// Unknown type, things should never be of this type
			/// </summary>
			Unknown,
			/// <summary>
			/// Clothing
			/// </summary>
			Clothing,
			/// <summary>
			/// Accessory
			/// </summary>
			Accessory,
			/// <summary>
			/// Hair
			/// </summary>
			Hair,
			/// <summary>
			/// Parts of a character
			/// </summary>
			Character
		};
		/// <summary>
		/// Data storage record for renderer properties
		/// </summary>
		[MessagePackObject]
		public record RendererProperty
		{
			/// <summary>
			/// Type of the object
			/// </summary>
			[Key("ObjectType")]
			public ObjectType ObjectType { get; init; }
			/// <summary>
			/// Coordinate index, always 0 except in Koikatsu
			/// </summary>
			[Key("CoordinateIndex")]
			public int CoordinateIndex { get; init; }
			/// <summary>
			/// Slot of the accessory, hair, or clothing
			/// </summary>
			[Key("Slot")]
			public int Slot { get; init; }
			/// <summary>
			/// Name of the renderer
			/// </summary>
			[Key("RendererName")]
			public string RendererName { get; init; } = null!;
			/// <summary>
			/// Property type
			/// </summary>
			[Key("Property")]
			public RendererProperties Property { get; init; }
			/// <summary>
			/// Value
			/// </summary>
			[Key("Value")]
			public string Value { get; init; } = null!;
			/// <summary>
			/// Original value
			/// </summary>
			[Key("ValueOriginal")]
			public string ValueOriginal { get; init; } = null!;
		}

		/// <summary>
		/// Data storage record for float properties
		/// </summary>
		[MessagePackObject]
		public record MaterialFloatProperty
		{
			/// <summary>
			/// Type of the object
			/// </summary>
			[Key("ObjectType")]
			public ObjectType ObjectType { get; init; }
			/// <summary>
			/// Coordinate index, always 0 except in Koikatsu
			/// </summary>
			[Key("CoordinateIndex")]
			public int CoordinateIndex { get; init; }
			/// <summary>
			/// Slot of the accessory, hair, or clothing
			/// </summary>
			[Key("Slot")]
			public int Slot;
			/// <summary>
			/// Name of the material
			/// </summary>
			[Key("MaterialName")]
			public string MaterialName { get; init; } = null!;
			/// <summary>
			/// Name of the property
			/// </summary>
			[Key("Property")]
			public string Property { get; init; } = null!;
			/// <summary>
			/// Value
			/// </summary>
			[Key("Value")]
			public string Value { get; init; } = null!;
			/// <summary>
			/// Original value
			/// </summary>
			[Key("ValueOriginal")]
			public string ValueOriginal { get; init; } = null!;
		}

		/// <summary>
		/// Data storage record for color properties
		/// </summary>
		[MessagePackObject]
		public record MaterialColorProperty
		{
			/// <summary>
			/// Type of the object
			/// </summary>
			[Key("ObjectType")]
			public ObjectType ObjectType { get; init; }
			/// <summary>
			/// Coordinate index, always 0 except in Koikatsu
			/// </summary>
			[Key("CoordinateIndex")]
			public int CoordinateIndex { get; init; }
			/// <summary>
			/// Slot of the accessory, hair, or clothing
			/// </summary>
			[Key("Slot")]
			public int Slot { get; init; }
			/// <summary>
			/// Name of the material
			/// </summary>
			[Key("MaterialName")]
			public string MaterialName { get; init; } = null!;
			/// <summary>
			/// Name of the property
			/// </summary>
			[Key("Property")]
			public string Property { get; init; } = null!;
			/// <summary>
			/// Value
			/// </summary>
			[Key("Value")]
			public Color Value { get; init; }
			/// <summary>
			/// Original value
			/// </summary>
			[Key("ValueOriginal")]
			public Color ValueOriginal { get; init; }
		}

		/// <summary>
		/// Data storage record for texture properties
		/// </summary>
		[MessagePackObject]
		public record MaterialTextureProperty
		{
			/// <summary>
			/// Type of the object
			/// </summary>
			[Key("ObjectType")]
			public ObjectType ObjectType { get; init; }
			/// <summary>
			/// Coordinate index, always 0 except in Koikatsu
			/// </summary>
			[Key("CoordinateIndex")]
			public int CoordinateIndex { get; init; }
			/// <summary>
			/// Slot of the accessory, hair, or clothing
			/// </summary>
			[Key("Slot")]
			public int Slot { get; init; }
			/// <summary>
			/// Name of the material
			/// </summary>
			[Key("MaterialName")]
			public string MaterialName { get; init; } = null!;
			/// <summary>
			/// Name of the property
			/// </summary>
			[Key("Property")]
			public string Property { get; init; } = null!;
			/// <summary>
			/// ID of the texture as stored in the texture dictionary
			/// </summary>
			[Key("TexID")]
			public int? TexID { get; init; }
			/// <summary>
			/// Texture offset value
			/// </summary>
			[Key("Offset")]
			public Vector2? Offset { get; init; }
			/// <summary>
			/// Texture offset original value
			/// </summary>
			[Key("OffsetOriginal")]
			public Vector2? OffsetOriginal { get; init; }
			/// <summary>
			/// Texture scale value
			/// </summary>
			[Key("Scale")]
			public Vector2? Scale { get; init; }
			/// <summary>
			/// Texture scale original value
			/// </summary>
			[Key("ScaleOriginal")]
			public Vector2? ScaleOriginal { get; init; }
		}

		/// <summary>
		/// Data storage record for shader data
		/// </summary>
		[MessagePackObject]
		public record MaterialShader
		{
			/// <summary>
			/// Type of the object
			/// </summary>
			[Key("ObjectType")]
			public ObjectType ObjectType { get; init; }
			/// <summary>
			/// Coordinate index, always 0 except in Koikatsu
			/// </summary>
			[Key("CoordinateIndex")]
			public int CoordinateIndex { get; init; }
			/// <summary>
			/// Slot of the accessory, hair, or clothing
			/// </summary>
			[Key("Slot")]
			public int Slot { get; init; }
			/// <summary>
			/// Name of the material
			/// </summary>
			[Key("MaterialName")]
			public string MaterialName { get; init; } = null!;
			/// <summary>
			/// Name of the shader
			/// </summary>
			[Key("ShaderName")]
			public string ShaderName { get; init; } = null!;
			/// <summary>
			/// Name of the original shader
			/// </summary>
			[Key("ShaderNameOriginal")]
			public string ShaderNameOriginal;
			/// <summary>
			/// Render queue
			/// </summary>
			[Key("RenderQueue")]
			public int? RenderQueue { get; init; }
			/// <summary>
			/// Original render queue
			/// </summary>
			[Key("RenderQueueOriginal")]
			public int? RenderQueueOriginal { get; init; }

			/// <summary>
			/// Data storage record for shader data
			/// </summary>
			/// <param name="objectType">Type of the object</param>
			/// <param name="coordinateIndex">Coordinate index, always 0 except in Koikatsu</param>
			/// <param name="slot">Slot of the accessory, hair, or clothing</param>
			/// <param name="materialName">Name of the material</param>
			/// <param name="shaderName">Name of the shader</param>
			/// <param name="shaderNameOriginal">Name of the original shader</param>
			/// <param name="renderQueue">Render queue</param>
			/// <param name="renderQueueOriginal">Original render queue</param>
			public MaterialShader(ObjectType objectType, int coordinateIndex, int slot, string materialName, string shaderName, string shaderNameOriginal, int? renderQueue, int? renderQueueOriginal)
			{
				ObjectType = objectType;
				CoordinateIndex = coordinateIndex;
				Slot = slot;
				MaterialName = materialName.Replace("(Instance)", "").Trim();
				ShaderName = shaderName;
				ShaderNameOriginal = shaderNameOriginal;
				RenderQueue = renderQueue;
				RenderQueueOriginal = renderQueueOriginal;
			}
		}

		[MessagePackObject]
		public record MaterialCopy
		{
			/// <summary>
			/// Type of the object
			/// </summary>
			[Key("ObjectType")]
			public ObjectType ObjectType { get; init; }
			/// <summary>
			/// Coordinate index, always 0 except in Koikatsu
			/// </summary>
			[Key("CoordinateIndex")]
			public int CoordinateIndex { get; init; }
			/// <summary>
			/// Slot of the accessory, hair, or clothing
			/// </summary>
			[Key("Slot")]
			public int Slot { get; init; }
			/// <summary>
			/// Name of the material
			/// </summary>
			[Key("MaterialName")]
			public string MaterialName { get; init; } = null!;
			/// <summary>
			/// Name of the copy
			/// </summary>
			[Key("MaterialCopyName")]
			public string MaterialCopyName { get; init; } = null!;
		}
		/// <summary>
		/// Properties of a renderer that can be set
		/// </summary>
		public enum RendererProperties
		{
			/// <summary>
			/// Whether the renderer is enabled
			/// </summary>
			Enabled,
			/// <summary>
			/// ShadowCastingMode of the renderer
			/// </summary>
			ShadowCastingMode,
			/// <summary>
			/// Whether the renderer will receive shadows cast by other objects
			/// </summary>
			ReceiveShadows
		}
		/// <summary>
		/// A record for containing texture data, stored as a byte array. Access the texture with the Texture property and use Dispose to safely destroy it and prevent memory leaks.
		/// </summary>
		public record TextureContainer
		{
			/// <summary>
			/// Load a byte array containing texture data.
			/// </summary>
			/// <param name="data"></param>
			public TextureContainer(byte[] data) => Data = data;

			/// <summary>
			/// Byte array containing the texture data.
			/// </summary>
			public byte[] Data { get; init; }

			/// <summary>
			/// Texture data. Created from the Data byte array when accessed.
			/// Additional note for IC library: Not going to recreate the Texture object here unless it becomes necessary.
			/// </summary>
			//public Texture? Texture { get; init; } = null;

			/// <summary>
			/// Convert a byte array to Texture2D.
			/// </summary>
			/// <param name="texBytes">Byte array containing the image</param>
			/// <param name="format">TextureFormat</param>
			/// <param name="mipmaps">Whether to generate mipmaps</param>
			/// <returns></returns>
			//private static Texture TextureFromBytes(byte[] texBytes, TextureFormat format = TextureFormat.ARGB32, bool mipmaps = true)
			//{
			//    if (texBytes == null || texBytes.Length == 0) return null;

			//    //LoadImage automatically resizes the texture so the texture size doesn't matter here
			//    var tex = new Texture2D(2, 2, format, mipmaps);
			//    tex.LoadImage(texBytes);

			//    RenderTexture rt = new RenderTexture(tex.width, tex.height, 0);
			//    rt.useMipMap = mipmaps;
			//    RenderTexture.active = rt;
			//    Graphics.Blit(tex, rt);

			//    return rt;
			//}
		}
		public MaterialEditorData(int version, Dictionary<object, object> dataDict) : base(version, dataDict)
		{
			MessagePackSerializer.DefaultOptions = WithMathTypes;
			Dictionary<int, TextureContainer> _texDict = new();
			Dictionary<int, byte[]> _rawTexDict = dataDict.TryGetValue("TextureDictionary", out object? _tryval) && (_tryval is not null) ?
				MessagePackSerializer.Deserialize<Dictionary<int, byte[]>>((byte[])_tryval) : new();
			foreach (KeyValuePair<int, byte[]> rawKvp in _rawTexDict)
				_texDict.Add(rawKvp.Key, new(rawKvp.Value));

			IEnumerable<RendererProperty> _rendererProperties = dataDict.TryGetValue("RendererPropertyList", out _tryval) && (_tryval is not null) ?
				MessagePackSerializer.Deserialize<IEnumerable<RendererProperty>>((byte[])_tryval) : Array.Empty<RendererProperty>();
			IEnumerable<MaterialFloatProperty> _materialFloatProperties = dataDict.TryGetValue("MaterialFloatPropertyList", out _tryval) && (_tryval is not null) ?
				MessagePackSerializer.Deserialize<IEnumerable<MaterialFloatProperty>>((byte[])_tryval) : Array.Empty<MaterialFloatProperty>();
			IEnumerable<MaterialTextureProperty> _materialTextureProperties = dataDict.TryGetValue("MaterialTexturePropertyList", out _tryval) && (_tryval is not null) ?
				MessagePackSerializer.Deserialize<IEnumerable<MaterialTextureProperty>>((byte[])_tryval) : Array.Empty<MaterialTextureProperty>();
			IEnumerable<MaterialColorProperty> _materialColorProperties = dataDict.TryGetValue("MaterialColorPropertyList", out _tryval) && (_tryval is not null) ?
				MessagePackSerializer.Deserialize<IEnumerable<MaterialColorProperty>>((byte[])_tryval) : Array.Empty<MaterialColorProperty>();
			IEnumerable<MaterialShader> _materialShaders = dataDict.TryGetValue("MaterialShaderList", out _tryval) && (_tryval is not null) ?
				MessagePackSerializer.Deserialize<IEnumerable<MaterialShader>>((byte[])_tryval) : Array.Empty<MaterialShader>();
			IEnumerable<MaterialCopy> _materialCopies = dataDict.TryGetValue("MaterialCopyList", out _tryval) && (_tryval is not null) ?
				MessagePackSerializer.Deserialize<IEnumerable<MaterialCopy>>((byte[])_tryval) : Array.Empty<MaterialCopy>();


			Data = new MaterialEditorOptions()
			{
				TextureDictionary = _texDict.ToImmutableDictionary(),
				RendererPropertyList = _rendererProperties.ToImmutableArray(),
				MaterialFloatPropertyList = _materialFloatProperties.ToImmutableArray(),
				MaterialTexturePropertyList = _materialTextureProperties.ToImmutableArray(),
				MaterialColorPropertyList = _materialColorProperties.ToImmutableArray(),
				MaterialShaderList = _materialShaders.ToImmutableArray(),
				MaterialCopyList = _materialCopies.ToImmutableArray()
			};
		}
	}
}
