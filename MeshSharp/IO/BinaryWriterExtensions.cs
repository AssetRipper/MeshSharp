using System.IO;

namespace AssetRipper.MeshSharp.IO
{
	internal static class BinaryWriterExtensions
	{
		public static void WriteStruct<T>(this BinaryWriter writer, T value) where T : IBinaryWriteable
		{
			value.Write(writer);
		}
	}
}
