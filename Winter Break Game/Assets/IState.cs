using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter();
    void WhileInState();
    void OnExit();
    void Transition(StateMachine owner); 
}
