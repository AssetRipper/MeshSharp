using AssetRipper.MeshSharp.Elements;
using AssetRipper.MeshSharp.Elements.Geometries;
using AssetRipper.MeshSharp.IO;
using System.Collections.Generic;
using System.IO;

namespace AssetRipper.MeshSharp.OBJ
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
