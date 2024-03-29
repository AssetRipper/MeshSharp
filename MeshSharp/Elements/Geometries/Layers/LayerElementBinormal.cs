﻿using System.Collections.Generic;

namespace AssetRipper.MeshSharp.Elements.Geometries.Layers
{
	public class LayerElementBinormal : LayerElement
	{
		public List<XYZ> BiNormals { get; internal set; } = new List<XYZ>();
		public LayerElementBinormal(Geometry owner) : base(owner) { }
	}
}
