using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    #region Variables
    public float userName;

    public float money;
    public float moneyText;

    public float time;
    public int day;
    public int week;
    public bool skipCheck;

    //TextUI
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI weekText;

    public GameObject startButton;

    public string sceneName = "MainGameplayScene";
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        minutesTime = 0;
        hoursTime = 0;
        day = 0;
        dayCount = 0;
        week = 0;

        skipCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (minutesTime >= 60)
        {
            minutesTime = 0;
            hoursTime++;
        }

        if (hoursTime >= 24)
        {
            hoursTime = 0;
            day++;
            dayCount++;
            skipCheck = false;
        }

        if (dayCount >= 7)
        {
            week++;
            dayCount = 0;
        }
        #endregion

        #region Slow down In-game time for player change
        if ((hoursTime >= 17) && (skipCheck == false))
        {
            minMul = 1;
        }
        else
        {
            minMul = 60;
        }
        #endregion

        #region Display variables onto UI
        timeText.text = $"{hoursTime}:{minInt}";
        dayText.text = $"Day: {day}";
        weekText.text = $"Week: {week}";
        #endregion
    }

    //Start screen to main play screen
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SkipButton()
    {
        skipCheck = true;
    }
}
