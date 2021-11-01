namespace MeshSharp
{
    public abstract class Polygon
	{
		public abstract int[] ToArray();
		public abstract Triangle[] ConvertToTriangles();
	}
}
