using UnityEngine;

public class GoToJunction : VehicleTask
{
    public GameObject Junction;

    private VehicleNavigator vehicleNavigator;

    private void Awake()
    {
        vehicleNavigator = gameObject.GetComponent<VehicleNavigator>();
    }

    public override void ExecuteTask()
    {
        vehicleNavigator.Seek(Junction);
    }
}
