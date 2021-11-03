using System;

namespace MeshSharp
{
	public class Polygon
	{
		public uint[] Indices { get; }

		public Polygon(uint[] indices)
		{
			if (indices == null)
				throw new ArgumentNullException(nameof(indices));
			if (indices.Length < 3)
				throw new ArgumentException("Polygons must have at least 3 sides", nameof(indices));
			this.Indices = indices;
		}

		public Triangle[] ConvertToTriangles()
		{
			Triangle[] result = new Triangle[Indices.Length - 2];
			uint index0 = Indices[0];
			for (int i = 0; i + 2 < Indices.Length; i++)
			{
				result[i] = new Triangle(index0, Indices[i + 1], Indices[i + 2]);
			}
			return result;
		}
	}
}
