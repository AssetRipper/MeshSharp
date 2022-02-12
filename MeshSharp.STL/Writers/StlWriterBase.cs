using AssetRipper.MeshSharp.Elements;
using AssetRipper.MeshSharp.Elements.Geometries;
using AssetRipper.MeshSharp.Elements.Geometries.Layers;
using AssetRipper.MeshSharp.IO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AssetRipper.MeshSharp.STL.Writers
{
	internal abstract class StlWriterBase : MeshWriterBase
	{
		public StlWriterBase(Stream stream) : base(stream) { }
		public StlWriterBase(string path) : base(path) { }

		public abstract void Write(Scene scene);

		protected static List<StlTriangle> ConvertToStlTriangles(Scene scene)
		{
			List<Mesh> meshes = MeshUtils.GetAllMeshes(scene);
			return ConvertToStlTriangles(meshes);
		}

		private static List<StlTriangle> ConvertToStlTriangles(List<Mesh> meshes)
		{
			List<StlTriangle> result = new List<StlTriangle>();
			foreach (Mesh mesh in meshes)
			{
				result.AddRange(ConvertToStlTriangles(mesh));
			}
			return result;
		}

		private static List<StlTriangle> ConvertToStlTriangles(Mesh mesh)
		{
			LayerElementNormal normalElement = (LayerElementNormal)mesh.Layers.FirstOrDefault(layer => HasCompatibleNormalValues(layer as LayerElementNormal));
			bool hasNormal = normalElement != null;
			//Console.WriteLine($"Has normals: {hasNormal}");
			List<StlTriangle> result = new List<StlTriangle>();
			for (int i = 0; i < mesh.Polygons.Count; i++)
			{
				Polygon polygon = mesh.Polygons[i];
				if (polygon is Triangle triangle)
				{
					XYZ v0 = mesh.Vertices[(int)triangle.Index0];
					XYZ v1 = mesh.Vertices[(int)triangle.Index1];
					XYZ v2 = mesh.Vertices[(int)triangle.Index2];
					if (hasNormal)
					{
						result.Add(new StlTriangle((Vector3)v0, (Vector3)v1, (Vector3)v2, (Vector3)normalElement.Normals[i]));
					}
					else
					{
						result.Add(new StlTriangle((Vector3)v0, (Vector3)v1, (Vector3)v2));
					}
				}
				else
				{
					Triangle[] subTriangles = polygon.ConvertToTriangles();
					foreach (Triangle subTriangle in subTriangles)
					{
						XYZ v0 = mesh.Vertices[(int)subTriangle.Index0];
						XYZ v1 = mesh.Vertices[(int)subTriangle.Index1];
						XYZ v2 = mesh.Vertices[(int)subTriangle.Index2];
						result.Add(new StlTriangle((Vector3)v0, (Vector3)v1, (Vector3)v2));
					}
				}
			}
			return result;
		}

		private static bool HasCompatibleNormalValues(LayerElementNormal normalElement)
		{
			return normalElement != null && normalElement.MappingInformationType == MappingMode.ByPolygon && normalElement.ReferenceInformationType == ReferenceMode.Direct;
		}
	}
}
