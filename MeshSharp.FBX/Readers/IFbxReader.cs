using MeshSharp.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshSharp.FBX
{
	public interface IFbxReader : IDisposable
	{
		FbxRootNode Parse();
		Scene Read();
	}
}
