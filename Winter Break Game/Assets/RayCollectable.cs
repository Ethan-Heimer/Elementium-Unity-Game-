using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCollectable : MonoBehaviour
{
    [SerializeField] ElementRayData ray;
    [SerializeField] EventSystem rayEventSystem; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rayEventSystem.InvokeEvent("On Ray Collected", new EventData(new EventInfo("Ray", ray)));

            Destroy(gameObject);

            UiManager.UiPopup(ray.icon, "New Element!", "New Element Unlocked: " + ray.name); 
        }
    }
}
