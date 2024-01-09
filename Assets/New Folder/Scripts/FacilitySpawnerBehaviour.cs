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
    private Transform facilityParent;
    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private FacilitySelectorBehaviour facilitySelector;
    [SerializeField]
    private FacilitySpawn[] facilityPrefabs;

    public event Action<Tile, GameObject> FacilitySpawned;

    private Dictionary<FacilityID, GameObject> prefabIDs;

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

    public void Spawn()
    {
        Tile tile = tileSelector.GetSelectedTile();
        FacilityID id = facilitySelector.GetSelectedFacility();
        GameObject prefab = prefabIDs[id];
        GameObject newFacility = Instantiate(prefab);
        newFacility.transform.position = tile.TileTransform.position;
        newFacility.transform.SetParent(facilityParent);
        FacilitySpawned.Invoke(tile, newFacility);
    }

    public FacilityID[] GetBuildableFacilities()
    {
        return prefabIDs.Keys.ToArray();
    }
}
