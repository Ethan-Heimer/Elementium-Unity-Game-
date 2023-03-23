using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Climb Status Provider", menuName = "Character Components/Climb Status Providers/Basic Climb Status Provder")]
public class CharacterClimbStatusProvider : ClimbStatusProvider
{
    public override bool CheckForClimb(Character character)
    {
        RaycastHit2D hit = Physics2D.BoxCast(character.transform.position, Vector2.one * .2f, 0f, Vector2.one, 0f, LayerMask.GetMask("Climable"));

        if (hit.collider is null) return false; 

        return true; 
    }
}