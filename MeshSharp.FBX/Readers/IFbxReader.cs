using AssetRipper.MeshSharp.Elements;
using System;

namespace AssetRipper.MeshSharp.FBX
{
	public interface IFbxReader : IDisposable
	{
		FbxRootNode Parse();
		Scene Read();
	}
}
