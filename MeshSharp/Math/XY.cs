namespace MeshSharp
{
	public struct XY : IVector<XY>
	{
		public static readonly XY Zero = new XY(0, 0);
		public static readonly XY AxisX = new XY(1, 0);
		public static readonly XY AxisY = new XY(0, 1);

		public double X { get; set; }
		public double Y { get; set; }

		public XY(double x, double y)
		{
			X = x;
			Y = y;
		}

		public XY(double[] components) : this(components[0], components[1]) { }

		public double[] GetComponents()
		{
			return new double[] { X, Y };
		}

		public XY SetComponents(double[] components)
		{
			return new XY(components);
		}

		public override string ToString()
		{
			return $"{X},{Y}";
		}

		#region Conversion Operators
		public static implicit operator XY(System.Numerics.Vector2 vector) => new XY(vector.X, vector.Y);
		public static explicit operator System.Numerics.Vector2(XY vector)
		{
			return new System.Numerics.Vector2((float)vector.X, (float)vector.Y);
		}
		#endregion
	}
}
