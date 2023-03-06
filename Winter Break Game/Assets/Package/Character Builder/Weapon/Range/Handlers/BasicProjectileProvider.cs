using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectileProvider : MonoBehaviour, IProjectileProvider
{
    public GameObject bullet; 

    public Projectile GetNewProjectile(float angle, float speed, float damage, GameObject owner)
    {
        var obj = Instantiate(bullet);

        obj.transform.position = transform.position;
        Projectile projectile = obj.GetComponent<Projectile>();

        //projectile.InitProjectile(angle, speed, damage, owner);

        return projectile;
    }
}
