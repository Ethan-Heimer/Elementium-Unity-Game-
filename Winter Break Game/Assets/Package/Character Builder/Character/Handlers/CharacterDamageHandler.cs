using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageHandler : MonoBehaviour, IDamageable, IDamageHandler
{
    IHealthHandler healthHandler;
    IOnCharacterDamaged[] onCharacterDamageds;
    
    Timer damageCooldown = new Timer(.5f); 

    void Awake()
    {
        healthHandler = GetComponent<IHealthHandler>();
        onCharacterDamageds = GetComponents<IOnCharacterDamaged>();
       

        damageCooldown.ResetTimer();
    }

    public void Damage(float Damage, GameObject damager)
    {
        if (damageCooldown.IsTimerUp())
        {
            foreach (IOnCharacterDamaged o in onCharacterDamageds)
            {
                o.OnCharacterDamaged(Damage, damager);
            }

            healthHandler.SubtractHealth(Damage);

            damageCooldown.ResetTimer();
            Debug.Log("Damaged "+Damage);
        }

    }

    
}
