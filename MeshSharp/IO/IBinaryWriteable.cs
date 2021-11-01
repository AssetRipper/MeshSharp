using System.IO;

namespace MeshSharp.IO
{
    internal interface IBinaryWriteable
    {
        void Write(BinaryWriter writer);
    }
}
