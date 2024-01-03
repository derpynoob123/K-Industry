using UnityEngine;

[System.Serializable]
public class Path
{
    public GameObject NodeA;
    public GameObject NodeB;
    public float Distance;

    public float GetPathLength()
    {
        return Distance;
    }
}
