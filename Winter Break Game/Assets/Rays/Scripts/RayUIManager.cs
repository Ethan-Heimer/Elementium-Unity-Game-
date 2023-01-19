using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RayUIManager : MonoBehaviour
{
    [SerializeField] EventSystem rayEventSystem;
    [SerializeField] GameObject rayUIElement;
    [SerializeField] Transform uiParent;

    List<GameObject> uiElements = new List<GameObject>();
    GameObject selectedElement;

    ElementRayData[] rays = new ElementRayData[0]; 

    void Awake()
    {
        rayEventSystem.SubscribeToEvent("On Ray Init", InitUI);
        rayEventSystem.SubscribeToEvent("On Ray Changed", OnSelected);
        rayEventSystem.SubscribeToEvent("On Ray List Changed", UpdateUI);
    }

    private void OnDisable()
    {
        rayEventSystem.UnsubscribeToEvent("On Ray Init", InitUI);
        rayEventSystem.UnsubscribeToEvent("On Ray Changed", OnSelected);
        rayEventSystem.UnsubscribeToEvent("On Ray List Changed", UpdateUI);
    }

    public void InitUI(EventData data)
    {
        UpdateUI(data);
        SelectUI(0);
    }

    void UpdateUI(EventData data)
    {
        ElementRayData[] newRays = (ElementRayData[])data.GetData("Selectable Rays");

        foreach (ElementRayData o in newRays)
        {
            if (!rays.Contains(o))
            {
                GameObject obj = Instantiate(rayUIElement);
                obj.transform.SetParent(uiParent);

                obj.GetComponent<Image>().sprite = o.icon;

                UiManager.UnhighlightElement(obj);
                uiElements.Add(obj);
            }
        }

        rays = newRays;
      
    }

    void OnSelected(EventData data) => SelectUI((int)data.GetData("Id Selected"));

    void SelectUI(int id)
    {
        if (selectedElement is not null) UiManager.UnhighlightElement(selectedElement);
        selectedElement = uiElements[id];
        UiManager.HighlightElement(selectedElement); 
    }
}

