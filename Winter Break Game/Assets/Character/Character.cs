using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterConfig config;

    public CharacterMovement movement;
    public CharacterDamageManager damageManager; 

    public void Awake()
    {
        movement = new CharacterMovement(this);
        damageManager = new CharacterDamageManager(this);
    }

    public void Start()
    {
        movement.SetUp();
        damageManager.SetUp();
    }

    public void Update()
    {
        movement.Tick();
        damageManager.Tick();
    }
}
