using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterDirectionHandler
{
    void FlipCharacter(int Direction);
    int GetCurrentDirection();
}
