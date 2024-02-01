using UnityEngine;

public abstract class VehicleTask : MonoBehaviour
{
    public string TaskName = "Task";
    public bool Running = false;

    public abstract void ExecuteTask();

    protected void FinishTask()
    {
        Running = false;
    }
}
