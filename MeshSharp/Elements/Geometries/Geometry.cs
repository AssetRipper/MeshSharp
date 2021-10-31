using MeshSharp.Elements.Geometries.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshSharp.Elements.Geometries
{
	public class Geometry : Element
	{
		public List<LayerElement> Layers { get; set; } = new List<LayerElement>();

		public Geometry() : base() { }

		public Geometry(string name) : base(name) { }
	}
}
