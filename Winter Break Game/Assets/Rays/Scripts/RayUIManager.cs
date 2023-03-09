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

    void Start()
    {
        ElementRayCollectionsManager.OnUsableRayListChanged += UpdateUI;
        ElementRaySelectionManager.OnElementRaySelected += SelectUI;

        InitUI();
       
    }

    private void OnDisable()
    {
        ElementRayCollectionsManager.OnUsableRayListChanged -= UpdateUI;
        ElementRaySelectionManager.OnElementRaySelected -= SelectUI;
    }

    public void InitUI()
    {
        UpdateUI();
        SelectUI(rays[0]);
    }

    void UpdateUI()
    {
        foreach (ElementRayData o in ElementRayCollectionsManager.SelectableElementRays)
        {
            if (!rays.Contains(o))
            {
                CreateNewUI(o);
            }
        }

        rays = ElementRayCollectionsManager.SelectableElementRays;
      
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

