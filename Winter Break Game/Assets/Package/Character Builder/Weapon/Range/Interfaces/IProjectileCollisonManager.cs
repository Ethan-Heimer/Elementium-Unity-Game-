using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileCollisonManager
{
    IDamageable[] GetIntersectingDamageables(GameObject parentCharacter);
}
