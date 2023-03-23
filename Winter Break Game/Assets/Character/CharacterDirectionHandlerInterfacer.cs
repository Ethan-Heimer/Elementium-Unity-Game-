using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDirectionHandlerInterfacer : CharacterComponentInterfacer<CharacterDirectionHandler>
{
    SpriteRenderer renderer; 
    public CharacterDirectionHandlerInterfacer(Character character, CharacterConfig config) : base(character, config) 
    {
        renderer = character.GetComponent<SpriteRenderer>();
    }

    public void FlipCharacter(float direction) => GetCharacterComponent().FlipCharacter(character, renderer, direction);
    public int GetCurrentDirection() => GetCharacterComponent().GetCurrentDirection(character, renderer);
}
