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
    private List<GameObject> facilityPrefabs;

    public void Spawn()
    {

    }
}
