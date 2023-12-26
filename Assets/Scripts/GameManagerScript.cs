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
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //Start screen to main play screen
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
