using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMeleeCollisonHandler
{
    IDamageable[] CheckCollision(GameObject _owner);
}
