using MeshSharp.Elements.Geometries;
using System.Collections.Generic;
using System.Text;

namespace MeshSharp.OBJ
{
	internal class ObjMesh
	{
		private string Name = "ObjMesh";
		private readonly List<XYZ> vertices = new List<XYZ>();
		private readonly List<Polygon> polygons = new List<Polygon>();

		internal static ObjMesh ConvertFromMeshes(List<Mesh> meshes)
		{
			ObjMesh result = new ObjMesh();
			result.ReadFromMeshes(meshes);
			return result;
		}

		private void ReadFromMeshes(List<Mesh> meshes)
		{
			if (meshes.Count == 1 && !string.IsNullOrEmpty(meshes[0].Name))
			{
				Name = meshes[0].Name;
			}

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
						//Note: OBJ indices start at 1, not 0
						newIndices[i] = (uint)vertices.IndexOf(mesh.Vertices[(int)polygon.Indices[i]]) + 1;
					}
					polygons.Add(new Polygon(newIndices));
				}
			}
		}

		public string ToAsciiString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"g {Name}");
			foreach (XYZ vertex in vertices)
			{
				sb.AppendLine($"v {vertex.X} {vertex.Y} {vertex.Z}");
			}
			foreach (Polygon polygon in polygons)
			{
				sb.Append('f');
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
