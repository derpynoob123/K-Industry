using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleTask : MonoBehaviour
{
    public string TaskName = "Task";
}

public class VehiclePlanner : MonoBehaviour
{
    public class VehiclePlan
    {
        public List<VehicleTask> Tasks;
    }
}
