using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponHandler : MonoBehaviour, IWeaponHandler
{
    public GameObject _weaponPrefab;
    Weapon _weapon;

    IOnCharacterAttack[] OnCharacterAttacks; 

    // Start is called before the first frame update
    void Awake()
    {
        GameObject weapon = Instantiate(_weaponPrefab);

        weapon.transform.position = transform.position;
        weapon.transform.SetParent(transform);
       

        _weapon = weapon.GetComponent<Weapon>();
        _weapon.ConfigOwner(gameObject);

        OnCharacterAttacks = GetComponents<IOnCharacterAttack>();
    }

    public void Attack()
    {
        _weapon.Attack();

        foreach(IOnCharacterAttack o in OnCharacterAttacks)
        {
            o.OnCharacterAttack();
        }
    }
}
