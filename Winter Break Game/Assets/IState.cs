using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(StateMachine owner);
    void WhileInState(StateMachine owner);
    void OnExit(StateMachine owner);
    void Transition(StateMachine owner); 
}
