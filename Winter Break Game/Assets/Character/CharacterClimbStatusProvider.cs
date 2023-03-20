using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterClimbStatusProvider : ClimbStatusProvider
{
    public override void Constructer(Character character)
    {
        base.Constructer(character);
    }
    protected override bool CheckForClimb()
    {
        if (!climbCooldown.IsTimerUp()) return false;

        RaycastHit2D hit = Physics2D.BoxCast(character.transform.position, Vector2.one * .2f, 0f, Vector2.one, 0f, LayerMask.GetMask("Climable"));

        if (hit.collider is null) return false; 

        return true; 
    }
}
