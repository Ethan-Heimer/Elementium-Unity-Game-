using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class ElementRayManager : MonoBehaviour
{
    public ElementRayData selectedRay;
    [SerializeField] List<ElementRayData> selectableRays = new List<ElementRayData>();
    [SerializeField] EventSystem rayEventSystem;

    int selectedID;
    
    void Start()
    {
        rayEventSystem.SubscribeToEvent("On Ray Collected", AddElement);

        Debug.Log(selectableRays.Count);
        rayEventSystem.InvokeEvent("On Ray Init", new EventData(new EventInfo("Selectable Rays", selectableRays.ToArray())));
        SelectRay(0);
    }

    private void OnDestroy()
    {
        rayEventSystem.UnsubscribeToEvent("On Ray Collected", AddElement); 
    }

    void Update()
    {
        if (Input.GetButtonDown("SelectLeft"))
        {
            SelectRay(selectedID-1);
        }
        else if (Input.GetButtonDown("SelectRight"))
        {
            SelectRay(selectedID+1);
        }
    }

    void SelectRay(int id)
    {
        int _id = id; 

        if(_id > selectableRays.Count - 1)
        {
            _id = 0; 
        }
        else if(_id < 0)
        {
            _id = selectableRays.Count - 1;
        }

        selectedID = _id; 
        selectedRay = selectableRays[selectedID];
        rayEventSystem.InvokeEvent("On Ray Changed", new EventData(new EventInfo("Ray Selected", selectedRay), new EventInfo("Id Selected", selectedID)));
    }

    void AddElement(EventData data)
    {
        ElementRayData ray = (ElementRayData)data.GetData("Ray"); 

        selectableRays.Add(ray);
        rayEventSystem.InvokeEvent("On Ray List Changed", new EventData(new EventInfo("Selectable Rays", selectableRays.ToArray())));

        SelectRay(selectableRays.Count - 1);
    }
}
