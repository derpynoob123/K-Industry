using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private List<SplineContainer> paths;
    [SerializeField]
    private SplineAnimate splineAnimate;

    private void Awake()
    {

    }
}
