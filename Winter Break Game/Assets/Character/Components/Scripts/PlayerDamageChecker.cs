using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Checker", menuName = "Character Components/Damage Checkers/Player Damage Checker")]
public class PlayerDamageChecker : CharacterDamageChecker
{
    public override bool CheckDamage(Character character)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(character.transform.position, .5f); 

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
