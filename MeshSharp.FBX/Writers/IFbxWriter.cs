namespace AssetRipper.MeshSharp.FBX
{
	public interface IFbxWriter
	{
		FbxRootNode GetRootNode();
		void WriteBinary();
		void WriteAscii();
	}
}
