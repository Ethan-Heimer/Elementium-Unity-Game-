using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        character.eventManager.OnDeath.AddListener(() => SceneSwicher.SwitchScene(SceneManager.GetActiveScene().buildIndex)); 
    }

    public void OnDamaged()
    {
        transform.position = checkPointPos;
        character.statsHandler.SubtractStatValue("Hearts", 1);
        character.eventManager.OnDamaged.Invoke();

        if(character.statsHandler.GetStat("Hearts") <= 0)
        {
            character.damageManager.SilentlyKillCharacter();
        }
    }
}
