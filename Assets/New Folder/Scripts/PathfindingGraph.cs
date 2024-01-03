using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingGraph
{
    private Dictionary<GameObject, Node> nodes = new();
    private List<Connection> connections = new();

    public void AddNode(GameObject id)
    {
        Node node = new(id);
        nodes.Add(id, node);
    }

    public void AddConnection(GameObject start, GameObject end, float cost)
    {
        Node startNode = FindNode(start);
        Node endNode = FindNode(end);
        Connection connection = new(startNode, endNode, cost);
        startNode.Connections.Add(connection);
        endNode.Connections.Add(connection);
        connections.Add(connection);
    }

    public Node FindNode(GameObject id)
    {
        return nodes[id];
    }
}
