using MeshSharp.Elements;
using MeshSharp.PLY.Writers;
using System.IO;

namespace MeshSharp.PLY
{
	public static class PlyWriter
	{
		public static void WriteAscii(string path, Scene scene)
		{
			new PlyAsciiWriter(path).Write(scene);
		}
		public static void WriteAscii(Stream stream, Scene scene)
		{
			new PlyAsciiWriter(stream).Write(scene);
		}
	}
}
