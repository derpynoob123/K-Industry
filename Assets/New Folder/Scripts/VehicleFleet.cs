using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFleet : MonoBehaviour
{
    [SerializeField]
    private List<VehicleController> vehicles;

    public GameObject Seek;
    public GameObject Seek2;
    public GameObject Receive;



    public int GetVehicleCount()
    {
        return vehicles.Count;
    }

    public List<VehicleController> GetFleet()
    {
        return vehicles;
    }
}
