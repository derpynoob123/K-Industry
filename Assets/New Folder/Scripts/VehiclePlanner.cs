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
    private readonly Queue<VehiclePlan> planQueue = new();
    private readonly Queue<VehicleTask> taskQueue = new();
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
                VehiclePlan plan;
                if (plans.Count == 1)
                {
                    plan = plans[0];
                }
                else
                {
                    int randomIndex = UnityEngine.Random.Range(0, plans.Count);
                    plan = plans[randomIndex];
                }
                planQueue.Enqueue(plan);
            }
        }

        if (currentPlan is null && planQueue.Count > 0)
        {
            VehiclePlan plan = planQueue.Dequeue();
            if (plan.Tasks.Count > 0)
            {
                currentPlan = plan;
                for (int taskIndex = 0; taskIndex < currentPlan.Tasks.Count; taskIndex++)
                {
                    VehicleTask task = currentPlan.Tasks[taskIndex];
                    taskQueue.Enqueue(task);
                }
                BeginNextTask();
            }
            else
            {
                Debug.LogWarning("No tasks in plan. Aborting plan.");
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
