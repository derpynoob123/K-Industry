using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNetwork : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;
    [SerializeField]
    private Path[] paths;

    private PathfindingGraph graph = new();

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

    public Node GetNode(GameObject id)
    {
        return graph.FindNode(id);
    }
}
