using System;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    private string guid;

    private const int guidSubLength = 4;

    private void GenerateGUID()
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

    private void Awake()
    {
        GenerateGUID();
    }
}
