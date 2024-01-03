using UnityEngine;

[System.Serializable]
public class Path
{
    public GameObject NodeA;
    public GameObject NodeB;

    public float GetPathLength()
    {
        Vector3 positionA = NodeA.transform.position;
        Vector3 positionB = NodeB.transform.position;
        return Vector3.Distance(positionA, positionB);
    }
}
