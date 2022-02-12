using AssetRipper.MeshSharp.Elements;
using AssetRipper.MeshSharp.Elements.Geometries;
using AssetRipper.MeshSharp.Elements.Geometries.Layers;
using AssetRipper.MeshSharp.IO;
using System.IO;

namespace AssetRipper.MeshSharp.STL.Readers
{
	internal abstract class StlReaderBase : MeshReaderBase
	{
		public StlReaderBase(Stream stream) : base(stream) { }
		public StlReaderBase(string path) : base(path) { }

		public Scene Read()
		{
			StlTriangle[] triangles = ReadFile();
			Scene result = new();
			result.Name = "LoadedSTL";
			Node root = new();
			root.Name = "Root";
			result.Nodes.Add(root);
			Mesh mesh = ConvertToMesh(triangles);
			root.Children.Add(mesh);
			return result;
		}

		protected abstract StlTriangle[] ReadFile();

		private static Mesh ConvertToMesh(StlTriangle[] triangles)
		{
			Mesh mesh = new Mesh();
			mesh.Name = "CompositeMesh";
			LayerElementNormal normalElement = new LayerElementNormal(mesh);
			mesh.Layers.Add(normalElement);
			normalElement.MappingInformationType = MappingMode.ByPolygon;
			normalElement.ReferenceInformationType = ReferenceMode.Direct;

			foreach (StlTriangle triangle in triangles)
			{
				uint index1 = (uint)AddVertexToList(mesh, triangle.Vertex1);
				uint index2 = (uint)AddVertexToList(mesh, triangle.Vertex2);
				uint index3 = (uint)AddVertexToList(mesh, triangle.Vertex3);
				XYZ normal = triangle.Normal;
				mesh.Polygons.Add(new Triangle(index1, index2, index3));
				normalElement.Normals.Add(normal);
			}
			return mesh;
		}

		private static int AddVertexToList(Mesh mesh, XYZ vertex)
		{
			int index = mesh.Vertices.IndexOf(vertex);
			if (index < 0)
			{
				index = mesh.Vertices.Count;
				mesh.Vertices.Add(vertex);
			}
			return index;
		}
	}
}
