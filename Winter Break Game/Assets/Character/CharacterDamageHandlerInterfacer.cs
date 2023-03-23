using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageHandlerInterfacer : CharacterComponentInterfacer<CharacterDamageHandler>
{
    public CharacterDamageHandlerInterfacer(Character character, CharacterConfig config) : base(character, config) { }
    public void OnDamaged() => GetCharacterComponent().OnDamaged(character);
}
