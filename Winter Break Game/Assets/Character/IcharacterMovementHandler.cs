using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterMovementHandler : ICharacterInterface
{
    void Start();
    void Update();
    void FixedUpdate(); 
}
