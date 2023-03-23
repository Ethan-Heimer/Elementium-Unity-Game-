using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Handler", menuName = "Character Components/Damage Handlers/Decrease Health")]
public class DecreaseHealthHandler : CharacterDamageHandler
{
    public float StartingHealth;
    [HideInInspector] public float Health;

    Timer damageCooldown = new Timer(.1f);

    bool initHealth;

    public override void OnDamaged(Character character)
    {
        if (!initHealth)
        {
            Health = StartingHealth;
            initHealth = true;
        }

        if (!damageCooldown.IsTimerUp()) return;

        Health--;

        if(Health <= 0)
        {
            character.damageManager.KillCharacter();
            initHealth = true;
        }

        damageCooldown.ResetTimer();
    }
}
