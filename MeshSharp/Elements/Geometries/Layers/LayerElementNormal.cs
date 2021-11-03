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
				XYZ normal = XYZ.Zero;
				foreach (Triangle triangle in item.ConvertToTriangles())
                {
					XYZ subnormal = XYZ.FindNormal(
						mesh.Vertices[(int)triangle.Index0],
						mesh.Vertices[(int)triangle.Index1],
						mesh.Vertices[(int)triangle.Index2]);
					normal += subnormal;
				}

				Normals.Add(normal.Normalize());
			}
		}
	}
}
