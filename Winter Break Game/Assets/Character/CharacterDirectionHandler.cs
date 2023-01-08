using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDirectionHandler : MonoBehaviour, ICharacterDirectionHandler
{
    [SerializeField] SpriteRenderer renderer;
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
