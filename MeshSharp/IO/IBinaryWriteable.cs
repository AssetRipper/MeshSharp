using System.IO;

namespace AssetRipper.MeshSharp.IO
{
	internal interface IBinaryWriteable
	{
		void Write(BinaryWriter writer);
	}
}
