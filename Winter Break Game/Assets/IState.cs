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

public interface IFixedState
{
    void FixedWhileInState(); 
}
