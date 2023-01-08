using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRayProvider
{
    public int GetRayMaxDistance(); 
    public Ray2D GetRay(Vector2 angle);
    public RaycastHit2D GetRaycast(Vector2 angle);
}
