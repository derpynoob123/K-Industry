using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNetworkManager : MonoBehaviour
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
            float pathLength = 1;
            graph.AddConnection(path.NodeA, path.NodeB, pathLength);
            graph.AddConnection(path.NodeB, path.NodeA, pathLength);
        }
    }
}
