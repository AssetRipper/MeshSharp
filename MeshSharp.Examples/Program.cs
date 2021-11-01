using MeshSharp.Elements;
using MeshSharp.FBX;
using MeshSharp.STL;
using System;

namespace MeshSharp.Examples
{
    class Program
	{
		static void Main(string[] args)
		{
            try
            {
				//StlConversion();
				StlExample();
			}
			catch(Exception ex)
            {
				Console.WriteLine(ex.ToString());
            }

			Console.WriteLine("Program finished");
			Console.ReadLine();
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

		static void StlConversion()
        {
			string pathI = @".\..\..\..\..\file_samples\stl\dev_binoculars_hudShape_1_ascii.stl";
			string pathO = @".\..\..\..\..\file_samples\stl\dev_binoculars_hudShape_1_out.fbx";
			Scene scene = StlReader.ReadAscii(pathI);
			FbxWriter.WriteAscii(pathO, scene);
			//for some reason, the mesh gets rotated 90 degrees on the x - axis during this conversion
		}

		static void StlExample()
		{
			string pathI = @".\..\..\..\..\file_samples\stl\dev_binoculars_hudShape_1_binary.stl";
			string pathO = @".\..\..\..\..\file_samples\stl\dev_binoculars_hudShape_1_ascii.stl";
			Scene scene = StlReader.ReadBinary(pathI);
			StlWriter.WriteAscii(pathO, scene);
			//this does not result in rotation
		}
	}
}
