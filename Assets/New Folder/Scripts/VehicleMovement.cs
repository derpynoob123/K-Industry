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

    public IEnumerator FollowPath(Path[] paths)
    {
        for (int pathIndex = 0; pathIndex < paths.Length; pathIndex++)
        {
            Path path = paths[pathIndex];
            float distanceInUnits = path.GetDistanceInUnits(); 
            float distanceInMetres = distanceInUnits * 100000;
            float distanceInKilometres = distanceInMetres / 1000;
            float duration = distanceInKilometres / speedInKilometrePerHour;
            Vector3 newPosition = path.EndNode.transform.position;
            PathFollow.Invoke(path, duration);
            print(duration);
            yield return new WaitForSeconds(duration);
            vehicle.position = newPosition;
            print(vehicle.position);
        }
    }
}
