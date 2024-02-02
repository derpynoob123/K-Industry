using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFleet : MonoBehaviour
{
    [SerializeField]
    private List<VehicleController> vehicles;
    public int GetVehicleCount()
    {
        return vehicles.Count;
    }

    public List<VehicleController> GetFleet()
    {
        return vehicles;
    }
}
