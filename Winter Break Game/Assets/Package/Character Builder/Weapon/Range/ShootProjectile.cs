using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour, IOnWeaponAttack
{
    IProjectileProvider projectileProvider;
    IAimHandler aimHandler;

    [SerializeField] float bulletSpeed;

    public void Awake()
    {
        projectileProvider = GetComponent<IProjectileProvider>();
        aimHandler = GetComponent<IAimHandler>();
    }
    public void OnWeaponAttack(float damage, GameObject _owner)
    {
        projectileProvider.GetNewProjectile(aimHandler.GetAimAngle(), bulletSpeed, damage, _owner);
    }
}