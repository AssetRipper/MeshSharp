using MeshSharp.Elements;
using MeshSharp.STL.Writers;
using System.IO;

namespace MeshSharp.STL
{
    public static class StlWriter
    {
        public static void WriteAscii(string path, Scene scene)
        {
            new StlAsciiWriter(path).Write(scene);
        }
        public static void WriteAscii(Stream stream, Scene scene)
        {
            new StlAsciiWriter(stream).Write(scene);
        }
        public static void WriteBinary(string path, Scene scene)
        {
            new StlBinaryWriter(path).Write(scene);
        }
        public static void WriteBinary(Stream stream, Scene scene)
        {
            new StlBinaryWriter(stream).Write(scene);
        }
    }
}
