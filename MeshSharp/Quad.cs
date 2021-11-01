namespace MeshSharp
{
    public class Quad : Polygon
	{
		public uint Index0 { get; set; }
		public uint Index1 { get; set; }
		public uint Index2 { get; set; }
		public uint Index3 { get; set; }

		public Quad(uint i0, uint i1, uint i2, uint i3)
		{
			this.Index0 = i0;
			this.Index1 = i1;
			this.Index2 = i2;
			this.Index3 = i3;
		}

		public override int[] ToArray()
		{
			return new int[] { (int)Index0, (int)Index1, (int)Index2, (int)Index3 };
		}

		public override Triangle[] ConvertToTriangles()
        {
			Triangle[] triangles = new Triangle[2];
			triangles[0] = new Triangle(Index0, Index1, Index2);
			triangles[1] = new Triangle(Index0, Index2, Index3);
			return triangles;
        }
	}
}
