using UnityEngine;
using UnityEngine.Splines;

public class Path : MonoBehaviour
{
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

    public float GetDistance()
    {
        return splineContainer.Spline.GetCurveLength(0);
    }
}
