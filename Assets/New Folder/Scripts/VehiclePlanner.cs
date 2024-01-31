using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VehiclePlan
{
    public TimeInstance StartTime;
    public List<VehicleTask> Tasks = new();
}

public class VehiclePlanner : MonoBehaviour
{
    [SerializeField]
    private DayClock clock;

    public List<VehiclePlan> Plans = new();

    private VehiclePlan currentPlan;

    private void Awake()
    {
        clock.MinutePassed += UpdatePlan;
    }

    private void UpdatePlan()
    {
        for (int plan = 0; plan < Plans.Count; plan++)
        {

        }
    }
}
