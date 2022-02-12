using AssetRipper.MeshSharp.Elements.Geometries.Layers;
using System.Collections.Generic;

namespace AssetRipper.MeshSharp.Elements.Geometries
{
	public class Geometry : Element
	{
		public List<LayerElement> Layers { get; } = new List<LayerElement>();

		public Geometry() : base() { }

		public Geometry(string name) : base(name) { }
	}
}
