using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleTask : MonoBehaviour
{

}

public class VehiclePlanner : MonoBehaviour
{
    public class VehiclePlan
    {
        public List<VehicleTask> Tasks;
    }
}
