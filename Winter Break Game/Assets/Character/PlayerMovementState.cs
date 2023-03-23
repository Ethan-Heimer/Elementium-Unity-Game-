using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementState : IState, IFixedState
{
    protected Character character;
    protected PlayerMovementHandler playerMovementHandler;
    public PlayerMovementState(Character _character, PlayerMovementHandler _playerMovementHandler)
    {
        character = _character;
        playerMovementHandler = _playerMovementHandler;
    }

    public abstract void OnEnter();
    public abstract void WhileInState();
    public abstract void FixedWhileInState();
    public abstract void OnExit();
}
