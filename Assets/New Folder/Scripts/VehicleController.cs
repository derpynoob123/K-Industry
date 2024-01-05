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

    public GameObject Target;

    private void Awake()
    {
        Node target = pathNetwork.GetNode(Target);
        Path[] paths = navigator.GetPath(target).ToArray();
        StartCoroutine(movement.FollowPath(paths));
    }
}
