using MeshSharp.Elements;

namespace MeshSharp.FBX.Converters
{
    public interface INodeParser
	{
		FbxVersion Version { get; }

		Scene ConvertScene();
	}
}
