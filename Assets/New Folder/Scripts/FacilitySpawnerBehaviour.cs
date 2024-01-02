using System;
using System.Collections.Generic;
using UnityEngine;

public class FacilitySpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private FacilitySelectorBehaviour facilitySelector;
    [SerializeField]
    private FacilityController facilityController;
    [SerializeField]
    private List<GameObject> facilityPrefabs;

    private Dictionary<FacilityID, GameObject> prefabIDs;
    //list of active facilities
    private Dictionary<Tile, GameObject> spawnedFacilities = new();

    private void Awake()
    {
        prefabIDs = new()
        {
            { FacilityID.PACKING, facilityPrefabs[0] },
            { FacilityID.STORAGE, facilityPrefabs[1] }
        };
    }

    public void Spawn()
    {
        Tile tile = tileSelector.GetSelectedTile();
        if (spawnedFacilities.ContainsKey(tile))
        {
            Debug.Log("Cannot build on tile containing an existing facility!");
            return;
        }

        FacilityID id = facilitySelector.GetSelectedFacility();
        GameObject prefab = prefabIDs[id];
        GameObject newFacility = Instantiate(prefab);
        spawnedFacilities.Add(tile, newFacility);
        newFacility.transform.position = tile.TileTransform.position;
    }
}
