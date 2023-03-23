using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Direction Status Provider", menuName = "Character Components/Direction Handlers/Standard Direction Handler")]
public class StandardCharacterDirectionHandler : CharacterDirectionHandler
{
    [SerializeField] float flipThreshhold; 

    public override void FlipCharacter(Character character, SpriteRenderer renderer, float direction)
    {
        if(direction > flipThreshhold)
        {
            renderer.flipX = false;
        }
        else if (direction < -flipThreshhold)
        {
            renderer.flipX = true;
        }

    }

    public override int GetCurrentDirection(Character character, SpriteRenderer renderer) => renderer && renderer.flipX?-1:1;
}
