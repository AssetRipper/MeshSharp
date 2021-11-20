using System;

namespace MeshSharp.PLY
{
	internal enum PlyFileFormat
	{
		Ascii,
		BinaryLittleEndian,
		BinaryBigEndian,
	}

	internal static class PlyFileFormatExtensions
	{
		public static string ToFileString(this PlyFileFormat format) => format switch
		{
			PlyFileFormat.Ascii => "ascii",
			PlyFileFormat.BinaryLittleEndian => "binary_little_endian",
			PlyFileFormat.BinaryBigEndian => "binary_big_endian",
			_ => throw new ArgumentOutOfRangeException(nameof(format)),
		};
	}
}
