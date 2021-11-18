using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries.Layers
{
	public class LayerElementNormal : LayerElement
	{
		public List<XYZ> Normals { get; internal set; } = new List<XYZ>();
		public LayerElementNormal(Geometry owner) : base(owner) { }

		/// <summary>
		/// Calculate a normal vector for each triangle in the mesh
		/// </summary>
		/// <returns>True if successful and false otherwise</returns>
		public bool CalculateFlatNormals()
		{
			if (!(_owner is Mesh mesh))
				return false;

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
			return true;
		}

		/// <summary>
		/// Calculate a normal vector for each vertex in the mesh.<br/>
		/// This will make the mesh appear very smooth, but may cause visual issues where defined edges are intended.
		/// </summary>
		/// <returns>True if successful and false otherwise</returns>
		public bool CalculateVertexNormals()
		{
			if (!(_owner is Mesh mesh))
				return false;

			Normals.Clear();
			MappingInformationType = MappingMode.ByPolygonVertex;
			ReferenceInformationType = ReferenceMode.Direct;

			//Initialize an array for holding the normals during calculation
			int vertexCount = mesh.Vertices.Count;
			var vertexNormals = new XYZ[vertexCount];

			//Calculate the normals
			foreach (Polygon item in mesh.Polygons)
			{
				foreach (Triangle triangle in item.ConvertToTriangles())
				{
					int index0 = (int)triangle.Index0;
					int index1 = (int)triangle.Index1;
					int index2 = (int)triangle.Index2;
					XYZ flatnormal = XYZ.FindNormal(
						mesh.Vertices[index0],
						mesh.Vertices[index1],
						mesh.Vertices[index2]);
					vertexNormals[index0] += flatnormal;
					vertexNormals[index1] += flatnormal;
					vertexNormals[index2] += flatnormal;
				}
			}

			//Normalize the normals
			for(int i = 0; i < vertexCount; i++)
			{
				vertexNormals[i] = vertexNormals[i].Normalize();
			}

			//Reorder by polygon vertex
			foreach (var polygon in mesh.Polygons)
			{
				foreach (uint index in polygon.Indices)
				{
					Normals.Add(vertexNormals[index]);
				}
			}

			return true;
		}
	}
}
