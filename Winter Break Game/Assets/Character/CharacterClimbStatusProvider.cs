using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClimbStatusProvider : MonoBehaviour, ICharacterClimbStatusProvider
{
    public bool CanClimb()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * .2f, 0f, Vector2.one, 0f, LayerMask.GetMask("Enviorment"));

        if (hit.collider is null) return false; 

        if (hit.collider.CompareTag("Climable"))
        {
            return true; 
        }

        return false; 
    }
}
