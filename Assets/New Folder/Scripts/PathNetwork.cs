using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNetwork : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;
    [SerializeField]
    private Path[] paths;

    private readonly PathfindingGraph graph = new();

    private void Awake()
    {
        InitialiseGraph();
    }

    private void InitialiseGraph()
    {
        for (int waypointIndex = 0; waypointIndex < waypoints.Length; waypointIndex++)
        {
            GameObject waypoint = waypoints[waypointIndex];
            graph.AddNode(waypoint);
        }
        for (int pathIndex = 0; pathIndex < paths.Length; pathIndex++)
        {
            Path path = paths[pathIndex];
            graph.AddConnection(path);
        }
    }

    public Node GetNode(GameObject junction)
    {
        return graph.FindNode(junction);
    }

    public GameObject GetJunction(Node node)
    {
        return graph.FindJunction(node);
    }

    public Path GetPath(Connection connection)
    {
        return graph.FindPath(connection);
    }
}
