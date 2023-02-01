using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageManager
{
    CharacterConfig config;
    Character character; 

    ICharacterDamageChecker damageChecker;
    ICharacterDamageHandler damageHandler;

    public CharacterDamageManager(Character _character)
    {
        character = _character;
        config = character.config; 
    }

    public void SetUp()
    {
        damageChecker = config.GetDamageChecker();
        damageHandler = config.GetDamageHandler();

        damageChecker.Constructer(character);
        damageHandler.Constructer(character); 
    }

    bool damaged;
    public void Tick()
    {
        damaged = damageChecker.CheckDamage();

        if (damaged)
        {
            damageHandler.OnDamaged(); 
        }
    }
}
