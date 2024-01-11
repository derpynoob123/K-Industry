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

    //Time variables
    public int minMul = 60;
    public float minutesTime;
    public int hoursTime;
    public int day;
    public int dayCount;
    public int week;

    public float locOrderTimer;
    public float intOrderTimer;
    public float orderGenTime;

    //Customer variables
    public int locRep;
    public int intRep;
    public float minBanana;
    public float maxBanana;
    public float locBanana;
    public float intBanana;

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
<<<<<<< Updated upstream
=======

        skipCheck = false;

        locRep = 50;
        intRep = 50;

        orderGenTime = 10f;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        #region In-game time counting
        //Timer counting
        minutesTime += minMul * Time.deltaTime;
        int minInt = (int)minutesTime;
        Debug.Log(minutesTime);

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
        }

        if (dayCount >= 7)
        {
            week++;
            dayCount = 0;
        }
        #endregion

        #region Slow down In-game time for player change
        if (hoursTime >= 17)
        {
            minMul = 1;
        }
        #endregion

        #region Display variables onto UI
        timeText.text = $"{hoursTime}:{minInt}";
        dayText.text = $"Day: {day}";
        weekText.text = $"Week: {week}";
        #endregion

        orderGenTime -= Time.deltaTime;
    }

    //Start screen to main play screen
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
<<<<<<< Updated upstream
=======

    public void SkipButton()
    {
        skipCheck = true;
    }

    public void LocalMarketOrderGenerator()
    {
        if (orderGenTime <= 0)
        {
            orderGenTime = 10f;
            locBanana = Random.Range(minBanana, maxBanana);
        }
    }
>>>>>>> Stashed changes
}
