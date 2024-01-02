using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplinePath : MonoBehaviour
{
    [SerializeField]
    private SplineContainer splineContainer;
    [SerializeField]
    private List<Connection> connections;
}
