using MeshSharp.Elements;
using MeshSharp.Elements.Geometries;
using System;
using System.Collections.Generic;
using System.IO;

namespace MeshSharp.OBJ
{
	public class ObjWriter : IDisposable
	{
		private bool disposedValue;
		protected Stream stream;

		public ObjWriter(Stream stream)
		{
			this.stream = stream;
		}
		public ObjWriter(string path) : this(File.Create(path)) { }

		public void Write(Scene scene)
		{
			List<Mesh> meshes = MeshUtils.GetAllMeshes(scene);
			ObjMesh processedMesh = ObjMesh.ConvertFromMeshes(meshes);
			using (StreamWriter writer = new StreamWriter(stream))
			{
				writer.WriteLine(processedMesh.ToAsciiString());
			}
		}

		public static void Write(string path, Scene scene) => new ObjWriter(path).Write(scene);
		public static void Write(Stream stream, Scene scene) => new ObjWriter(stream).Write(scene);

		#region Disposal
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					stream?.Dispose();
				}

				stream = null;
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
