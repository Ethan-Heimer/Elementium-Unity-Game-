using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Damage Checker", menuName = "Character Components/Damage Checkers/Check For Ray")]
public class CheckForRay : CharacterDamageChecker
{
    IRayDamageReciever damageReciever;
    public override bool CheckDamage(Character character)
    {
        if(damageReciever is null) damageReciever = character.GetComponent<IRayDamageReciever>();
        return damageReciever.IsCorrectRayTouching(); 
    }
}
