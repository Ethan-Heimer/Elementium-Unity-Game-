using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Handler", menuName = "Character Components/Damage Handlers/Destroy On Damaged")]
public class DestroyOnDamaged : CharacterDamageHandler
{
    public override void OnDamaged(Character character)
    {
        character.damageManager.KillCharacter();
    }
}
