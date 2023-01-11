using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageChecker : ICharacterDamageChecker
{
    Transform transform;
    public void Constructer(Character character) 
    {
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

  
    public object Clone() => MemberwiseClone(); 
}
