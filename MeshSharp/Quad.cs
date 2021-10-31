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
	}
}
