using System;
using UnityEngine;

public class DayClock : MonoBehaviour
{
    [SerializeField]
    private GameManagerScript time;

    [SerializeField]
    private ClockHour currentHoursOfDay = new();

    [SerializeField]
    private ClockMinute currentMinutesOfDay = new();

    public event Action HourPassed;
    public event Action MinutePassed;

    private const string o = "0";

    private const int lengthLimit = 2;

    private void Update()
    {
        UpdateHours();
        UpdateMinutes();
    }

    private void UpdateHours()
    {
        string hours = time.hoursTime.ToString();
        if (hours.Length != lengthLimit)
        {
            hours = $"{o}{hours}";
        }
        ClockHour oldHoursOfDay = currentHoursOfDay;
        oldHoursOfDay.Tens = currentHoursOfDay.Tens;
        oldHoursOfDay.Ones = currentHoursOfDay.Ones;
        string tens = hours[..1];
        currentHoursOfDay.Tens = int.Parse(tens);
        string ones = hours.Substring(1, 1);
        currentHoursOfDay.Ones = int.Parse(ones);
        if (!IsCurrentHour(oldHoursOfDay))
        {
            HourPassed?.Invoke();
        }
    }

    private void UpdateMinutes()
    {
        int minutesInInt = Mathf.FloorToInt(time.minutesTime);
        string minutes = minutesInInt.ToString();
        if (minutes.Length != lengthLimit)
        {
            minutes = $"{o}{minutes}";
        }
        ClockMinute oldMinutesOfDay = new();
        oldMinutesOfDay.Tens = currentMinutesOfDay.Tens;
        oldMinutesOfDay.Ones = currentMinutesOfDay.Ones;
        string tens = minutes[..1];
        currentMinutesOfDay.Tens = int.Parse(tens);
        string ones = minutes.Substring(1, 1);
        currentMinutesOfDay.Ones = int.Parse(ones);
        if (!IsCurrentMinute(oldMinutesOfDay))
        {
            MinutePassed?.Invoke();
        }
    }
}
