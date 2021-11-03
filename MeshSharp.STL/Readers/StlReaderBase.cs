using MeshSharp.Elements;
using MeshSharp.Elements.Geometries;
using MeshSharp.Elements.Geometries.Layers;
using System;
using System.IO;

namespace MeshSharp.STL.Readers
{
	internal abstract class StlReaderBase : IDisposable
	{
		private bool disposedValue;
		protected Stream stream;

		public StlReaderBase(Stream stream)
		{
			this.stream = stream;
		}
		public StlReaderBase(string path) : this(File.OpenRead(path)) { }

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

		#region Disposal
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					stream?.Dispose();
				}

				stream = null;
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
