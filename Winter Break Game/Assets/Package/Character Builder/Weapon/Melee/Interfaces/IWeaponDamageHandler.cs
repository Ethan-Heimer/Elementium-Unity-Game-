using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponDamageHandler
{
    void DamageObjects(IDamageable[] objs, float Damage, GameObject _owner);
}