using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class PlayerDamageHandler : CharacterClass, ICharacterDamageHandler
{
    public override void Constructer(Character _character) 
    {
        base.Constructer(_character);

        character.damageManager.OnDeath += () => SceneSwicher.SwitchScene(SceneManager.GetActiveScene().buildIndex);
    }

    public async void OnDamaged()
    {
        character.DisableCharacter(true, true);
        character.statsHandler.SubtractStatValue("Hearts", 1);

        await Task.Delay(500);

        character.DisableCharacter(false);
        character.transform.position = CheckpointManager.currentCheckpoint != null ? CheckpointManager.currentCheckpoint.transform.position : character.transform.position; 

        if (character.statsHandler.GetStat("Hearts") <= 0)
        {
            character.damageManager.SilentlyKillCharacter();
            return;
        }
    }

  
}
