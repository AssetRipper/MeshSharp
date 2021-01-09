﻿using System.Collections.Generic;

namespace MeshIO.GLTF
{
	/// <summary>
	/// The material appearance of a primitive.
	/// </summary>
	internal class GltfMaterial : GltfNamedAsset
	{
		/// <summary>
		/// A set of parameter values that are used to define the metallic-roughness material model from Physically-Based Rendering (PBR) methodology.
		/// When not specified, all the default values of pbrMetallicRoughness apply.
		/// </summary>
		/// <remarks>
		/// Required: NO
		/// </remarks>
		public GltfPbrMetallicRoughness pbrMetallicRoughness { get; set; }
		/// <summary>
		/// A tangent space normal map.
		/// The texture contains RGB components in linear space. 
		/// Each texel represents the XYZ components of a normal vector in tangent space.
		/// Red [0 to 255] maps to X [-1 to 1]. Green [0 to 255] maps to Y [-1 to 1]. Blue [128 to 255]
		/// maps to Z [1/255 to 1]. The normal vectors use OpenGL conventions where +X is right and +Y 
		/// is up. +Z points toward the viewer. In GLSL, this vector would be unpacked like so: vec3 
		/// normalVector = tex2D("sampled normal map texture value", texCoord) * 2 - 1.
		/// Client implementations should normalize the normal vectors before using them in lighting
		/// equations.
		/// </summary>
		/// <remarks>
		/// Required: NO
		/// </remarks>
		public GltfNormalTextureInfo normalTexture { get; set; }
		/// <summary>
		/// The occlusion map texture. The occlusion values are sampled from the R channel.
		/// Higher values indicate areas that should receive full indirect lighting and lower 
		/// values indicate no indirect lighting. These values are linear. If other channels are 
		/// present (GBA), they are ignored for occlusion calculations.
		/// </summary>
		/// <remarks>
		/// Required: NO
		/// </remarks>
		public GltfOcclusionTextureInfo occlusionTexture { get; set; }
		/// <summary>
		/// The emissive map controls the color and intensity of the light being emitted by the material.
		/// This texture contains RGB components encoded with the sRGB transfer function. If a fourth 
		/// component (A) is present, it is ignored.
		/// </summary>
		/// <remarks>
		/// Required: NO
		/// </remarks>
		public object emissiveTexture { get; set; }
		/// <summary>
		/// The RGB components of the emissive color of the material. These values are linear. If an emissiveTexture is specified, this value is multiplied with the texel values.
		/// </summary>
		/// <remarks>
		/// Required: NO, default: [0,0,0]
		/// </remarks>
		/// <value>
		/// Each element in the array must be greater than or equal to 0 and less than or equal to 1.
		/// </value>
		public List<float> emissiveFactor { get; set; }
		/// <summary>
		/// The material's alpha rendering mode enumeration specifying the interpretation of the alpha value of the main factor and texture.
		/// </summary>
		/// <remarks>
		/// Required: NO, default: "OPAQUE"
		/// </remarks>
		/// <value>
		/// "OPAQUE" The alpha value is ignored and the rendered output is fully opaque.
		/// "MASK" The rendered output is either fully opaque or fully transparent depending on the alpha value and the specified alpha cutoff value.
		/// "BLEND" The alpha value is used to composite the source and destination areas.The rendered output is combined with the background using the normal painting operation(i.e.the Porter and Duff over operator).
		/// </value>
		public string alphaMode { get; set; } = "OPAQUE";
		/// <summary>
		/// Specifies the cutoff threshold when in MASK mode. If the alpha value is greater than or equal 
		/// to this value then it is rendered as fully opaque, otherwise, it is rendered as fully 
		/// transparent. A value greater than 1.0 will render the entire material as fully transparent.
		/// This value is ignored for other modes.
		/// </summary>
		/// <remarks>
		/// Required: NO, default: 0.5
		/// </remarks>
		public float? alphaCutoff { get; set; }
		/// <summary>
		/// Specifies whether the material is double sided. When this value is false, back-face culling is 
		/// enabled. When this value is true, back-face culling is disabled and double sided lighting is 
		/// enabled. The back-face must have its normals reversed before the lighting equation is evaluated.
		/// </summary>
		/// <remarks>
		/// Required: NO, default: false
		/// </remarks>
		public bool? doubleSided { get; set; }
	}
}
