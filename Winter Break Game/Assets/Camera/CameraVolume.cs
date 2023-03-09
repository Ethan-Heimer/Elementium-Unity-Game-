using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CameraVolume : MonoBehaviour
{
    public static event Action<Transform, CameraState> OnVolumeChanged; 

    [SerializeField] CameraState stateWhenInVolume;

    [SerializeField] UnityEvent OnVolumeEntered;
    [SerializeField] UnityEvent OnVolumeExit; 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != Character.GetPlayer().gameObject) return;

        OnVolumeEntered?.Invoke();
        switch (stateWhenInVolume)
        {
            case CameraState.Follow:
                OnVolumeChanged.Invoke(collision.transform, stateWhenInVolume); 
                break;

            case CameraState.Stationary:
                OnVolumeChanged.Invoke(transform, stateWhenInVolume); 
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
