using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageHandler
{
    void Damage(float damage, GameObject damager);
}
