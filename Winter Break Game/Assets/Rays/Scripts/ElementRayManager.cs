using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ElementRayManager : MonoBehaviour
{
    public static event Action<ElementRayData[]> OnElementRayInit;
    public static event Action<ElementRayData> OnElementRaySelected;
    public static event Action<ElementRayData[]> OnUsableRayListChanged;

    public ElementRayData selectedRay;
    [SerializeField] List<ElementRayData> selectableRays = new List<ElementRayData>();

    int selectedID;
    
    void Start()
    {
        RayCollectable.OnRayCollected += AddElement;

        OnElementRayInit?.Invoke(selectableRays.ToArray()); 

        SelectRay(0);
    }

    private void OnDestroy()
    {
        RayCollectable.OnRayCollected -= AddElement;
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
       
        OnElementRaySelected?.Invoke(selectedRay);
    }

    void AddElement(ElementRayData data)
    {
        ElementRayData ray = data;

        selectableRays.Add(ray);
       
        OnUsableRayListChanged?.Invoke(selectableRays.ToArray()); 

        SelectRay(selectableRays.Count - 1);
    }
}
