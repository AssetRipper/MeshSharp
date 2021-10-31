using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries.Layers
{
    public class LayerElementMaterial : LayerElement
	{
		public List<int> Materials { get; set; } = new List<int>();
		public LayerElementMaterial(Geometry owner) : base(owner)
		{
			MappingInformationType = MappingMode.AllSame;
			ReferenceInformationType = ReferenceMode.IndexToDirect;
			Materials.Add(0);
		}
	}
}
