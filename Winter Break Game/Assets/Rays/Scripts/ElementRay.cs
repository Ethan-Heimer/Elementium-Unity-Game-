using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRay : MonoBehaviour
{
    [SerializeField] EventSystem rayEventSystem;

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
    private void Update()
    {
        rayData = data.GetRayData(); 

        ray = raycast.GetRaycast(input.GetAimVector());
        aimVector = input.GetAimVector();

        distance = ray.distance != 0 ? ray.distance : raycast.GetRayMaxDistance();

        if (input.ShootRayIsPressed())
        {
            renderer.RenderRay(rayData, distance, aimVector);
            checker.CheckRay(ray, rayData);

            rayEventSystem.FlagEvent("While Ray Shot", null); 
        }
        else
        {
            renderer.DisableRay(distance, aimVector);

            rayEventSystem.UnflagEvent("While Ray Shot");
        }
    }
}
