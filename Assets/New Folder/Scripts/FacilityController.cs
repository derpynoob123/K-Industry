using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityController : MonoBehaviour
{
    [Serializable]
    public class FacilityPoint
    {
        public GameObject Tile;
        public GameObject Junction;
    }

    [SerializeField]
    private FacilitySpawnerBehaviour facilitySpawner;
    [SerializeField]
    private FacilityPoint[] facilityPoints; 

    private Dictionary<Node, GameObject> facilities;

    private void Awake()
    {

    }

    private void AddNewFacility(Tile tile, GameObject facility)
    {

    }
}
