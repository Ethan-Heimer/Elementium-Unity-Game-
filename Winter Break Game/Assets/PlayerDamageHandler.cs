using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler :  ICharacterDamageHandler
{
    public CheckPointData checkPointData;
    ICharacterEventHandler eventHandler;
    Transform transform; 
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
    public void Constructer(Character character) 
    {
        transform = character.transform;

        startingPos = transform.position;
        eventHandler = character.movement.eventHandler; 
    }

    public void OnDamaged()
    {
        transform.position = checkPointPos;
        eventHandler.InvokeEvent("OnPlayerDie");
    }

    
    public object Clone() =>  MemberwiseClone();
}
