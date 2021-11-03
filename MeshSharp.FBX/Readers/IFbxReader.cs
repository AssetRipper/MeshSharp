using MeshSharp.Elements;
using System;

namespace MeshSharp.FBX
{
	public interface IFbxReader : IDisposable
	{
		FbxRootNode Parse();
		Scene Read();
	}
}
