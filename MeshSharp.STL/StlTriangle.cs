using MeshSharp.IO;
using System.IO;
using System.Numerics;
using System.Text;

namespace MeshSharp.STL
{
	internal class StlTriangle : IBinaryReadable, IBinaryWriteable
	{
		public StlTriangle()
		{
		}

		public StlTriangle(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
		{
			Vertex1 = vertex1;
			Vertex2 = vertex2;
			Vertex3 = vertex3;
			RecalculateNormal();
		}

		public StlTriangle(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3, Vector3 normal)
		{
			Normal = normal;
			Vertex1 = vertex1;
			Vertex2 = vertex2;
			Vertex3 = vertex3;
		}

		public Vector3 Normal { get; private set; }
		public Vector3 Vertex1 { get; private set; }
		public Vector3 Vertex2 { get; private set; }
		public Vector3 Vertex3 { get; private set; }

		public void RecalculateNormal()
		{
			Normal = (Vector3)XYZ.FindNormal(Vertex1, Vertex2, Vertex3);
		}

		public void Read(BinaryReader reader)
		{
			Normal = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
			Vertex1 = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
			Vertex2 = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
			Vertex3 = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
			reader.ReadUInt16(); //attribute byte count
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(Normal.X);
			writer.Write(Normal.Y);
			writer.Write(Normal.Z);
			writer.Write(Vertex1.X);
			writer.Write(Vertex1.Y);
			writer.Write(Vertex1.Z);
			writer.Write(Vertex2.X);
			writer.Write(Vertex2.Y);
			writer.Write(Vertex2.Z);
			writer.Write(Vertex3.X);
			writer.Write(Vertex3.Y);
			writer.Write(Vertex3.Z);
			writer.Write((ushort)0); //attribute byte count is always zero
		}

		public string ToAsciiString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"facet normal {ToStringInvariant(Normal.X)} {ToStringInvariant(Normal.Y)} {ToStringInvariant(Normal.Z)}");
			sb.AppendLine("\touter loop");
			sb.AppendLine($"\t\tvertex {ToStringInvariant(Vertex1.X)} {ToStringInvariant(Vertex1.Y)} {ToStringInvariant(Vertex1.Z)}");
			sb.AppendLine($"\t\tvertex {ToStringInvariant(Vertex2.X)} {ToStringInvariant(Vertex2.Y)} {ToStringInvariant(Vertex2.Z)}");
			sb.AppendLine($"\t\tvertex {ToStringInvariant(Vertex3.X)} {ToStringInvariant(Vertex3.Y)} {ToStringInvariant(Vertex3.Z)}");
			sb.AppendLine("\tendloop");
			sb.AppendLine("endfacet");
			return sb.ToString();
		}

		private static string ToStringInvariant(float value) => value.ToString("e", System.Globalization.CultureInfo.InvariantCulture);
	}
}
