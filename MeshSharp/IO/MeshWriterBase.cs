using System;
using System.IO;

namespace AssetRipper.MeshSharp.IO
{
	internal abstract class MeshWriterBase : IDisposable
	{
		private bool disposedValue;
		protected Stream stream;

		public MeshWriterBase(Stream stream)
		{
			this.stream = stream;
		}
		public MeshWriterBase(string path) : this(File.Create(path)) { }

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
