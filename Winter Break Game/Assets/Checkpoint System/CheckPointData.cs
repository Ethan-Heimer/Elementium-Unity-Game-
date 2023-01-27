using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CheckPointData : ScriptableObject
{
    GameObject currentCheckPoint;

    public GameObject GetCurrentCheckpoint() => currentCheckPoint;
    public Vector3 GetCurrentCheckpointPosition() => currentCheckPoint is not null ? currentCheckPoint.transform.position : Vector3.zero;

    public void SetCurrentCheckpoint(GameObject checkpoint) => currentCheckPoint = checkpoint; 

}
