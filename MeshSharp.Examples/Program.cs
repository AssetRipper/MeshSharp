using MeshIO.Elements;
using MeshIO.FBX;
using System;
using System.IO;

namespace MeshIO.Examples
{
	class Program
	{
		static void Main(string[] args)
		{
			FbxExample();

			Console.WriteLine("Program finished");
		}

		static void FbxExample()
		{
			//string pathI = @".\..\..\..\..\file_samples\fbx\objects_ascii_2014-2015.fbx";
			string pathI = @".\..\..\..\..\file_samples\fbx\test_project_arq_acsii.fbx";
			//string pathO = @".\..\..\..\..\file_samples\fbx\objects_ascii_2014-2015_out.fbx";
			string pathO = @".\..\..\..\..\file_samples\fbx\test_project_arq_acsii_out.fbx";

			Scene scene = FbxReader.Read(pathI, ErrorLevel.Checked);
			FbxWriter.WriteAscii(pathO, scene);
		}
	}
}
