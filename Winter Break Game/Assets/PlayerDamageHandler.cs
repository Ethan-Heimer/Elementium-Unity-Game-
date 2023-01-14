using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : CharacterClass, ICharacterDamageHandler
{
    public CheckPointData checkPointData;
  
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
    public override void Constructer(Character _character) 
    {
        base.Constructer(_character);

        transform = character.transform;

        startingPos = transform.position;
    }

    public void OnDamaged()
    {
        transform.position = checkPointPos;
        character.eventManager.InvokeEvent("OnPlayerDie");
    }
}
