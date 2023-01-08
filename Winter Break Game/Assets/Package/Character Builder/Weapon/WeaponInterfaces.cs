using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnWeaponAttack
{
    void OnWeaponAttack(float damage, GameObject owner);
}
