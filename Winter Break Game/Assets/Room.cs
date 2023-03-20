using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraVolume))]
public class Room : MonoBehaviour
{
    CameraVolume volume;

    public void Start()
    {
        volume = GetComponent<CameraVolume>();

        volume.OnVolumeEntered.AddListener(() => ToggleRoom(true));
        volume.OnVolumeExit.AddListener(() => ToggleRoom(false));

        ToggleRoom(false);
    }

    public void ToggleRoom(bool value)
    {
        foreach (Transform o in transform) if(!o.CompareTag("Stay On Disable")) o.gameObject.SetActive(value);
    }
}
