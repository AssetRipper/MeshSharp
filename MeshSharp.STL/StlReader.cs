using MeshSharp.Elements;
using MeshSharp.STL.Readers;
using System.IO;

namespace MeshSharp.STL
{
	public static class StlReader
	{
		public static Scene ReadAscii(string path)
		{
			return new StlAsciiReader(path).Read();
		}
		public static Scene ReadAscii(Stream stream)
		{
			return new StlAsciiReader(stream).Read();
		}
		public static Scene ReadBinary(string path)
		{
			return new StlBinaryReader(path).Read();
		}
		public static Scene ReadBinary(Stream stream)
		{
			return new StlBinaryReader(stream).Read();
		}
	}
}
