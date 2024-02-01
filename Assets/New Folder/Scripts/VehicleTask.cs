using UnityEngine;

public abstract class VehicleTask : MonoBehaviour
{
    public string TaskName = "Task";
    public bool Running = false;

    protected abstract void Process();
    public void ExecuteTask()
    {
        Process();
        Running = true;
    }

    public void FinishTask()
    {
        Running = false;
    }
}
