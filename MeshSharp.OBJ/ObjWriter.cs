using AssetRipper.MeshSharp.Elements;
using System.IO;

namespace AssetRipper.MeshSharp.OBJ
{
	public static class ObjWriter
	{
		public static void Write(string path, Scene scene) => new ObjAsciiWriter(path).Write(scene);
		public static void Write(Stream stream, Scene scene) => new ObjAsciiWriter(stream).Write(scene);
	}
}
