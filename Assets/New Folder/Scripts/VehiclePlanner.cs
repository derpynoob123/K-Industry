using System;
using System.Collections.Generic;
using Unity.Mathematics;
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

    private Dictionary<TimeInstance, List<VehiclePlan>> planTimings;
    private Queue<VehiclePlan> planQueue = new();
    private Queue<VehicleTask> taskQueue = new();
    private VehiclePlan currentPlan;
    private VehicleTask currentTask;

    private void Awake()
    {
        clock.MinutePassed += UpdatePlan;

        InitialisePlanTimings();
    }

    private void InitialisePlanTimings()
    {
        planTimings = new();
        for (int planIndex = 0; planIndex < Plans.Count; planIndex++)
        {
            VehiclePlan plan = Plans[planIndex];
            TimeInstance timing = plan.StartTime;
            if (!planTimings.ContainsKey(timing))
            {
                planTimings.Add(timing, new());
            }

            planTimings[timing].Add(plan);
        }
    }

    private void UpdatePlan()
    {
        CheckForNewPlans();

        if (currentPlan is null)
        {
            if (planQueue.Count <= 0)
            {
                return;
            }

            currentPlan = planQueue.Dequeue();
        }


    }

    private void CheckForNewPlans()
    {
        if (planTimings.ContainsKey(clock.CurrentTimeOfDay))
        {
            List<VehiclePlan> plans = planTimings[clock.CurrentTimeOfDay];
            if (plans.Count <= 0)
            {
                return;
            }

            int randomIndex = UnityEngine.Random.Range(0, plans.Count);
            VehiclePlan plan = plans[randomIndex];
            if (currentPlan is null)
            {
                currentPlan = plan;
            }
            else
            {
                planQueue.Enqueue(plan);
            }
        }
    }
}
