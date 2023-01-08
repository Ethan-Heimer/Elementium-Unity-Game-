using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElementRayDataProvider 
{
    ElementRayData GetRayData();
    void SetRayData(ElementRayData data); 
}
