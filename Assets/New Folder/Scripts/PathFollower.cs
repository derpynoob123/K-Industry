using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private SplineAnimate splineAnimate;
    [SerializeField]
    private VehicleMovement vehicleMovement;

    private void Awake()
    {
        vehicleMovement.PathFollow += FollowPath;
    }

    public void FollowPath(Path path, float duration)
    {
        if (splineAnimate.IsPlaying)
        {
            splineAnimate.Restart(false);
        }

        splineAnimate.Container = path.SplineContainer;
        splineAnimate.Duration = duration;
        splineAnimate.Play();
    }
}
