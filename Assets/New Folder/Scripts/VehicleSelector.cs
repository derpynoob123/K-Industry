using System;
using UnityEngine;

public class VehicleSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedVehicle; 

    private readonly Selector<VehicleController> selector = new();

    public void SelectVehicle(VehicleController vehicle)
    {
        selector.Select(vehicle);
        selectedVehicle = selector.SelectedObject.gameObject;
    }

    public void Deselect()
    {
        selector.Deselect();
        selectedVehicle = null;
    }

    public VehicleController GetSelectedVehicle()
    {
        return selector.SelectedObject;
    }

    public void AddObserverToSelectedEvent(Action observer)
    {
        selector.Selected += observer;
    }

    public void AddObserverToDeselectedEvent(Action observer)
    {
        selector.Deselected += observer;
    }
}
