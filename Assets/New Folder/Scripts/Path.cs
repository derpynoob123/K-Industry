using UnityEngine;
using UnityEngine.Splines;

public class Path : MonoBehaviour
{
    const int mainSpline = 0;

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
        return splineContainer.Spline.GetCurveLength(mainSpline);
    }
}
