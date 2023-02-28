using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks; 

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
            character.eventManager.OnDamaged.Invoke();
            character.damageHandler.OnDamaged(); 
        }
    }

    public async void KillCharacter()
    {
        GameObject.Destroy(character.GetComponent<SpriteRenderer>());
        GameObject.Destroy(character.GetComponent<Rigidbody2D>());
        GameObject.Destroy(character.GetComponent<Collider2D>());

        character.PauseExecution(true);
        character.eventManager.OnDeath.Invoke();

        for (int i = character.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(character.transform.GetChild(i).gameObject);
        }

        await Task.Delay(2000);

        GameObject.Destroy(character.gameObject);
    }
}
