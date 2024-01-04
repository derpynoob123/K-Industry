using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGraph
{
    private readonly Dictionary<GameObject, Node> nodes = new();

    public void AddNode(GameObject junction)
    {
        Node node = new();
        nodes.Add(id, node);
    }

    public void AddConnection(Path path)
    {
        Node startNode = FindNode(path.StartNode);
        Node endNode = FindNode(path.EndNode);
        float cost = path.GetDistance();
        Connection connection = new(startNode, endNode, cost);
        startNode.Connections.Add(connection);
        endNode.Connections.Add(connection);
    }

    public Node FindNode(GameObject id)
    {
        return nodes[id];
    } 
}
