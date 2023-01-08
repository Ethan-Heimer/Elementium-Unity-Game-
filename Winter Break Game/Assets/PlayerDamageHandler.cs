using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour, ICharacherDamageHandler
{
    [SerializeField] CheckPointData checkPointData;
    ICharacterEventHandler eventHandler; 

    Vector2 startingPos;
    Vector2 checkPointPos
    {
        get
        {
            if (checkPointData.GetCurrentCheckpoint() is null)
            {
                return startingPos;
            }

            return checkPointData.GetCurrentCheckpointPosition(); 
        }
    }
    void Start()
    {
        startingPos = transform.position;
        eventHandler = GetComponent<ICharacterEventHandler>();
    }

    public void OnDamaged()
    {
        transform.position = checkPointPos;
        eventHandler.InvokeEvent("OnPlayerDie");
    }
}
