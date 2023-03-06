using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRayRaycastProvider : MonoBehaviour, IRayProvider
{
    int MaxRayDistance = 50; 

    public Ray2D GetRay(Vector2 angle) => new Ray2D(transform.position, angle);
    public int GetRayMaxDistance() => MaxRayDistance; 
    public RaycastHit2D GetRaycast(Vector2 angle) => Physics2D.Raycast(transform.position, angle, MaxRayDistance, LayerMask.GetMask("Enviorment")); 
}
