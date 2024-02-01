using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VehiclePlan
{
    [SerializeField]
    private TimeInstance startTime = new();
    public TimeInstance StartTime
    {
        get => startTime;
    }
    [SerializeField]
    private List<VehicleTask> tasks = new();
    public List<VehicleTask> Tasks
    {
        get => tasks;
    }
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
        clock.MinutePassed += Process;

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

    private void Process()
    {
        UpdatePlan();
        if (currentTask == null)
        {
            return;
        }

        UpdateTask();
    }

    private void UpdatePlan()
    {
        if (planTimings.ContainsKey(clock.CurrentTimeOfDay))
        {
            List<VehiclePlan> plans = planTimings[clock.CurrentTimeOfDay];
            if (plans.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, plans.Count);
                VehiclePlan plan = plans[randomIndex];
                planQueue.Enqueue(plan);
            }
        }

        if (currentPlan is null && planQueue.Count > 0)
        {
            VehiclePlan plan = planQueue.Dequeue();
            if (plan.Tasks.Count > 0)
            {
                currentPlan = plan;
                taskQueue = new Queue<VehicleTask>(currentPlan.Tasks);

                BeginNextTask();
            }
        }
    }

    private void UpdateTask()
    {
        if (!currentTask.Running)
        {
            currentTask = null;
        }

        if (currentTask == null)
        {
            if (taskQueue.Count > 0)
            {
                BeginNextTask();
            }
            else
            {
                currentPlan = null;
            }
        }
    }

    private void BeginNextTask()
    {
        currentTask = taskQueue.Dequeue();
        currentTask.ExecuteTask();
        currentTask.Running = true;
    }
}
