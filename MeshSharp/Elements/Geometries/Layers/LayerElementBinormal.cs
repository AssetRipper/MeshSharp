using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries.Layers
{
    public class LayerElementBinormal : LayerElement
	{
		public List<XYZ> BiNormals { get; } = new List<XYZ>();
		public LayerElementBinormal(Geometry owner) : base(owner) { }
	}
}
