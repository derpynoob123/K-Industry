using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dashboard : MonoBehaviour
{
    [SerializeField]
    private VehicleFleet vehicleFleet;

    [SerializeField]
    private TMP_Text vehicleCountText;

    private void LateUpdate()
    {
        UpdateDashboard();
    }

    private void UpdateDashboard()
    {
        string vehicleCount = vehicleFleet.GetVehicleCount().ToString();
        vehicleCountText.text = $"Vehicle: {vehicleCount}";
    }
}
