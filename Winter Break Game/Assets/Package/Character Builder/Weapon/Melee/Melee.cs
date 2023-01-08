using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Melee : MonoBehaviour, IOnWeaponAttack
{   
    public IWeaponDamageHandler damageHandler;
    public IMeleeCollisonHandler collisonHandler;

    public float swingTime;
    Timer t_actionTime;
    public void Awake()
    {
        t_actionTime = new Timer(swingTime);

        damageHandler = GetComponent<IWeaponDamageHandler>();
        collisonHandler = GetComponent<IMeleeCollisonHandler>();
    }

    public async void OnWeaponAttack(float damage, GameObject _owner)
    {
        t_actionTime.ResetTimer();

        while (!t_actionTime.IsTimerUp())
        {
            IDamageable[] objs = collisonHandler.CheckCollision(_owner);
            damageHandler.DamageObjects(objs, damage, _owner);

            await Task.Yield();
        }
    }
}


