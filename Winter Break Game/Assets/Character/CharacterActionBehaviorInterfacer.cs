using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionBehaviorInterfacer : CharacterComponentInterfacer<CharacterActionHandler>
{
    public CharacterActionBehaviorInterfacer(Character character, CharacterConfigManager config) : base(character, config) { }
    public void OnAction() => Component.OnAction(character);

}
