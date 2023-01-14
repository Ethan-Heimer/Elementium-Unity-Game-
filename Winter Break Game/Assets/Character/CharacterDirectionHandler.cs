using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDirectionHandler : CharacterClass, ICharacterDirectionHandler
{
    [SerializeField] SpriteRenderer renderer;
    public override void Constructer(Character character)
    {
        base.Constructer(character);
        renderer = character.GetComponent<SpriteRenderer>();
    }

    public void FlipCharacter(int direction)
    {
        switch(direction)
        {
            case 1:
                renderer.flipX = false; 
                break;

            case -1:
                renderer.flipX = true;
                break;
        }
    }

    public int GetCurrentDirection() => renderer.flipX?-1:1;
}
