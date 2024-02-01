using System;
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

    public event Action ReachedDestination;
    public event Action CannotReachDestination;

    private readonly AStarPathFinder pathfinder = new();
    private Node currentNode;
    private Coroutine seekRoutine;
    private Node destinationNode;

    private void Awake()
    {
        vehicleMovement.ReachedJunction += UpdateCurrentPosition;
        vehicleMovement.ReachedJunction += CheckIfDestinationReached;

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
        if (paths is not null)
        {
            vehicleMovement.SeekPath(paths);
            destinationNode = destination;
        }
        else
        {
            CannotReachDestination?.Invoke();
            Debug.LogError("There is no path to the destination. Aborting seek.");
        }
        seekRoutine = null;
    }

    public void Stop()
    {
        vehicleMovement.AbortPath();
    }

    private void UpdateCurrentPosition(GameObject junction)
    {
        Node node = pathNetwork.GetNode(junction);
        currentNode = node;
        currentJunction = junction;
    }

    private void CheckIfDestinationReached(GameObject junction)
    {
        Node node = pathNetwork.GetNode(junction);
        if (destinationNode == node)
        {
            destinationNode = null;
            ReachedDestination?.Invoke();
        }
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
