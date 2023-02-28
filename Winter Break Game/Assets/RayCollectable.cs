using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCollectable : MonoBehaviour
{
    public ElementRayData rayData
    {
        private get;
        set;
    }

    [SerializeField] EventSystem rayEventSystem; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rayEventSystem.InvokeEvent("On Ray Collected", new EventData(new EventInfo("Ray", rayData)));

            Destroy(gameObject);

            UiManager.UiPopup(rayData.icon, "New Element!", "New Element Unlocked: " + rayData.name); 
        }
    }
}
