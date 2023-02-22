using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVolume : MonoBehaviour
{
    [SerializeField] CameraState stateWhenInVolume;
    [SerializeField] EventSystem cameraEventSystem;

    bool startingVolume = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        switch (stateWhenInVolume)
        {
            case CameraState.Follow:
                cameraEventSystem.InvokeEvent("On Volume Entered", new EventData(new EventInfo("Target", collision.transform), new EventInfo("Camera State", stateWhenInVolume))); 
                break;

            case CameraState.Stationary:
                cameraEventSystem.InvokeEvent("On Volume Entered", new EventData(new EventInfo("Target", transform), new EventInfo("Camera State", stateWhenInVolume)));
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale); 
    }
}
