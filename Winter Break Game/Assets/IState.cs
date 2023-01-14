using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IState
{
    void OnEnter();
    void WhileInState();
    void OnExit();
    
    void Transition(StateMachine owner); 
}

public interface ICharacterState : IState, ICloneable {
    void Constructer(Character character);
}

public interface IGroundState : ICharacterState { }
public interface IAirState : ICharacterState { }
public interface IWallState : ICharacterState { }
public interface IClimbState : ICharacterState { }
