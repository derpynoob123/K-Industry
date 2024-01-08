using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportManager : MonoBehaviour
{
    [SerializeField]
    private List<VehicleController> vehicles;
    public GameObject Target;

    private void Start()
    {
        vehicles[0].Seek(Target);
    }
}
