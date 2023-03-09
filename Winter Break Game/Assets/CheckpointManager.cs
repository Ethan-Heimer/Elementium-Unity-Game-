using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static GameObject currentCheckpoint
    {
        get;
        private set;
    }

    public void Start()
    {
        Checkpoint.OnCheckPointCollected += UpdateCheckpoint; 
    }

    void UpdateCheckpoint(GameObject checkPoint) => currentCheckpoint = checkPoint; 
}
