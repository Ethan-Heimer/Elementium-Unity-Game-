using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElementRayCollectionsManager : MonoBehaviour
{
    static List<ElementRayData> _selectableElementRays;
    public static ElementRayData[] SelectableElementRays
    {
        get { return _selectableElementRays.ToArray(); }
    }

    public static event Action OnUsableRayListChanged;
   
    [SerializeField] List<ElementRayData> startingRays = new List<ElementRayData>();
    void Awake()
    {
        RayCollectable.OnRayCollected += AddElement;
        _selectableElementRays = new List<ElementRayData>(startingRays); 
    }

    void AddElement(ElementRayData data)
    {
        ElementRayData ray = data;

        _selectableElementRays.Add(ray);

        OnUsableRayListChanged?.Invoke();
    }
}
