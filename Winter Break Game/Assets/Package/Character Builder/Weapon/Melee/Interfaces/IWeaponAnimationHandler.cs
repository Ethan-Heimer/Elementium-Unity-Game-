using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponAnimationHandler
{
    IEnumerator Animation(float speed);
    void Play();
}
