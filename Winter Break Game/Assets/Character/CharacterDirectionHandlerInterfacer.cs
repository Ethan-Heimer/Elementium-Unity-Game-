using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDirectionHandlerInterfacer : CharacterComponentInterfacer<CharacterDirectionHandler>
{
    SpriteRenderer renderer; 
    public CharacterDirectionHandlerInterfacer(Character character, CharacterConfigManager config) : base(character, config) 
    {
        renderer = character.GetComponent<SpriteRenderer>();
    }

    public void FlipCharacter(float direction) => Component.FlipCharacter(character, renderer, direction);
    public int GetCurrentDirection() => Component.GetCurrentDirection(character, renderer);
}
