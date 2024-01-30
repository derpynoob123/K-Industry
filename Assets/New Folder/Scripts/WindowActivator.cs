using System.Collections.Generic;
using UnityEngine;
using System;

public class WindowActivator : MonoBehaviour
{
    [Serializable]
    public class Window
    {
        public ToggleButton Toggle;
        public GameObject Screen;
    }

    [SerializeField]
    private Window[] windows;
    [SerializeField]
    private WindowSelector windowSelector;
    [SerializeField]
    private GameObject activeWindow;

    private readonly Dictionary<GameObject, ToggleButton> toggles = new();

    private void Awake()
    {
        windowSelector.AddObserverToSelectedEvent(ShowWindow);
        windowSelector.AddObserverToDeselectedEvent(HideWindow);

        InitialiseToggles();
    }

    private void InitialiseToggles()
    {
        for (int windowIndex = 0; windowIndex < windows.Length; windowIndex++)
        {
            Window window = windows[windowIndex];
            toggles.Add(window.Screen, window.Toggle);
        }
    }

    private void ShowWindow()
    {
        if (activeWindow)
        {
            ToggleButton toggle = toggles[activeWindow];
            toggle.Untoggle();
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
