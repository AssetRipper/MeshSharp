using System.IO;

namespace AssetRipper.MeshSharp.IO
{
	internal interface IBinaryReadable
	{
		void Read(BinaryReader reader);
	}
}
