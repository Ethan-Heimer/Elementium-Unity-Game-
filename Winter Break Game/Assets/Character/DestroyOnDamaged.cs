using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDamaged : CharacterClass, ICharacterDamageHandler
{
    public void OnDamaged()
    {
        character.eventManager.OnDeath.Invoke();
        character.damageManager.KillCharacter();
    }
}
