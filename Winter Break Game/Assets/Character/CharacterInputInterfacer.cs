using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputInterfacer : CharacterComponentInterfacer<CharacterInputHandler>
{
    public CharacterInputInterfacer(Character character, CharacterConfig characterConfig) : base(character, characterConfig) { }
   
    public float GetHorizontalInput() => GetCharacterComponent().GetHorizontalInput(character);
    public float GetVerticalInput() => GetCharacterComponent().GetVerticalInput(character);
    public bool GetJumpInput() => GetCharacterComponent().GetJumpInput(character);
    public bool GetActionInput() => GetCharacterComponent().GetActionInput(character);
    public bool GetClimbInput() => GetCharacterComponent().GetClimbInput(character);
}
