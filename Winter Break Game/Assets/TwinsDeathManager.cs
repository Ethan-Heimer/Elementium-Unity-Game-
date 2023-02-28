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
        waterTwin.eventManager.OnDeath.AddListener(() => ElemiteManager.CreateElemiteObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));    
        fireTwin.eventManager.OnDeath.AddListener(() => ElemiteManager.CreateElemiteObject(rayCollectable, fireTwinDrop, fireTwin.transform.position));    
    }

    public void OnDisable()
    {
        waterTwin?.eventManager.OnDeath.RemoveListener(() => ElemiteManager.CreateElemiteObject(rayCollectable, waterTwinDrop, waterTwin.transform.position));
        fireTwin?.eventManager.OnDeath.RemoveListener(() => ElemiteManager.CreateElemiteObject(rayCollectable, fireTwinDrop, fireTwin.transform.position));
    }
}
