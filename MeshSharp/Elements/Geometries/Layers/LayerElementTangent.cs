using System.Collections.Generic;

namespace AssetRipper.MeshSharp.Elements.Geometries.Layers
{
	public class LayerElementTangent : LayerElement
	{
		public List<XYZ> Tangents { get; set; } = new List<XYZ>();
		public LayerElementTangent(Geometry owner) : base(owner) { }
	}
}
