using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForRay : CharacterClass, ICharacterDamageChecker
{
    IRayDamageReciever damageReciever;

    public override void Constructer(Character _character)
    {
        base.Constructer(_character);
        damageReciever = character.GetComponent<IRayDamageReciever>();

        if (damageReciever is null)
        {
            Debug.LogError("Add A Ray Damage Reciever To Character Gameobject");
        }
    }

    public bool CheckDamage()
    {
        Debug.Log(damageReciever.IsCorrectRayTouching());
        return damageReciever.IsCorrectRayTouching(); 
    }
}
