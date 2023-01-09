using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterInputHandler
{
    float GetHorizontalInput();
    float GetVerticalInput(); 
    bool GetJumpInput();
    
}
