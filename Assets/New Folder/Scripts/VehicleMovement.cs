using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField]
    private Transform vehicle;
    [SerializeField]
    private float speedInKilometrePerHour;

    public event Action<Path, float> PathFollow;
    public event Action<GameObject> ReachedJunction;

    public bool IsMoving { get; private set; }

    private Coroutine movementRoutine;

    public void SeekPath(Path[] paths)
    {
        movementRoutine = StartCoroutine(FollowPath(paths));
    }

    private IEnumerator FollowPath(Path[] paths)
    {
        IsMoving = true;
        for (int pathIndex = 0; pathIndex < paths.Length; pathIndex++)
        {
            Path path = paths[pathIndex];
            float distanceInMetres = path.GetDistanceInMetres();
            float distanceInKilometres = distanceInMetres / 1000;
            float duration = distanceInKilometres / speedInKilometrePerHour;
            Vector3 newPosition = path.EndNode.transform.position;
            PathFollow.Invoke(path, duration);
            yield return new WaitForSeconds(duration);
            vehicle.position = newPosition;
            ReachedJunction.Invoke(path.EndNode);
        }
        IsMoving = false;
    }
}
