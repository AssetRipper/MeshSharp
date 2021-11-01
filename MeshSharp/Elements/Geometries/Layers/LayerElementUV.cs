using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries.Layers
{
    public class LayerElementUV : LayerElement
	{
		public List<XY> UV { get; } = new List<XY>();
		public List<int> UVIndex { get; } = new List<int>();
		public LayerElementUV(Geometry owner) : base(owner) { }
	}
}
