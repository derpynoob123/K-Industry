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
    [SerializeField]
    private List<VehiclePlan> plans = new();

    private readonly Queue<VehiclePlan> planQueue = new();
    private readonly Queue<VehicleTask> taskQueue = new();

    private VehiclePlan currentPlan;
    private VehicleTask currentTask;

    private void Awake()
    {
        clock.MinutePassed += Process;
    }

    private void Process()
    {
        if (IsTimeToStartPlan())
        {
            VehiclePlan plan = GetPlan(clock.CurrentTimeOfDay);
            planQueue.Enqueue(plan);
        }

        if (!CurrentPlanExists() && HavePlansInQueue())
        {
            BeginNextPlan();
            BeginNextTask();
        }

        if (!CurrentTaskExists())
        {
            return;
        }

        if (!currentTask.Running)
        {
            currentTask = null;
            if (HaveTasksInQueue())
            {
                BeginNextTask();
            }
            else
            {
                currentPlan = null;
            }
        }
    }

    private VehiclePlan GetPlan(TimeInstance time)
    {
        VehiclePlan[] plans = GetPlans(time);

        VehiclePlan plan;
        if (plans.Length == 1)
        {
            plan = plans[0];
        }
        else
        {
            int randomIndex = UnityEngine.Random.Range(0, plans.Length);
            plan = plans[randomIndex];
        }
        return plan;
    }

    private VehiclePlan[] GetPlans(TimeInstance time)
    {
        List<VehiclePlan> plans = new();
        for (int planIndex = 0; planIndex < this.plans.Count; planIndex++)
        {
            VehiclePlan plan = this.plans[planIndex];
            if (TimeInstance.IsSameTime(plan.StartTime, time))
            {
                plans.Add(plan);
            }
        }
        return plans.ToArray();
    }

    private void BeginNextPlan()
    {
        currentPlan = planQueue.Dequeue();
        VehicleTask[] planTasks = currentPlan.Tasks.ToArray();
        InitialiseTaskQueue(planTasks);
    }

    private void InitialiseTaskQueue(VehicleTask[] tasks)
    {
        taskQueue.Clear();
        for (int taskIndex = 0; taskIndex < tasks.Length; taskIndex++)
        {
            VehicleTask task = tasks[taskIndex];
            taskQueue.Enqueue(task);
        }
    }

    private void BeginNextTask()
    {
        currentTask = taskQueue.Dequeue();
        currentTask.ExecuteTask();
        currentTask.Running = true;
    }

    private bool CurrentPlanExists()
    {
        if (currentPlan is null)
        {
            return false;
        }
        return true;
    }

    private bool CurrentTaskExists()
    {
        if (currentTask == null)
        {
            return false;
        }
        return true;
    }

    private bool HavePlansInQueue()
    {
        if (planQueue.Count > 0)
        {
            return true;
        }
        return false;
    }

    private bool HaveTasksInQueue()
    {
        if (taskQueue.Count > 0)
        {
            return true;
        }
        return false;
    }

    private bool IsTimeToStartPlan()
    {
        for (int planIndex = 0; planIndex < plans.Count; planIndex++)
        {
            TimeInstance time = plans[planIndex].StartTime;
            if (TimeInstance.IsSameTime(time, clock.CurrentTimeOfDay))
            {
                return true;
            }
        }
        return false;
    }
}
