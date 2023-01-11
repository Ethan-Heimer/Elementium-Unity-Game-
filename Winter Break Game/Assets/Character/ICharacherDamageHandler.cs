using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterDamageHandler : ICharacterInterface
{
    void OnDamaged();
}
