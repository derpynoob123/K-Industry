using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFleet : MonoBehaviour
{
    [SerializeField]
    private List<VehicleController> vehicles;

    public GameObject Seek;

    private IEnumerator Start()
    {
        yield return null;
        vehicles[0].Seek(Seek);
    }
}
