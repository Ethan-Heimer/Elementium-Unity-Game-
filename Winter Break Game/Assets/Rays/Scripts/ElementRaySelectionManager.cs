using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ElementRaySelectionManager : MonoBehaviour
{
    public static event Action<ElementRayData> OnElementRaySelected;

    ElementRayData selectedRay;

    IElementRayManagerInputProvider inputHandler = new ElementRayManagerInputHandler();

    int _selecedId; 
    int selectedID
    {
        get { return _selecedId; }
        set
        {
            int id = value;
            if (id > ElementRayCollectionsManager.SelectableElementRays.Length - 1)
            {
                id = 0;
            }
            else if (id < 0)
            {
                id = ElementRayCollectionsManager.SelectableElementRays.Length - 1;
            }

            _selecedId = id;
            SelectRay(id);
        }
    }
    
    void Start()
    {
        SelectRay(0);
    }

    void Update()
    {
        int input = inputHandler.GetInput();
        if(input != 0)
        {
            selectedID += input;
        }
    }

    void SelectRay(int id)
    {
        selectedRay = ElementRayCollectionsManager.SelectableElementRays[id];
        OnElementRaySelected?.Invoke(selectedRay);
    }
}
