using System.Collections.Generic;

namespace AssetRipper.MeshSharp.Elements.Geometries.Layers
{
	/// <summary>
	/// LayerElementColor
	/// </summary>
	public class LayerElementVertexColor : LayerElement
	{
		public List<XYZM> Colors { get; internal set; } = new List<XYZM>();
		public List<int> ColorIndex { get; internal set; } = new List<int>();
		public LayerElementVertexColor(Geometry owner) : base(owner) { }
	}
}
