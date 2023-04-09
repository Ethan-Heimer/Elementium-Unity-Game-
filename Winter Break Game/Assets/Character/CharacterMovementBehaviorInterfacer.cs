using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementBehaviorInterfacer : CharacterComponentInterfacer<CharacterMovementHandler>
{
    public CharacterMovementBehaviorInterfacer(Character character, CharacterConfigManager config) : base(character, config) { }

    public void OnUpdate() => Component.OnUpdate(character);
    public void OnFixedUpdate() => Component.OnFixedUpdate(character);
}
