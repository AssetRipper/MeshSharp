namespace AssetRipper.MeshSharp
{
	public class Quad : Polygon
	{
		public uint Index0
		{
			get => Indices[0];
			set => Indices[0] = value;
		}
		public uint Index1
		{
			get => Indices[1];
			set => Indices[1] = value;
		}
		public uint Index2
		{
			get => Indices[2];
			set => Indices[2] = value;
		}
		public uint Index3
		{
			get => Indices[3];
			set => Indices[3] = value;
		}

		public Quad(uint i0, uint i1, uint i2, uint i3) : base(new uint[] { i0, i1, i2, i3 }) { }
	}
}
