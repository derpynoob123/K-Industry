using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityController : MonoBehaviour
{
    public List<FacilityID> Buildables { get; set; }

    private void Awake()
    {
        Initialise();
    }

    private void Initialise()
    {
        Buildables = new()
        {
            FacilityID.PACKING,
            FacilityID.STORAGE
        };
    }
}
