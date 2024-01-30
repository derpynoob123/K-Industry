using System.Collections.Generic;
using UnityEngine;

public class VehicleNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject currentJunction;
    [SerializeField]
    private PathNetwork pathNetwork;
    [SerializeField]
    private VehicleMovement vehicleMovement;

    private readonly AStarPathFinder pathfinder = new();
    private Node currentNode;

    private void Awake()
    {
        vehicleMovement.ReachedJunction += UpdateCurrentPosition;

        UpdateCurrentPosition(currentJunction);
    }

    public void UpdateCurrentPosition(GameObject current)
    {
        Node node = pathNetwork.GetNode(current);
        currentNode = node;
        currentJunction = current;
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
