using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class RayCollectable : MonoBehaviour
{
    public static event Action<ElementRayData> OnRayCollected;
    public ElementRayData rayData;
    [SerializeField] UnityEvent OnCollected;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Character.GetPlayer().gameObject) 
        {
            OnRayCollected?.Invoke(rayData);
            OnCollected?.Invoke();

            Destroy(gameObject);

            UiManager.UiPopup(rayData.icon, "New Element!", "New Element Unlocked: " + rayData.name); 
        }
    }

    public static void CreateCollectableObject(RayCollectable elemite, ElementRayData rayData, Vector3 position)
    {
        var obj = Instantiate(elemite.gameObject);
        obj.transform.position = position;
        obj.GetComponent<RayCollectable>().rayData = rayData;
    }
}
