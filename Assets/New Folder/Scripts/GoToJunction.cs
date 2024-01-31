public class GoToJunction : VehicleTask
{
    private VehicleNavigator vehicleNavigator;

    private void Awake()
    {
        vehicleNavigator = gameObject.GetComponent<VehicleNavigator>();
    }
}
