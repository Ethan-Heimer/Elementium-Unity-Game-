using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageChecker : CharacterClass, ICharacterDamageChecker
{
    Transform transform;
    public override void Constructer(Character character) 
    {
        base.Constructer(character);
        transform = character.transform; 
    }

    public bool CheckDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .5f); 

        foreach(Collider2D o in colliders)
        {
            if (o.CompareTag("Killable"))
            {
                return true; 
            }
        }

        return false;
    }
}
