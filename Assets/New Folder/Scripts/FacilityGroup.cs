using System;
using System.Collections.Generic;
using UnityEngine;

public class FacilityGroup : MonoBehaviour
{
    [Serializable]
    public class FacilityPoint
    {
        public Transform Tile;
        public GameObject Junction;
        public GameObject Facility;
    }

    [SerializeField]
    private FacilitySpawner facilitySpawner;
    [SerializeField]
    private MapBehaviour map;
    [SerializeField]
    private PathNetwork pathNetwork;
    [SerializeField]
    private FacilityPoint[] facilityPoints;

    private readonly Dictionary<Transform, FacilityPoint> facilityLookUp = new();

    private void Awake()
    {
        facilitySpawner.FacilitySpawned += AddNewFacility;

        InitialiseFacilityLookUp();
    }

    private void InitialiseFacilityLookUp()
    {
        for (int pointIndex = 0; pointIndex < facilityPoints.Length; pointIndex++)
        {
            FacilityPoint point = facilityPoints[pointIndex];
            facilityLookUp.Add(point.Tile, point);
        }
    }

    private void AddNewFacility(Tile tile, GameObject facility)
    {
        FacilityPoint point = facilityLookUp[tile.TileTransform];
        point.Facility = facility;
    }
}
