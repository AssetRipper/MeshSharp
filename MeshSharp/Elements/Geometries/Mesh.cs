using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries
{
    public class Mesh : Geometry
	{
		public List<XYZ> Vertices { get; } = new List<XYZ>();
		public List<Polygon> Polygons { get; } = new List<Polygon>();

		public Mesh() : base() { }

		public Mesh(string name) : base(name) { }
	}
}
