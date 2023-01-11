using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDirectionHandler : ICharacterDirectionHandler
{
    [SerializeField] SpriteRenderer renderer;
    public void Constructer(Character character)
    {
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

    public object Clone() => MemberwiseClone(); 
}
