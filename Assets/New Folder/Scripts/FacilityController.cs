using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityController : MonoBehaviour
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

    private Dictionary<Tile, Node> facilityNodes;
    private Dictionary<Node, GameObject> facilities;

    private void Awake()
    {
        InitialiseFacilityNodes();
    }

    private void InitialiseFacilityNodes()
    {
        facilityNodes = new();
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

    }
}
