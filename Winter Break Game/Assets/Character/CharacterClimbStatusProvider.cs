using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterClimbStatusProvider : ClimbStatusProvider
{
    Transform transform;
    public override void Constructer(Character character)
    {
        base.Constructer(character);
        transform = character.transform;
    }
    public override bool CanClimb()
    {
        if (!climbCooldown.IsTimerUp()) return false;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * .2f, 0f, Vector2.one, 0f, LayerMask.GetMask("Enviorment"));

        if (hit.collider is null) return false; 

        if (hit.collider.CompareTag("Climable"))
        {
            return true; 
        }

        return false; 
    }
}
