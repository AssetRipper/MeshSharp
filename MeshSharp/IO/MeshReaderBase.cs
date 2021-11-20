using System;
using System.IO;

namespace MeshSharp.IO
{
	internal abstract class MeshReaderBase : IDisposable
	{
		private bool disposedValue;
		protected Stream stream;

		public MeshReaderBase(Stream stream)
		{
			this.stream = stream;
		}
		public MeshReaderBase(string path) : this(File.OpenRead(path)) { }

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
