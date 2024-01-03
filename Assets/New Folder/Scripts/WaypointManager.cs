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
        GameObject start = wayPoints[0];
        Node startNode = graph.FindNode(start);
        GameObject end = wayPoints[1];
        Node endNode = graph.FindNode(end);
        Connection[] path = pathFinder.FindPath(startNode, endNode).ToArray();
        foreach (var item in path)
        {
            print(item.EndNode.Position);
        }
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
            float pathLength = path.GetPathLength();
            graph.AddConnection(path.NodeA, path.NodeB, pathLength);
            graph.AddConnection(path.NodeB, path.NodeA, pathLength);
        }
    }
}
