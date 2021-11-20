using MeshSharp.Elements;
using MeshSharp.Elements.Geometries;
using MeshSharp.IO;
using System.Collections.Generic;
using System.IO;

namespace MeshSharp.OBJ
{
	internal class ObjAsciiWriter : MeshWriterBase
	{
		public ObjAsciiWriter(Stream stream) : base(stream) { }
		public ObjAsciiWriter(string path) : base(path) { }

		public void Write(Scene scene)
		{
			List<Mesh> meshes = MeshUtils.GetAllMeshes(scene);
			ObjMesh processedMesh = ObjMesh.ConvertFromMeshes(meshes);
			using (StreamWriter writer = new StreamWriter(stream))
			{
				writer.WriteLine(processedMesh.ToAsciiString());
			}
		}
	}
}
