using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileProvider
{
    Projectile GetNewProjectile(float angle, float speed, float damage, GameObject owner);
}
