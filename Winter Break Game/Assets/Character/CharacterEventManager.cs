using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

[System.Serializable]
public class CharacterEventManager
{
    public UnityEvent OnGround;
    public UnityEvent InAir;
    public UnityEvent OnWall;
    public UnityEvent OffWall; 
    public UnityEvent OnStartMove;
    public UnityEvent OnEndMove;
    public UnityEvent OnStartClimb; 
    public UnityEvent OnClimb;
    public UnityEvent OnEndClimb; 
    public UnityEvent OnJump;

    public UnityEvent OnDeath;
    public UnityEvent OnDamaged;
}

