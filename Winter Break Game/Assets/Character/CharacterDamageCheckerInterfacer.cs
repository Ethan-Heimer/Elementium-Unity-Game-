using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageCheckerInterfacer : CharacterComponentInterfacer<CharacterDamageChecker>
{
    public CharacterDamageCheckerInterfacer(Character character, CharacterConfigManager config) : base(character, config) { }
    public bool CheckDamage() => Component.CheckDamage(character);
}
