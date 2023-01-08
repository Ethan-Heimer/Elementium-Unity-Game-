using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElementRayInputProvider
{
    bool ShootRayIsPressed();
    Vector3 GetAimVector(); 
}
