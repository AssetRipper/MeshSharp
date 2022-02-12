using AssetRipper.MeshSharp.Elements;
using AssetRipper.MeshSharp.PLY.Writers;
using System.IO;

namespace AssetRipper.MeshSharp.PLY
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
