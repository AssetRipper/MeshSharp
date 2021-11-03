using System.IO;

namespace MeshSharp.IO
{
	internal interface IBinaryReadable
	{
		void Read(BinaryReader reader);
	}
}
