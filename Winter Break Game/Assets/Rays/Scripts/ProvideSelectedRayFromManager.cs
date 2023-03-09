using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvideSelectedRayFromManager : MonoBehaviour, IElementRayDataProvider
{
    ElementRayData selectedRay;
    public void Awake()
    {
        ElementRaySelectionManager.OnElementRaySelected += SetRay;
    }
    public void OnDisable()
    {
        ElementRaySelectionManager.OnElementRaySelected -= SetRay;
    }
    public void SetRay(ElementRayData data) => selectedRay = data; 

    public ElementRayData GetRayData() => selectedRay;

    public void SetRayData(ElementRayData data) => selectedRay = data; 
}
