using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRayChecker 
{
    void CheckRay(RaycastHit2D ray); 
}

public interface IElementRayRayChecker
{
    void CheckRay(RaycastHit2D ray, ElementRayData data);
}
