using MeshSharp.Elements;
using System;
using System.Collections.Generic;
using System.IO;

namespace MeshSharp.STL.Writers
{
    internal class StlAsciiWriter : StlWriterBase
    {
        public StlAsciiWriter(string path) : base(path)
        {
        }

        public StlAsciiWriter(Stream stream) : base(stream)
        {
        }

        public override void Write(Scene scene)
        {
            if (scene == null)
                throw new ArgumentNullException(nameof(scene));
            List<StlTriangle> triangles = ConvertToStlTriangles(scene);
            using StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine($"solid {scene.Name ?? ""}");
            foreach (StlTriangle triangle in triangles)
            {
                writer.WriteLine(triangle.ToAsciiString());
            }
            writer.WriteLine($"endsolid {scene.Name ?? ""}");
        }
    }
}