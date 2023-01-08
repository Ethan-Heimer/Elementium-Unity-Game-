using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDataProvider : MonoBehaviour, IElementRayDataProvider
{
    [SerializeField] ElementRayData rayData;
    public ElementRayData GetRayData() => rayData;
    public void SetRayData(ElementRayData data) => rayData = data; 

}
