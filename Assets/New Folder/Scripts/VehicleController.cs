using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    private GameObject currentNode;
    [SerializeField]
    private PathNetworkManager pathNetworkManager;

    private AStarPathFinder pathfinder = new();

    private void Awake()
    {
        
    }

    public void GoToNode(Node destination)
    {

    }
}
