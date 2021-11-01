using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries.Layers
{
    public class LayerElementNormal : LayerElement
	{
		public List<XYZ> Normals { get; internal set; } = new List<XYZ>();
		public LayerElementNormal(Geometry owner) : base(owner) { }

		public void CalculateFlatNormals()
		{
			if (!(_owner is Mesh mesh))
				return;

			Normals.Clear();

			MappingInformationType = MappingMode.ByPolygon;
			ReferenceInformationType = ReferenceMode.Direct;

			foreach (Polygon item in mesh.Polygons)
			{
				XYZ normal = XYZ.FindNormal(
					mesh.Vertices[item.ToArray()[0]],
					mesh.Vertices[item.ToArray()[1]],
					mesh.Vertices[item.ToArray()[2]]);

				Normals.Add(normal.Normalize());
			}
		}
	}
}
