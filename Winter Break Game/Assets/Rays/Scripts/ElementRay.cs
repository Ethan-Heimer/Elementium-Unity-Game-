using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ElementRay : MonoBehaviour
{
    public static event Action OnRayFired;
    [SerializeField] UnityEvent OnRayShot; 

    IElementRayRenderer renderer;
    public IElementRayInputProvider input;
    IElementRayDataProvider data;
    IRayProvider raycast;
    IElementRayRayChecker checker;

    ElementRayData rayData;
    RaycastHit2D ray;
    Vector2 aimVector;
    float distance;
    private void Awake()
    {
        renderer = GetComponent<IElementRayRenderer>();
        input = GetComponent<IElementRayInputProvider>();
        data = GetComponent<IElementRayDataProvider>();
        raycast = GetComponent<IRayProvider>();
        checker = GetComponent<IElementRayRayChecker>();
    }

    bool rayIsFireing; 
    public void FireRay()
    {
        rayIsFireing = true;

        rayData = data.GetRayData();

        ray = raycast.GetRaycast(input.GetAimVector());
        aimVector = input.GetAimVector();

        distance = ray.distance != 0 ? ray.distance : raycast.GetRayMaxDistance();

        renderer.RenderRay(rayData, distance, aimVector);
        checker.CheckRay(ray, rayData);
    }
    private void LateUpdate()
    {
        if (rayIsFireing)
        {
            OnRayFired?.Invoke();
            OnRayShot?.Invoke();
        }
        else
        {
            renderer.DisableRay(distance, aimVector);
        }

        rayIsFireing = false;
    }
}
