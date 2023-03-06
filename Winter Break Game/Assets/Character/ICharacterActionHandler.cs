using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterActionHandler : ICharacterInterface
{
    void Start();
    void OnAction();
}
