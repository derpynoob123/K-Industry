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
    private readonly List<Tile> facilityTiles = new();

    private void Awake()
    {
        facilitySpawner.FacilitySpawned += AddNewFacility;

        InitialiseFacilityPoints();
    }

    private void InitialiseFacilityPoints()
    {
        for (int pointIndex = 0; pointIndex < facilityPoints.Length; pointIndex++)
        {
            FacilityPoint point = facilityPoints[pointIndex];
            facilityLookUp.Add(point.Tile, point);
            Tile tile = map.GetTile(point.Tile);
            facilityTiles.Add(tile);
        }
    }

    private void AddNewFacility(Tile tile, GameObject facility)
    {
        FacilityPoint point = facilityLookUp[tile.TileTransform];
        point.Facility = facility;
    }

    public Tile[] GetTiles()
    {
        return facilityTiles.ToArray();
    }
}
