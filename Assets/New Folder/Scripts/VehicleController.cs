using System;
using System.Collections;
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
    private StorageUnitBehaviour storage;

    private void Awake()
    {
        GenerateGUID();
    }

    public void Unload(GameObject receiver)
    {
        storage.SendUnit(receiver);
    }
}
