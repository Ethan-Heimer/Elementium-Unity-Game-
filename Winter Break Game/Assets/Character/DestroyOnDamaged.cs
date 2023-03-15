using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDamaged : CharacterClass, ICharacterDamageHandler
{
    public void OnDamaged()
    {
        character.damageManager.KillCharacter();
    }
}
