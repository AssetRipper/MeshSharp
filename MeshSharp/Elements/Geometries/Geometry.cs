using MeshSharp.Elements.Geometries.Layers;
using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries
{
    public class Geometry : Element
	{
		public List<LayerElement> Layers { get; set; } = new List<LayerElement>();

		public Geometry() : base() { }

		public Geometry(string name) : base(name) { }
	}
}
