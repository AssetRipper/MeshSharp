using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace AssetRipper.MeshSharp.STL.Readers
{
	internal class StlAsciiReader : StlReaderBase
	{
		public StlAsciiReader(Stream stream) : base(stream) { }
		public StlAsciiReader(string path) : base(path) { }

		protected override StlTriangle[] ReadFile()
		{
			using StreamReader reader = new(stream);
			string magic = ReadMagic(reader);
			if (magic != "solid ")
				throw new Exception($"Invalid magic: '{magic}");
			string name = reader.ReadLine();

			var result = new List<StlTriangle>();
			while (true)
			{
				StlTriangle triangle = ReadTriangle(reader);
				if (triangle == null)
					break;
				result.Add(triangle);
			}
			return result.ToArray();
		}

		private static string ReadMagic(StreamReader reader)
		{
			char[] buffer = new char[6];
			reader.Read(buffer, 0, buffer.Length);
			return new string(buffer);
		}

		private static StlTriangle ReadTriangle(StreamReader reader)
		{
			string normalLine = GetTrimmedNonEmptyLine(reader);
			if (normalLine == null)
				throw new Exception("Stream ended whilst reading an STL triangle.");
			if (normalLine.StartsWith("endsolid"))
				return null;//This line ends the file

			Vector3 normal = ParseNormal(normalLine);

			string outerLoopLine = GetTrimmedNonEmptyLine(reader) ?? throw new Exception("Stream ended whilst reading an STL triangle.");
			AssertSyntax(outerLoopLine, "outer loop");

			string vertex1Line = GetTrimmedNonEmptyLine(reader) ?? throw new Exception("Stream ended whilst reading an STL triangle.");
			Vector3 vertex1 = ParseVertex(vertex1Line);

			string vertex2Line = GetTrimmedNonEmptyLine(reader) ?? throw new Exception("Stream ended whilst reading an STL triangle.");
			Vector3 vertex2 = ParseVertex(vertex2Line);

			string vertex3Line = GetTrimmedNonEmptyLine(reader) ?? throw new Exception("Stream ended whilst reading an STL triangle.");
			Vector3 vertex3 = ParseVertex(vertex3Line);

			string endLoopLine = GetTrimmedNonEmptyLine(reader) ?? throw new Exception("Stream ended whilst reading an STL triangle.");
			AssertSyntax(endLoopLine, "endloop");

			string endFacetLine = GetTrimmedNonEmptyLine(reader) ?? throw new Exception("Stream ended whilst reading an STL triangle.");
			AssertSyntax(endFacetLine, "endfacet");

			return new StlTriangle(vertex1, vertex2, vertex3, normal);
		}

		private static string GetTrimmedNonEmptyLine(StreamReader reader)
		{
			string result;
			while (true)
			{
				result = reader.ReadLine()?.Trim();
				if (result == null)
					return null;
				if (result.Length != 0)
					return result;
			}
		}

		private static void AssertSyntax(string line, string expectedContents)
		{
			if (line != expectedContents)
				throw new Exception($"Assertion failed: read '{line}' expected '{expectedContents};");
		}

		private static float ParseFloat(string text) => float.Parse(text, System.Globalization.CultureInfo.InvariantCulture);

		private static Vector3 ParseNormal(string line)
		{
			string[] entries = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (entries[0] != "facet")
				throw new Exception($"Invalid facet keyword: '{entries[0]}'");
			if (entries[1] != "normal")
				throw new Exception($"Invalid normal keyword: '{entries[1]}'");
			float nx = ParseFloat(entries[2]);
			float ny = ParseFloat(entries[3]);
			float nz = ParseFloat(entries[4]);
			return new Vector3(nx, ny, nz);
		}

		private static Vector3 ParseVertex(string line)
		{
			string[] entries = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (entries[0] != "vertex")
				throw new Exception($"Invalid vertex keyword: '{entries[0]}'");
			float vx = ParseFloat(entries[1]);
			float vy = ParseFloat(entries[2]);
			float vz = ParseFloat(entries[3]);
			return new Vector3(vx, vy, vz);
		}
	}
}
