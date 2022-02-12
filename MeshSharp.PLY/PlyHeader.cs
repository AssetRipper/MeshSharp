using System.Text;

namespace AssetRipper.MeshSharp.PLY
{
	internal class PlyHeader
	{
		private const string PlyMagic = "ply";
		private const string EndHeaderString = "end_header";

		public PlyFileFormat Format { get; set; }
		public int VertexCount { get; set; }
		public int FaceCount { get; set; }

		public string ToAsciiString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(PlyMagic);
			sb.AppendLine($"format {Format.ToFileString()} 1.0");
			sb.AppendLine($"element vertex {VertexCount}");
			sb.AppendLine("property float x");
			sb.AppendLine("property float y");
			sb.AppendLine("property float z");
			sb.AppendLine($"element face {FaceCount}");
			sb.AppendLine("property list uchar int vertex_index");
			sb.AppendLine(EndHeaderString);
			return sb.ToString();
		}
	}
}
