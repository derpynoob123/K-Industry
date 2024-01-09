using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityGroup : MonoBehaviour
{
    [Serializable]
    public class FacilityPoint
    {
        public Transform Tile;
        public GameObject Junction;
    }

    [SerializeField]
    private FacilitySpawnerBehaviour facilitySpawner;
    [SerializeField]
    private MapBehaviour map;
    [SerializeField]
    private PathNetwork pathNetwork;
    [SerializeField]
    private FacilityPoint[] facilityPoints;

    private Dictionary<Tile, Node> facilityNodes = new();
    private Dictionary<Node, GameObject> facilities = new();

    private void Awake()
    {
        facilitySpawner.FacilitySpawned += AddNewFacility; 

        InitialiseFacilityNodes();
    }

    private void InitialiseFacilityNodes()
    {
        for (int facilityPointIndex = 0; facilityPointIndex < facilityPoints.Length; facilityPointIndex++)
        {
            FacilityPoint point = facilityPoints[facilityPointIndex];
            Tile tile = map.GetTile(point.Tile);
            Node node = pathNetwork.GetNode(point.Junction);
            facilityNodes.Add(tile, node);
        }
    }

    private void AddNewFacility(Tile tile, GameObject facility)
    {
        Node node = facilityNodes[tile];
        facilities.Add(node, facility);
    }
}
