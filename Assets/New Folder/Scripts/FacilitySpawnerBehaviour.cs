using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FacilitySpawnerBehaviour : MonoBehaviour
{
    [Serializable]
    public class FacilitySpawn
    {
        public FacilityID ID;
        public GameObject FacilityPrefab;
    }

    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private FacilitySelectorBehaviour facilitySelector;
    [SerializeField]
    private FacilitySpawn[] facilityPrefabs;

    private Dictionary<FacilityID, GameObject> prefabIDs;
    //list of active facilities
    private Dictionary<Tile, GameObject> spawnedFacilities = new();

    private void Awake()
    {
        InitialiseSpawns();
    }

    private void InitialiseSpawns()
    {
        prefabIDs = new();
        for (int facilitySpawnIndex = 0; facilitySpawnIndex < facilityPrefabs.Length; facilitySpawnIndex++)
        {
            FacilitySpawn spawn = facilityPrefabs[facilitySpawnIndex];
            prefabIDs.Add(spawn.ID, spawn.FacilityPrefab);
        }
    }

    public void Build()
    {
        Tile tile = tileSelector.GetSelectedTile();
        if (spawnedFacilities.ContainsKey(tile))
        {
            Debug.Log("Cannot build on tile containing an existing facility!");
            return;
        }
        Spawn(tile);
    }

    public void Spawn(Tile tile)
    {
        FacilityID id = facilitySelector.GetSelectedFacility();
        GameObject prefab = prefabIDs[id];
        GameObject newFacility = Instantiate(prefab);
        spawnedFacilities.Add(tile, newFacility);
        newFacility.transform.position = tile.TileTransform.position;
    }

    public FacilityID[] GetBuildableFacilities()
    {
        return prefabIDs.Keys.ToArray();
    }
}
