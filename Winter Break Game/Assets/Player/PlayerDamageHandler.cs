using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Damage Handler", menuName = "Character Components/Damage Handlers/Player Damage Handler")]
public class PlayerDamageHandler : CharacterDamageHandler
{
    public float StartingHeartsAmount=3;
    float hearts;

    bool initHearts;
    public override async void OnDamaged(Character character)
    {
        if (!initHearts)
        {
            hearts = StartingHeartsAmount;
            initHearts = true;
        }
           
        character.DisableCharacter(true);
        hearts--;

        await Task.Delay(500);

        character.DisableCharacter(false);
        character.transform.position = CheckpointManager.currentCheckpoint != null ? CheckpointManager.currentCheckpoint.transform.position : character.transform.position; 

        if (hearts <= 0)
        {
            character.damageManager.SilentlyKillCharacter();
            SceneSwicher.SwitchScene(SceneManager.GetActiveScene().buildIndex);
            initHearts = false;
            return;
        }
    }

  
}
