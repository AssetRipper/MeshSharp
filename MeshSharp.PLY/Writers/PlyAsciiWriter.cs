using System.IO;
using System.Text;

namespace MeshSharp.PLY.Writers
{
	internal class PlyAsciiWriter : PlyWriterBase
	{
		public PlyAsciiWriter(Stream stream) : base(stream)
		{
		}

		public PlyAsciiWriter(string path) : base(path)
		{
		}

		protected override PlyFileFormat Format => PlyFileFormat.Ascii;

		protected override void WriteMeshData(PlyMesh mesh)
		{
			using StreamWriter writer = new StreamWriter(stream, Encoding.ASCII);
			writer.WriteLine(mesh.ToAsciiString());
		}
	}
}
