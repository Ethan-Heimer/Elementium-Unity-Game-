using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRayDamageReciever : MonoBehaviour, IRayDamageReciever, IWaterRayInteractable
{
    bool damage; 

    public void OnHit(Vector2 whereHit)
    {
        damage = true;
    }

    public bool IsCorrectRayTouching() => damage; 
}
