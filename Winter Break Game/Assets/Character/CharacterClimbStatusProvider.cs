using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterClimbStatusProvider : ICharacterClimbStatusProvider
{
    Transform transform;
    public void Constructer(Character character)
    {
        transform = character.transform;
    }
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

    public object Clone() => MemberwiseClone(); 
}
