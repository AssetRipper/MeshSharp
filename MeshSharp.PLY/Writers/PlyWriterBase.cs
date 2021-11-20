using MeshSharp.Elements;
using MeshSharp.Elements.Geometries;
using MeshSharp.IO;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeshSharp.PLY.Writers
{
	internal abstract class PlyWriterBase : MeshWriterBase
	{
		public PlyWriterBase(Stream stream) : base(stream) { }
		public PlyWriterBase(string path) : base(path) { }
		protected abstract PlyFileFormat Format { get; }

		public void Write(Scene scene)
		{
			List<Mesh> meshes = MeshUtils.GetAllMeshes(scene);
			PlyMesh processedMesh = PlyMesh.ConvertFromMeshes(meshes);
			PlyHeader header = new PlyHeader();
			header.Format = Format;
			header.VertexCount = processedMesh.VertexCount;
			header.FaceCount = processedMesh.PolygonCount;
			using (StreamWriter writer = new StreamWriter(stream, Encoding.ASCII, leaveOpen: true))
			{
				writer.Write(header.ToAsciiString());
			}
			WriteMeshData(processedMesh);
		}

		protected abstract void WriteMeshData(PlyMesh mesh);
	}
}
