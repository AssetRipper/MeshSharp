using MeshSharp.Elements;
using MeshSharp.FBX.Converters;
using System;
using System.IO;

namespace MeshSharp.FBX
{
	public class FbxWriter : IFbxWriter, IDisposable
	{
		private Stream writeStream;
		private bool disposedValue;

		FbxVersion Version { get; set; }
		public Scene Scene { get; set; }

		#region Constructors
		public FbxWriter(string path, Scene scene, FbxVersion version = FbxVersion.v7400)
		{
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException(nameof(path));

			writeStream = File.Create(path);
			Scene = scene;
			Version = version;
		}

		public FbxWriter(Stream stream, Scene scene, FbxVersion version = FbxVersion.v7400)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			writeStream = stream;
			Scene = scene;
			Version = version;
		}
		#endregion

		#region Instance Methods
		public FbxRootNode GetRootNode()
		{
			IFbxConverter converter = FbxConverterBase.GetConverter(Scene, Version);
			return converter.ToRootNode();
		}

		public FbxRootNode GetRootNode(FbxVersion version)
		{
			IFbxConverter converter = FbxConverterBase.GetConverter(Scene, version);
			return converter.ToRootNode();
		}

		public void WriteAscii()
		{
			using (FbxAsciiWriter writer = new FbxAsciiWriter(writeStream))
				writer.Write(GetRootNode());
		}

		public void WriteBinary()
		{
			using (FbxBinaryWriter writer = new FbxBinaryWriter(writeStream))
				writer.Write(GetRootNode());
		}
		#endregion

		#region Static Methods
		public static void WriteAscii(string path, Scene scene, FbxVersion version = FbxVersion.v7400)
		{
			new FbxWriter(path, scene, version).WriteAscii();
		}
		public static void WriteAscii(Stream stream, Scene scene, FbxVersion version = FbxVersion.v7400)
		{
			new FbxWriter(stream, scene, version).WriteAscii();
		}

		public static void WriteAscii(string path, FbxRootNode root)
		{
			if (path == null)
				throw new ArgumentNullException(nameof(path));

			using (FileStream stream = new FileStream(path, FileMode.Create))
				WriteAscii(stream, root);
		}
		public static void WriteAscii(Stream stream, FbxRootNode root)
		{
			using (FbxAsciiWriter writer = new FbxAsciiWriter(stream))
				writer.Write(root);
		}

		public static void WriteBinary(string path, Scene scene, FbxVersion version = FbxVersion.v7400)
		{
			new FbxWriter(path, scene, version).WriteBinary();
		}
		public static void WriteBinary(Stream stream, Scene scene, FbxVersion version = FbxVersion.v7400)
		{
			new FbxWriter(stream, scene, version).WriteBinary();
		}

		public static void WriteBinary(string path, FbxRootNode root)
		{
			if (path == null)
				throw new ArgumentNullException(nameof(path));

			using (FileStream stream = new FileStream(path, FileMode.Create))
				WriteBinary(stream, root);
		}
		public static void WriteBinary(Stream stream, FbxRootNode root)
		{
			using (FbxBinaryWriter writer = new FbxBinaryWriter(stream))
				writer.Write(root);
		}
		#endregion

		#region Disposal
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					writeStream.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				writeStream = null;
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~FbxWriter()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
