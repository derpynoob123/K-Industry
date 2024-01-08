using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    private VehicleNavigator navigator;
    [SerializeField]
    private VehicleMovement movement;
    [SerializeField]
    private PathNetwork pathNetwork;

    public void Seek(GameObject destination)
    {
        Node target = pathNetwork.GetNode(destination);
        Path[] paths = navigator.GetPath(target).ToArray();
        StartCoroutine(movement.FollowPath(paths));
    }
}
