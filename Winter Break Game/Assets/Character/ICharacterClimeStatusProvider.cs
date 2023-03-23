using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ClimbStatusProvider : CharacterComponent
{
    public abstract bool CheckForClimb(Character character);
}
