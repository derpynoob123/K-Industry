using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField]
    private Transform vehicle;
    [SerializeField]
    private float speedInKilometrePerHour;

    public event Action<Path, float> PathFollow;
    public event Action<GameObject> ReachedJunction;

    public bool IsFollowingPath { get; private set; }

    private Coroutine movementRoutine;
    private bool stopFollowing = false;

    public void SeekPath(Path[] paths)
    {
        movementRoutine = StartCoroutine(FollowPath(paths));
    }

    public void AbortPath()
    {
        if (!IsFollowingPath)
        {
            return;
        }

        stopFollowing = true;
    }

    private IEnumerator FollowPath(Path[] paths)
    {
        IsFollowingPath = true;
        for (int pathIndex = 0; pathIndex < paths.Length; pathIndex++)
        {
            if (stopFollowing)
            {
                stopFollowing = false;
                break;
            }

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
        IsFollowingPath = false;
    }
}
