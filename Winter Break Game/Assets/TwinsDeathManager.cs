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
        waterTwin.damageManager.OnDeath += () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position);
        fireTwin.damageManager.OnDeath += () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position);
    }

    public void OnDisable()
    {
        waterTwin.damageManager.OnDeath -= () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position);
        fireTwin.damageManager.OnDeath -= () => RayCollectable.CreateCollectableObject(rayCollectable, waterTwinDrop, waterTwin.transform.position);
    }
}
