using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CameraVolume : MonoBehaviour
{
    public static event Action<Transform, int, CameraState> OnVolumeChanged;

    [SerializeField] CameraState stateWhenInVolume;
    [SerializeField] int Fov;

    public UnityEvent OnVolumeEntered;
    public UnityEvent OnVolumeExit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != Character.GetPlayer().gameObject) return;

        OnVolumeEntered?.Invoke();
        switch (stateWhenInVolume)
        {
            case CameraState.Follow:
                OnVolumeChanged.Invoke(collision.transform, Fov, stateWhenInVolume);
                break;

            case CameraState.Stationary:
                OnVolumeChanged.Invoke(transform, Fov, stateWhenInVolume);
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != Character.GetPlayer().gameObject) return;
        OnVolumeExit?.Invoke();
    }

   
}
