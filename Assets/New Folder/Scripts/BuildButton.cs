using UnityEngine;

public class BuildButton : MonoBehaviour
{
    [SerializeField]
    private FacilitySpawner facilitySpawner;
    [SerializeField]
    private FacilitySelector facilitySelector;

    private void Awake()
    {
        facilitySelector.AddObserverToSelectedEvent(ShowButton);
        facilitySelector.AddObserverToDeselectedEvent(HideButton);
        HideButton();
    }

    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }
}
