using TMPro;
using UnityEngine;

public class Dashboard : MonoBehaviour
{
    [SerializeField]
    private VehicleFleet vehicleFleet;

    [SerializeField]
    private TMP_Text vehicleCountText;
    [SerializeField]
    private TMP_Text currentMoneyText;

    private void LateUpdate()
    {
        UpdateDashboard();
    }

    private void UpdateDashboard()
    {
        string vehicleCount = vehicleFleet.GetVehicleCount().ToString();
        vehicleCountText.text = $"Vehicle: {vehicleCount}";

        string currentMoney = PlayerResource.Money.ToString();
        currentMoneyText.text = $"Current Money: {currentMoney}";
    }
}
