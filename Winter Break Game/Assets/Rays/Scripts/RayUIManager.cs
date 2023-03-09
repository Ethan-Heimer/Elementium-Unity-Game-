using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class RayUIManager : MonoBehaviour
{
    [SerializeField] GameObject rayUIElement;
    [SerializeField] Transform uiParent;

    List<GameObject> uiElements = new List<GameObject>();
    GameObject selectedElement;

    ElementRayData[] rays = new ElementRayData[0]; 

    void Awake()
    {
        ElementRayManager.OnElementRayInit += InitUI;
        ElementRayManager.OnElementRaySelected += SelectUI;
        ElementRayManager.OnUsableRayListChanged += UpdateUI; 
    }

    private void OnDisable()
    {
        ElementRayManager.OnElementRayInit -= InitUI;
        ElementRayManager.OnElementRaySelected -= SelectUI;
        ElementRayManager.OnUsableRayListChanged -= UpdateUI;
    }

    public void InitUI(ElementRayData[] data)
    {
        UpdateUI(data);
        SelectUI(rays[0]);
    }

    void UpdateUI(ElementRayData[] data)
    {
        ElementRayData[] newRays = data;

        foreach (ElementRayData o in newRays)
        {
            if (!rays.Contains(o))
            {
                CreateNewUI(o);
            }
        }

        rays = newRays;
      
    }

    void SelectUI(ElementRayData selectedRay)
    {
        if (selectedElement is not null) UiManager.UnhighlightElement(selectedElement);

        selectedElement = uiElements[Array.FindIndex(rays, x => x == selectedRay)];
        UiManager.HighlightElement(selectedElement); 
    }

    void CreateNewUI(ElementRayData o)
    {
        GameObject obj = Instantiate(rayUIElement);
        obj.transform.SetParent(uiParent);

        obj.GetComponent<Image>().sprite = o.icon;

        UiManager.UnhighlightElement(obj);
        uiElements.Add(obj);
    }
}

