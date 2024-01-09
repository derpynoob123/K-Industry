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
        vehicleMovement.ReachedJunction += SetRendererPosition;
    }

    public void FollowPath(Path path, float duration)
    {
        splineAnimate.Container = path.SplineContainer;
        splineAnimate.Duration = duration;
        splineAnimate.Restart(false);
        splineAnimate.Play();
    }

    public void SetRendererPosition(GameObject target)
    {
        rendererTransform.localPosition = target.transform.position;
    }
}
