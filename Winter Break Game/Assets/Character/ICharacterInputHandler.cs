using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class CharacterInputHandler : CharacterComponent 
{
    public abstract float GetHorizontalInput(Character character);
    public abstract float GetVerticalInput(Character character); 
    public abstract bool GetJumpInput(Character character);
    public abstract bool GetActionInput(Character character);
    public abstract bool GetClimbInput(Character character);
}
