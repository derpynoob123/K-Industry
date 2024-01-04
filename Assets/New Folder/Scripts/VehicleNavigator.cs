using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleNavigator : MonoBehaviour
{
    [SerializeField]
    private GameObject currentNodeGameObject;
    [SerializeField]
    private PathNetworkManager pathNetworkManager;

    private AStarPathFinder pathfinder = new();
    private Node currentNode;

    private void Awake()
    {
        currentNode = pathNetworkManager.GetNode(currentNodeGameObject);
    }
}
