using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AgencyAccess : MonoBehaviour
{
    public GameObject InputObject;

    public void checkAgency()
    {
        string InputtedAgency = InputObject.GetComponent<InputField>().text;
        if(InputtedAgency == "")
        {
            //for webgl
            if(Application.platform == RuntimePlatform.WebGLPlayer)
            {
                PlayerPrefs.SetString("Agency", "webplay");
                GoToScene("SampleScene");
            }
            else
            {
               //for pc 
               return;
            }

        }
        else
        {
            PlayerPrefs.SetString("Agency", InputtedAgency);
            GoToScene("SampleScene");
        }
    }

    void GoToScene(string SceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(SceneName))
        {
            Debug.Log("Scene exists, loading...");
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            Debug.Log("Scene does not exist");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
