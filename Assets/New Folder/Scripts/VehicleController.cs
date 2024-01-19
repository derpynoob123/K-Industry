using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    private VehicleNavigator navigator;
    [SerializeField]
    private VehicleMovement movement;
    [SerializeField]
    private PathNetwork pathNetwork;
    [SerializeField]
    private StorageUnitBehaviour storage;

    public void SeekDestination(GameObject destination)
    {
        Node target = pathNetwork.GetNode(destination);
        StartCoroutine(Seek(target));
    }

    private IEnumerator Seek(Node destination)
    {
        if (movement.IsFollowingPath)
        {
            Stop();
        }

        while (movement.IsFollowingPath)
        {
            yield return null;
        }

        Path[] paths = navigator.GetPath(destination).ToArray();
        movement.SeekPath(paths);
    }

    public void Stop()
    {
        movement.AbortPath();
    }

    public void Unload(GameObject receiver)
    {
        storage.SendUnit(receiver);
    }
}
