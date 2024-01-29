using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    private string guid;

    private const int guidSubLength = 4;

    public void GenerateGUID()
    {
        guid = Guid.NewGuid().ToString();
    }

    public string GetGUID()
    {
        return guid;
    }

    public string GetFirstGUIDDigits()
    {
        return guid[..guidSubLength];
    }

    public string GetLastGUIDigits()
    {
        int startIndex = guid.Length - guidSubLength;
        return guid.Substring(startIndex, guidSubLength);
    }

    [SerializeField]
    private VehicleNavigator navigator;
    [SerializeField]
    private VehicleMovement movement;
    [SerializeField]
    private PathNetwork pathNetwork;
    [SerializeField]
    private StorageUnitBehaviour storage;

    private void Awake()
    {
        GenerateGUID();
    }

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
