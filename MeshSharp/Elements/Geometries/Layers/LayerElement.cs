namespace AssetRipper.MeshSharp.Elements.Geometries.Layers
{
	public abstract class LayerElement
	{
		public string Name { get; set; } = string.Empty;
		public MappingMode MappingInformationType { get; set; }
		public ReferenceMode ReferenceInformationType { get; set; }

		protected Geometry _owner;

		public LayerElement(Geometry owner)
		{
			_owner = owner;
		}
	}
}
