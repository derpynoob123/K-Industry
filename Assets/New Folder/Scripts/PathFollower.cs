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
        splineAnimate.Restart(true);
    }

    public void SetRendererPosition(GameObject target)
    {
        rendererTransform.position = target.transform.position;
    }
}
