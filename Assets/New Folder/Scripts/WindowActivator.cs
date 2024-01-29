using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowActivator : MonoBehaviour
{
    [SerializeField]
    private WindowSelector windowSelector;
    [SerializeField]
    private GameObject activeWindow;

    private void Awake()
    {
        windowSelector.AddObserverToSelectedEvent(ShowWindow);
        windowSelector.AddObserverToDeselectedEvent(HideWindow);
    }

    private void ShowWindow()
    {
        if (activeWindow)
        {
            HideWindow();
        }

        activeWindow = windowSelector.GetWindow();
        activeWindow.SetActive(true);
    }
    
    private void HideWindow()
    {
        activeWindow.SetActive(false);
        activeWindow = null;
    }
}
