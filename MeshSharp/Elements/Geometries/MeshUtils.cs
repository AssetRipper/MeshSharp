using System.Collections.Generic;

namespace MeshSharp.Elements.Geometries
{
    internal static class MeshUtils
    {
        internal static List<Mesh> GetAllMeshes(Scene scene)
        {
            List<Mesh> result = new List<Mesh>();
            foreach (Node node in scene.Nodes)
            {
                result.AddRange(GetAllMeshes(node, true));
            }
            return result;
        }

        internal static List<Mesh> GetAllMeshes(Node parentNode, bool recursively)
        {
            List<Mesh> result = new List<Mesh>();
            foreach (Element child in parentNode.Children)
            {
                if (child is Mesh mesh)
                    result.Add(mesh);
                else if (recursively && child is Node childNode)
                    result.AddRange(GetAllMeshes(childNode, true));
            }
            return result;
        }
    }
}
