using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float actionCooldown=.5f;
    public float damage;

    Timer t_actionCooldown;  

    IOnWeaponAttack[] OnWeaponAttacks;

    public IWeaponAnimationHandler animationHandler;

    [HideInInspector] public GameObject _owner;
    public void ConfigOwner(GameObject parent) => _owner = parent;

    public virtual void Awake()
    {
        OnWeaponAttacks = GetComponents<IOnWeaponAttack>();
        animationHandler = GetComponent<IWeaponAnimationHandler>();
        t_actionCooldown = new Timer(actionCooldown);
    }

    public void Attack()
    {
        if(t_actionCooldown.IsTimerUp())
        {
            foreach(IOnWeaponAttack o in OnWeaponAttacks)
            {
                o.OnWeaponAttack(damage, _owner);
            }

            t_actionCooldown.ResetTimer();

            if (animationHandler is not null) animationHandler.Play();
        }
    }
}


