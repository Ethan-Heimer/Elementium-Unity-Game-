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
        IElementRayInteractable obj = ray.collider.GetComponent<IElementRayInteractable>();
        if (obj is null) return; 

        foreach (string o in data.InterfacesToInvoke)
        {
            if(obj.GetType().GetInterface(o) is not null)
            {
                obj.OnHit(ray.point);
            }
        }
    }
}
