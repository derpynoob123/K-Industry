using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField]
    private GameObject untoggled;
    [SerializeField]
    private GameObject toggled;

    public void Toggle()
    {
        untoggled.SetActive(false);
        toggled.SetActive(true);
    }

    public void Untoggle()
    {
        untoggled.SetActive(true);
        toggled.SetActive(false);
    }
}
