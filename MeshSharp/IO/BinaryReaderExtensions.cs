using System.IO;

namespace AssetRipper.MeshSharp.IO
{
	internal static class BinaryReaderExtensions
	{
		public static T ReadStruct<T>(this BinaryReader reader) where T : IBinaryReadable, new()
		{
			T result = new();
			result.Read(reader);
			return result;
		}
	}
}
