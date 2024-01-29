using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FacilitySpawner : MonoBehaviour
{
    [Serializable]
    public class FacilitySpawn
    {
        public FacilityID ID;
        public GameObject FacilityPrefab;
    }

    [SerializeField]
    private FacilityBuilder facilityBuilder;
    [SerializeField]
    private Transform facilityParent;
    [SerializeField]
    private TileSelector tileSelector;
    [SerializeField]
    private FacilitySelector facilitySelector;
    [SerializeField]
    private FacilitySpawn[] facilityPrefabs;

    public event Action<Tile, GameObject> FacilitySpawned;

    private readonly Dictionary<FacilityID, GameObject> prefabIDs = new();

    private void Awake()
    {
        facilityBuilder.Built += Spawn;

        InitialiseSpawns();
    }

    private void InitialiseSpawns()
    {
        for (int facilitySpawnIndex = 0; facilitySpawnIndex < facilityPrefabs.Length; facilitySpawnIndex++)
        {
            FacilitySpawn spawn = facilityPrefabs[facilitySpawnIndex];
            prefabIDs.Add(spawn.ID, spawn.FacilityPrefab);
        }
    }

    public void Spawn()
    {
        FacilityID id = facilitySelector.GetSelectedFacility();
        GameObject prefab = prefabIDs[id];
        GameObject newFacility = Instantiate(prefab);
        Tile tile = tileSelector.GetSelectedTile();
        newFacility.transform.position = tile.TileTransform.position;
        newFacility.transform.SetParent(facilityParent);
        FacilitySpawned.Invoke(tile, newFacility);
    }

    public FacilityID[] GetBuildableFacilities()
    {
        return prefabIDs.Keys.ToArray();
    }
}
