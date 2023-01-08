using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageManager : MonoBehaviour
{
    ICharacterDamageChecker damageChecker;
    ICharacherDamageHandler damageHandler;

    private void Awake()
    {
        damageChecker = GetComponent<ICharacterDamageChecker>();
        damageHandler = GetComponent<ICharacherDamageHandler>();
    }

    public void Update()
    {
        bool damaged = damageChecker.CheckDamage();

        if (damaged)
        {
            damageHandler.OnDamaged(); 
        }
    }
}
