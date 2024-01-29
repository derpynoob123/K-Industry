using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VehicleTime : MonoBehaviour
{
    [SerializeField]
    private GameManagerScript time;

    [SerializeField]
    private int[] minutesOfDay = { 0, 0 };

    private const string o = "0";

    private void Update()
    {
        int minutesInInt = Mathf.FloorToInt(time.minutesTime);
        string minutes = minutesInInt.ToString();
        if (minutes.Length != minutesOfDay.Length)
        {
            minutes = $"{o}{minutes}";
        }
        for (int minuteIndex = 0; minuteIndex < minutesOfDay.Length; minuteIndex++)
        {
            string minute = minutes.Substring(minuteIndex, 1);
            minutesOfDay[minuteIndex] = int.Parse(minute);
        }
    }
}
