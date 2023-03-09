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
        waterTwin.eventManager.OnDeath.AddListener(() => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));    
        fireTwin.eventManager.OnDeath.AddListener(() => RayCollectable.CreateCollectableObject(rayCollectable, fireTwinDrop, fireTwin.transform.position));    
    }

    public void OnDisable()
    {
        waterTwin?.eventManager.OnDeath.RemoveListener(() => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));
        fireTwin?.eventManager.OnDeath.RemoveListener(() => RayCollectable.CreateCollectableObject(rayCollectable, fireTwinDrop, fireTwin.transform.position));
    }
}
