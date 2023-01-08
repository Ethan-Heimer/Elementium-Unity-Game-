using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileDamageHandler
{
    void DamageObjects(GameObject[] projectiles, float damage, GameObject owner);
}
