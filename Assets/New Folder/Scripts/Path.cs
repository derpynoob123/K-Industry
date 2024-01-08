using UnityEngine;
using UnityEngine.Splines;

public class Path : MonoBehaviour
{
    private const int scale = 100000;

    [SerializeField]
    private GameObject startNode;
    public GameObject StartNode
    {
        get
        {
            return startNode;
        }
    }
    [SerializeField]
    private GameObject endNode;
    public GameObject EndNode
    {
        get
        {
            return endNode;
        }
    }
    [SerializeField]
    private SplineContainer splineContainer;
    public SplineContainer SplineContainer
    {
        get
        {
            return splineContainer;
        }
    }

    public float GetDistanceInUnits()
    {
        return splineContainer.Spline.GetLength();
    }

    public float GetDistanceInMetres()
    {
        float distance = GetDistanceInUnits() * scale;
        return distance;
    }
}
