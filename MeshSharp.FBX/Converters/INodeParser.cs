using AssetRipper.MeshSharp.Elements;

namespace AssetRipper.MeshSharp.FBX.Converters
{
	public interface INodeParser
	{
		FbxVersion Version { get; }

		Scene ConvertScene();
	}
}
