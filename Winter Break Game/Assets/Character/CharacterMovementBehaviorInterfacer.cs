using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementBehaviorInterfacer : CharacterComponentInterfacer<CharacterMovementHandler>
{
    public CharacterMovementBehaviorInterfacer(Character character, CharacterConfig config) : base(character, config) { }

    public void Start() => GetCharacterComponent().OnStart(character);
    public void Update() => GetCharacterComponent().OnUpdate(character);
    public void FixedUpdate() => GetCharacterComponent().OnFixedUpdate(character);
}
