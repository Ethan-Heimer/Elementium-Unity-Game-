using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageManager
{
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
        }
    }
}
