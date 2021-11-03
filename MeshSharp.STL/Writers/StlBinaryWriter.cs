using MeshSharp.Elements;
using MeshSharp.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace MeshSharp.STL.Writers
{
	internal class StlBinaryWriter : StlWriterBase
	{
		public StlBinaryWriter(string path) : base(path)
		{
		}

		public StlBinaryWriter(Stream stream) : base(stream)
		{
		}

		public override void Write(Scene scene)
		{
			if (scene == null)
				throw new ArgumentNullException(nameof(scene));
			List<StlTriangle> triangles = ConvertToStlTriangles(scene);
			using BinaryWriter writer = new BinaryWriter(stream);
			writer.Write(new byte[80]);
			writer.Write((uint)triangles.Count);
			foreach (StlTriangle triangle in triangles)
			{
				writer.WriteStruct(triangle);
			}
		}
	}
}
