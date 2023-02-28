using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class ElementRayRaycastChecker : MonoBehaviour, IElementRayRayChecker
{
    public void CheckRay(RaycastHit2D ray, ElementRayData data)
    {
        if (ray.collider == null) return;

        Debug.Log(ray.collider.name);
        RayAffectable obj = ray.collider.GetComponent<RayAffectable>();
        if (obj is null) return;

        obj.CheckForHit(data.ElementSToInteractWith.ToArray(), ray.point); 
    }
}
