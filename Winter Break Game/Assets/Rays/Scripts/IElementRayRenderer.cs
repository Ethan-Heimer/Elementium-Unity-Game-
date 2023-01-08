using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElementRayRenderer 
{
    void RenderRay(ElementRayData data, float distance, Vector2 angle);
    void DisableRay(float distance, Vector2 angle);
}
