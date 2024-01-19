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

    private IEnumerator Start()
    {
        yield return null;
        vehicles[0].SeekDestination(Seek);
        yield return new WaitForSeconds(3);
        vehicles[0].SeekDestination(Seek2);
    }
}
