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

    private Queue<VehiclePlan> planQueue;
    private Queue<VehicleTask> taskQueue;
    private VehiclePlan currentPlan;
    private VehicleTask currentTask;

    private void Awake()
    {
        clock.MinutePassed += UpdatePlan;
    }

    private void UpdatePlan()
    {
        if (IsThereAPlanStarting())
        {

        }

        if (currentPlan is null)
        {
            return;
        }


    }

    private bool IsThereAPlanStarting()
    {
        for (int planIndex = 0; planIndex < Plans.Count; planIndex++)
        {
            VehiclePlan plan = Plans[planIndex];
            if (clock.IsSameTimeOfDay(plan.StartTime))
            {
                return true;
            }
        }
        return false;
    }


}
