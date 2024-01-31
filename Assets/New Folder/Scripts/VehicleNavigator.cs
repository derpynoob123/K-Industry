using System.Collections;
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
    private Coroutine seekRoutine;

    private void Awake()
    {
        vehicleMovement.ReachedJunction += UpdateCurrentPosition;

        UpdateCurrentPosition(currentJunction);
    }

    public void Seek(GameObject destination)
    {
        if (seekRoutine is not null)
        {
            StopCoroutine(seekRoutine);
            Debug.LogWarning("Current seek aborted. Using new destination.");
        }

        Node target = pathNetwork.GetNode(destination);
        seekRoutine = StartCoroutine(Seek(target));
    }

    private IEnumerator Seek(Node destination)
    {
        if (vehicleMovement.IsFollowingPath)
        {
            Stop();
        }

        while (vehicleMovement.IsFollowingPath)
        {
            yield return null;
        }

        Path[] paths = GetPath(destination).ToArray();
        vehicleMovement.SeekPath(paths);
        seekRoutine = null;
    }

    public void Stop()
    {
        vehicleMovement.AbortPath();
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
