using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDamageReciever : RayAffectable, IRayDamageReciever
{
    bool damage; 

    public override void OnHit(Vector2 whereHit)
    {
        damage = true;
    }

    public bool IsCorrectRayTouching() => damage; 
}
