using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wayPoints;
    [SerializeField]
    private Path[] paths;

    private PathfindingGraph graph = new();
    private AStarPathFinder pathFinder = new();

    private void Awake()
    {
        InitialiseGraph();
    }

    private void InitialiseGraph()
    {
        for (int waypointIndex = 0; waypointIndex < wayPoints.Length; waypointIndex++)
        {
            GameObject waypoint = wayPoints[waypointIndex];
            graph.AddNode(waypoint);
        }
        for (int pathIndex = 0; pathIndex < paths.Length; pathIndex++)
        {
            Path path = paths[pathIndex];
            graph.AddConnection(path.NodeA, path.NodeB);
            graph.AddConnection(path.NodeB, path.NodeA);
        }
    }
}
