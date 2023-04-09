using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputInterfacer : CharacterComponentInterfacer<CharacterInputHandler>
{
    public CharacterInputInterfacer(Character character, CharacterConfigManager characterConfig) : base(character, characterConfig) { }
   
    public float GetHorizontalInput() => Component.GetHorizontalInput(character);
    public float GetVerticalInput() => Component.GetVerticalInput(character);
    public bool GetJumpInput() => Component.GetJumpInput(character);
    public bool GetActionInput() => Component.GetActionInput(character);
    public bool GetClimbInput() => Component.GetClimbInput(character);
}
