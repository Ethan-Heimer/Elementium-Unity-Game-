using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealthHandler : CharacterClass, ICharacterDamageHandler
{
    Timer damageCooldown = new Timer(.1f);

    public override void Constructer(Character _character)
    {
        base.Constructer(_character);

        character.statsHandler.SetStat("Health", character.statsHandler.GetStat("Starting Health")); 
    }

    public void OnDamaged()
    {
        if (!damageCooldown.IsTimerUp()) return;

        character.statsHandler.SubtractStatValue("Health", 1);  

        if(character.statsHandler.GetStat("Health") == 0)
        {
            character.damageManager.KillCharacter();
        }

        damageCooldown.ResetTimer();
    }
}
