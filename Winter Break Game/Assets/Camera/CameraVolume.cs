using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class CameraVolume : MonoBehaviour
{
    [SerializeField] CameraState stateWhenInVolume;
    [SerializeField] EventSystem cameraEventSystem;

    [SerializeField] UnityEvent OnVolumeEntered;
    [SerializeField] UnityEvent OnVolumeExit; 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != Character.GetPlayer().gameObject) return;

        OnVolumeEntered?.Invoke();
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

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != Character.GetPlayer().gameObject) return;
        OnVolumeExit?.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale); 
    }
}
