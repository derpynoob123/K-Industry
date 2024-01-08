using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private Transform rendererTransform;
    [SerializeField]
    private SplineAnimate splineAnimate;
    [SerializeField]
    private VehicleMovement vehicleMovement;

    private void Awake()
    {
        vehicleMovement.PathFollow += FollowPath;
        vehicleMovement.ReachedPathEnd += ResetRendererPosition;
    }

    public void FollowPath(Path path, float duration)
    {
        splineAnimate.Container = path.SplineContainer;
        splineAnimate.Duration = duration;
        splineAnimate.Restart(false);
        splineAnimate.Play();
    }

    public void ResetRendererPosition()
    {
        rendererTransform.localPosition = Vector3.zero;
    }
}
