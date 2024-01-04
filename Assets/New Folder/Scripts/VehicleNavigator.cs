using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject currentNodeGameObject;
    [SerializeField]
    private PathNetwork pathNetworkManager;

    private AStarPathFinder pathfinder = new();
    private Node currentNode;

    private void Awake()
    {
        currentNode = pathNetworkManager.GetNode(currentNodeGameObject);
    }

    public Path[] GetPath(Node destination)
    {
        List<Connection> connections = pathfinder.FindPath(currentNode, destination);

    }
}
