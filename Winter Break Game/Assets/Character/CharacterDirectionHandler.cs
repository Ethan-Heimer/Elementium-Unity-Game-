using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDirectionHandler : CharacterClass, ICharacterDirectionHandler
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] float flipThreshhold; 
    public override void Constructer(Character character)
    {
        base.Constructer(character);
        renderer = character.GetComponent<SpriteRenderer>();
    }

    public void FlipCharacter(float direction)
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

    public int GetCurrentDirection() => renderer && renderer.flipX?-1:1;
}
