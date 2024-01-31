using System;
using UnityEngine;

public class DayClock : MonoBehaviour
{
    [SerializeField]
    private GameManagerScript time;

    [SerializeField]
    private string currentTimeInString;

    public event Action HourPassed;
    public event Action MinutePassed;

    public TimeInstance CurrentTimeOfDay { get; private set; }

    private const string o = "0";
    private const int lengthLimit = 2;

    private void Awake()
    {
        CurrentTimeOfDay = new();
    }

    private void Update()
    {
        UpdateHours();
        UpdateMinutes();
        UpdateCurrentTime();
    }

    private void UpdateCurrentTime()
    {
        string hour = $"{CurrentTimeOfDay.Hour.Tens}{CurrentTimeOfDay.Hour.Ones}";
        string minute = $"{CurrentTimeOfDay.Minute.Tens}{CurrentTimeOfDay.Minute.Ones}";
        currentTimeInString = hour + minute;
    }

    private void UpdateHours()
    {
        string hours = time.hoursTime.ToString();
        if (hours.Length != lengthLimit)
        {
            hours = $"{o}{hours}";
        }

        ClockHour oldHoursOfDay = new()
        {
            Tens = CurrentTimeOfDay.Hour.Tens,
            Ones = CurrentTimeOfDay.Hour.Ones
        };
        string tens = hours[..1];
        CurrentTimeOfDay.Hour.Tens = int.Parse(tens);
        string ones = hours.Substring(1, 1);
        CurrentTimeOfDay.Hour.Ones = int.Parse(ones);
        if (!ClockHour.IsSameHour(oldHoursOfDay, CurrentTimeOfDay.Hour))
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
        ClockMinute oldMinutesOfDay = new()
        {
            Tens = CurrentTimeOfDay.Minute.Tens,
            Ones = CurrentTimeOfDay.Minute.Ones
        };
        string tens = minutes[..1];
        CurrentTimeOfDay.Minute.Tens = int.Parse(tens);
        string ones = minutes.Substring(1, 1);
        CurrentTimeOfDay.Minute.Ones = int.Parse(ones);
        if (!ClockMinute.IsSameMinute(oldMinutesOfDay, CurrentTimeOfDay.Minute))
        {
            MinutePassed?.Invoke();
        }
    }
}
