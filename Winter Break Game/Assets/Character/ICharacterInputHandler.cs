using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public interface ICharacterInputHandler : ICharacterInterface
{
    float GetHorizontalInput();
    float GetVerticalInput(); 
    bool GetJumpInput();
    bool GetActionInput();
    bool GetClimbInput();
}
