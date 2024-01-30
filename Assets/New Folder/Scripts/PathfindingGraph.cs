using System.Collections.Generic;
using UnityEngine;

public class PathfindingGraph
{
    private readonly Dictionary<GameObject, Node> nodes = new();
    private readonly Dictionary<Node, GameObject> junctions = new();
    private readonly Dictionary<Path, Connection> connections = new();
    private readonly Dictionary<Connection, Path> paths = new();

    public void AddNode(GameObject junction)
    {
        Node node = new(junction.transform.position);

        nodes.Add(junction, node);
        junctions.Add(node, junction);
    }

    public void AddConnection(Path path)
    {
        Node startNode = FindNode(path.StartNode);
        Node endNode = FindNode(path.EndNode);
        float cost = path.GetDistanceInUnits();
        Connection connection = new(startNode, endNode, cost);

        startNode.Connections.Add(connection);
        endNode.Connections.Add(connection);

        connections.Add(path, connection);
        paths.Add(connection, path);
    }

    public Node FindNode(GameObject junction)
    {
        return nodes[junction];
    } 

    public GameObject FindJunction(Node node)
    {
        return junctions[node];
    }

    public Connection FindConnection(Path path)
    {
        return connections[path];
    }

    public Path FindPath(Connection connection)
    {
        return paths[connection];
    }
}
