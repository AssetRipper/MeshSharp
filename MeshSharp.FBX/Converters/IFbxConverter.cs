namespace MeshSharp.FBX.Converters
{
    public interface IFbxConverter
	{
		FbxVersion Version { get; }

		FbxRootNode ToRootNode();
	}
}
