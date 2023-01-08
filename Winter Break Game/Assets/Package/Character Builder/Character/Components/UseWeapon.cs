using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour, IOnCharacterUpdate
{
    IWeaponHandler weaponHandler; 
    // Start is called before the first frame update
    void Awake()
    {
        weaponHandler = GetComponent<IWeaponHandler>();
    }

    // Update is called once per frame
    public void OnCharacterUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weaponHandler.Attack();
        }
    }
}
