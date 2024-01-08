using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject currentNodeGameObject;
    [SerializeField]
    private PathNetwork pathNetwork;

    private AStarPathFinder pathfinder = new();
    private Node currentNode;

    private void Awake()
    {
        currentNode = pathNetwork.GetNode(currentNodeGameObject);
    }

    public List<Path> GetPath(Node destination)
    {
        List<Connection> connections = pathfinder.FindPath(currentNode, destination);
        List<Path> paths = new();
        for (int connectionIndex = 0; connectionIndex < connections.Count; connectionIndex++)
        {
            Connection connection = connections[connectionIndex];
            Path path = pathNetwork.GetPath(connection);
            paths.Add(path);
        }
        return paths;
    }
}
