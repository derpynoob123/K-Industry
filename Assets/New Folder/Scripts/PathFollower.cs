using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private SplineAnimate splineAnimate;

    public void FollowPath(SplineContainer path)
    {
        splineAnimate.Container = path;
        splineAnimate.Play();
    }
}
