using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionBehaviorInterfacer : CharacterComponentInterfacer<CharacterActionHandler>
{
    public CharacterActionBehaviorInterfacer(Character character, CharacterConfig config) : base(character, config) { }
    public void OnAction() => GetCharacterComponent().OnAction(character);

}
