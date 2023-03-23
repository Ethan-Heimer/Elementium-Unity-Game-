using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class CharacterDamageManager
{
    public event Action OnDamaged;
    public event Action OnDeath;

    Character character;

    CharacterDamageCheckerInterfacer damageChecker;
    CharacterDamageHandlerInterfacer damageHandler;

    public CharacterDamageManager(Character _character, CharacterDamageCheckerInterfacer _damageChecker, CharacterDamageHandlerInterfacer _damageHandler)
    {
        character = _character;

        damageChecker = _damageChecker;
        damageHandler = _damageHandler;
    }

    bool damaged;
    public void Tick()
    {
        damaged = damageChecker.CheckDamage();

        if (damaged)
        {
            damageHandler.OnDamaged();
            OnDamaged?.Invoke();
           
        }
    }

    public async void KillCharacter()
    {
        character.DisableCharacter(true);

        character.PauseExecution(true);
        OnDeath?.Invoke();

        await Task.Delay(500);

        GameObject.Destroy(character.gameObject);
        Debug.Log("Dead");
    }

    public void SilentlyKillCharacter()
    {
        character.DisableCharacter(true);

        character.PauseExecution(true);
        OnDeath?.Invoke();
    }
}
