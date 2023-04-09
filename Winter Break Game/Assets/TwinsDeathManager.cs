using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinsDeathManager : MonoBehaviour
{
    [SerializeField] Character waterTwin;
    [SerializeField] Character fireTwin;

    [SerializeField] RayCollectable rayCollectable;

    [SerializeField] ElementRayData waterTwinDrop;
    [SerializeField] ElementRayData fireTwinDrop;
    

    public void Start()
    {
        waterTwin.eventManager.AddEventListener("OnDeath", () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));
        fireTwin.eventManager.AddEventListener("OnDeath", () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));
    }

    public void OnDisable()
    {
        waterTwin.eventManager.RemoveEventListener("OnDeath", () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));
        fireTwin.eventManager.RemoveEventListener("OnDeath", () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));
    }
}
