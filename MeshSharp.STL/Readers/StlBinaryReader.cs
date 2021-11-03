using MeshSharp.IO;
using System;
using System.IO;

namespace MeshSharp.STL.Readers
{
	internal class StlBinaryReader : StlReaderBase
	{
		public StlBinaryReader(Stream stream) : base(stream) { }
		public StlBinaryReader(string path) : base(path) { }

		protected override StlTriangle[] ReadFile()
		{
			using BinaryReader reader = new(stream);
			reader.ReadBytes(80);
			uint count = reader.ReadUInt32();
			var result = new StlTriangle[count];
			for (uint i = 0; i < count; i++)
			{
				result[i] = reader.ReadStruct<StlTriangle>();
			}
			if (stream.Position != stream.Length)
				throw new Exception($"Read {stream.Position} but expected {stream.Length} while read STL binary file.");
			return result;
		}
	}
}
