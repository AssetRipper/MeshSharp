using MeshSharp.Elements;
using MeshSharp.Elements.Geometries;
using MeshSharp.Elements.Geometries.Layers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace MeshSharp.STL.Writers
{
    internal abstract class StlWriterBase : IDisposable
    {
        private bool disposedValue;
        protected Stream stream;

        public StlWriterBase(Stream stream)
        {
            this.stream = stream;
        }
        public StlWriterBase(string path) : this(File.Create(path)) { }

        public abstract void Write(Scene scene);

        private static List<Mesh> GetMeshes(Scene scene)
        {
            List<Mesh> result = new List<Mesh>();
            foreach (Node node in scene.Nodes)
            {
                result.AddRange(GetMeshes(node));
            }
            return result;
        }

        private static List<Mesh> GetMeshes(Node node)
        {
            List<Mesh> result = new List<Mesh>();
            foreach (Element child in node.Children)
            {
                if (child is Mesh mesh)
                    result.Add(mesh);
                else if (child is Node childNode)
                    result.AddRange(GetMeshes(childNode));
            }
            return result;
        }

        protected static List<StlTriangle> ConvertToStlTriangles(Scene scene)
        {
            List<Mesh> meshes = GetMeshes(scene);
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
