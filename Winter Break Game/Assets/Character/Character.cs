using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterConfig config;

    public CharacterMovement movement;
    public CharacterDamageManager damageManager;
    public CharacterEventManager eventManager;

    public ICharacterStatsHandler statsHandler; 

    [SerializeField] public CharacterEventData eventData; 

    public void Awake()
    {
        movement = new CharacterMovement(this);
        damageManager = new CharacterDamageManager(this);
        eventManager = new CharacterEventManager(this, eventData);

        statsHandler = config.GetStatsHandler();

        movement.SetUp();
        damageManager.SetUp();
        eventManager.SetUp();
    }

    public void Update()
    {
        movement.Tick();
        damageManager.Tick();
    }

    public void FixedUpdate()
    {
        movement.FixedTick();
    }
}
