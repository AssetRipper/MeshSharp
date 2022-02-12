using System.Collections.Generic;

namespace AssetRipper.MeshSharp.Elements
{
	public class Scene : Element
	{
		public List<Node> Nodes { get; } = new List<Node>();

		public Scene() : base() { }
		public Scene(string name) : base(name) { }
	}
}
