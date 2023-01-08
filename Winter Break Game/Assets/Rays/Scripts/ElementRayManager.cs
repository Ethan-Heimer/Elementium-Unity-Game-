using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRayManager : MonoBehaviour
{
    public ElementRayData selectedRay;
    [SerializeField] ElementRayData[] selectableRays;
    [SerializeField] GameObject ray;
    [SerializeField] EventSystem rayEventSystem;
   
    int _selectedID;
    int selectedID
    {
        get
        {
            return _selectedID; 
        }

        set
        {
            if(value > selectableRays.Length - 1)
            {
                _selectedID = 0;
            }
            else if(value < 0)
            {
                _selectedID = selectableRays.Length - 1;
            }
            else
            {
                _selectedID = value;
            }
        }
    }

    void Start()
    {
        rayEventSystem.InvokeEvent("On Ray Init", new EventData(new EventInfo("Selectable Rays", selectableRays)));
        UpdateSelection();
    }

    void Update()
    {
        if (Input.GetButtonDown("SelectLeft"))
        {
            selectedID--;
            UpdateSelection();
        }
        else if (Input.GetButtonDown("SelectRight"))
        {
            selectedID++;
            UpdateSelection();
        }
    }

    void UpdateSelection()
    {
        selectedRay = selectableRays[selectedID];
        rayEventSystem.InvokeEvent("On Ray Changed", new EventData(new EventInfo("Ray Selected", selectedRay), new EventInfo("Id Selected", selectedID)));
    }
}
