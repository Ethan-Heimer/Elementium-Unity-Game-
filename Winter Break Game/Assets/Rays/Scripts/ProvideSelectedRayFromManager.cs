using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvideSelectedRayFromManager : MonoBehaviour, IElementRayDataProvider
{
    [SerializeField] EventSystem rayEvent;
    ElementRayData selectedRay;
    public void Awake()
    {
        rayEvent.SubscribeToEvent("On Ray Changed", SetRay);
    }
    public void SetRay(EventData edata) => selectedRay = (ElementRayData)edata.GetData("Ray Selected"); 

    public ElementRayData GetRayData() => selectedRay;

    public void SetRayData(ElementRayData data) => selectedRay = data; 
}
