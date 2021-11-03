namespace MeshSharp
{
    public class Triangle : Polygon
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

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Triangle() : this(0, 0, 0) { }

		/// <summary>
		/// Setup a triangle with the 3 indexes.
		/// </summary>
		/// <param name="i0"></param>
		/// <param name="i1"></param>
		/// <param name="i2"></param>
		public Triangle(uint i0, uint i1, uint i2) : base(new uint[] { i0, i1, i2 }) { }
    }
}
