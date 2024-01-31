using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VehiclePlan
{
    public List<VehicleTask> Tasks = new();
}

public class VehiclePlanner : MonoBehaviour
{
    public List<VehiclePlan> Plans = new();
}
