using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeaponDamageHandler : MonoBehaviour, IWeaponDamageHandler
{
    public void DamageObjects(IDamageable[] objs, float Damage, GameObject _owner)
    {
        foreach (IDamageable o in objs)
        {
            o.Damage(Damage, _owner);
        }
    }
}
