using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wayPoints;
    [SerializeField]
    private Path[] connections;

    private PathfindingGraph graph = new();
    private AStarPathFinder pathFinder = new();
}
