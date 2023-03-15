using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class CharacterDamageManager
{
    public event Action OnDamaged;
    public event Action OnDeath;

    CharacterConfig config;
    Character character; 


    public CharacterDamageManager(Character _character)
    {
        character = _character;
        config = character.config; 
    }

    bool damaged;
    public void Tick()
    {
        damaged = character.damageChecker.CheckDamage();

        if (damaged)
        {
            character.damageHandler.OnDamaged();
            OnDamaged?.Invoke();
           
        }
    }

    public async void KillCharacter()
    {
        character.DisableCharacter(true);

        character.PauseExecution(true);
        OnDeath?.Invoke();

        await Task.Delay(2000);

        GameObject.Destroy(character.gameObject);
    }

    public void SilentlyKillCharacter()
    {
        character.DisableCharacter(true);

        character.PauseExecution(true);
        OnDeath?.Invoke();
    }
}
