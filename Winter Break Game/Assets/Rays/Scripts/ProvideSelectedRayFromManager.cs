using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvideSelectedRayFromManager : MonoBehaviour, IElementRayDataProvider
{
    ElementRayData selectedRay;
    public void Awake()
    {
        ElementRayManager.OnElementRaySelected += SetRay;
    }
    public void OnDisable()
    {
        ElementRayManager.OnElementRaySelected -= SetRay;
    }
    public void SetRay(ElementRayData data) => selectedRay = data; 

    public ElementRayData GetRayData() => selectedRay;

    public void SetRayData(ElementRayData data) => selectedRay = data; 
}
