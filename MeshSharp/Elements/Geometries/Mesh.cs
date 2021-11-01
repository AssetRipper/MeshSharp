using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries
{
    public class Mesh : Geometry
	{
		public List<XYZ> Vertices { get; internal set; } = new List<XYZ>();
		public List<Polygon> Polygons { get; internal set; } = new List<Polygon>();

		public Mesh() : base() { }

		public Mesh(string name) : base(name) { }
	}
}
