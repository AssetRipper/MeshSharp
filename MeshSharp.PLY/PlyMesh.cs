using MeshSharp.Elements.Geometries;
using System.Collections.Generic;
using System.Text;

namespace MeshSharp.PLY
{
	internal class PlyMesh
	{
		private readonly List<XYZ> vertices = new List<XYZ>();
		private readonly List<Polygon> polygons = new List<Polygon>();

		public int VertexCount => vertices.Count;
		public int PolygonCount => polygons.Count;

		internal static PlyMesh ConvertFromMeshes(List<Mesh> meshes)
		{
			PlyMesh result = new PlyMesh();
			result.ReadFromMeshes(meshes);
			return result;
		}

		private void ReadFromMeshes(List<Mesh> meshes)
		{
			foreach (Mesh mesh in meshes)
			{
				foreach (XYZ vertex in mesh.Vertices)
				{
					if (!vertices.Contains(vertex))
						vertices.Add(vertex);
				}
				foreach (Polygon polygon in mesh.Polygons)
				{
					uint[] newIndices = new uint[polygon.Indices.Length];
					for (uint i = 0; i < newIndices.Length; i++)
					{
						newIndices[i] = (uint)vertices.IndexOf(mesh.Vertices[(int)polygon.Indices[i]]);
					}
					polygons.Add(new Polygon(newIndices));
				}
			}
		}

		public string ToAsciiString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (XYZ vertex in vertices)
			{
				sb.AppendLine($"{vertex.X} {vertex.Y} {vertex.Z}");
			}
			foreach (Polygon polygon in polygons)
			{
				sb.Append(polygon.Indices.Length);
				foreach (uint index in polygon.Indices)
				{
					sb.Append($" {index}");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}
