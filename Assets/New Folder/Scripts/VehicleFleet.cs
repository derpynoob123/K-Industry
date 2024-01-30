using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFleet : MonoBehaviour
{
    [SerializeField]
    private List<VehicleController> vehicles;
    [SerializeField]
    private DayClock clock;

    public GameObject Seek;
    public GameObject Seek2;
    public GameObject Receive;

    public DayClock.ClockTime Min;
    public DayClock.ClockTime Hr;

    private void Awake()
    {
        clock.MinuteChanged += Chekk;
    }

    private void Chekk()
    {
        if (clock.IsSameTimeOfDay(Hr, Min))
        {
            print('r');
            StartCoroutine(Rout());
        }
    }

    private IEnumerator Rout()
    {
        vehicles[0].SeekDestination(Seek);
        yield return new WaitForSeconds(3);
        vehicles[0].SeekDestination(Seek2);
    }

    public int GetVehicleCount()
    {
        return vehicles.Count;
    }

    public List<VehicleController> GetFleet()
    {
        return vehicles;
    }
}
