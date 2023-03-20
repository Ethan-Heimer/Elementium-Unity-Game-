using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

[System.Serializable]
public class CharacterEventManager : CharacterClass
{
    [SerializeField] UnityEvent OnGround; //
    [SerializeField] UnityEvent InAir; //
    [SerializeField] UnityEvent OnWall; //
    [SerializeField] UnityEvent OffWall; //
    [SerializeField] UnityEvent OnStartMove;
    [SerializeField] UnityEvent OnEndMove;
    
    [SerializeField] UnityEvent OnAxisMove; //
    [SerializeField] UnityEvent OnAxisMoveEnd;

    [SerializeField] UnityEvent OnStartClimb;
    [SerializeField] UnityEvent OnEndClimb; // 

    [SerializeField] UnityEvent OnJump; //
     
    [SerializeField] UnityEvent OnDeath; //
    [SerializeField] UnityEvent OnDamaged; //

    public override void Constructer(Character _character)
    {
        base.Constructer(_character);

        character.groundStatus.OnHitGround += OnGround.Invoke;
        character.groundStatus.OnEnterAir += InAir.Invoke;

        character.damageManager.OnDamaged += OnDamaged.Invoke;
        character.damageManager.OnDeath += OnDeath.Invoke;

        character.wallStatus.OnWallEntered += OnWall.Invoke;
        character.wallStatus.OnWallExited += OffWall.Invoke;

        character.movement.OnStartMove += OnStartMove.Invoke;
        character.movement.OnEndMove += OnEndMove.Invoke;

        character.movement.OnAxisMove += OnAxisMove.Invoke;
        character.movement.OnAxisMoveEnd += OnAxisMoveEnd.Invoke;

        character.movement.OnJump += OnJump.Invoke;

        character.climbStatus.OnClimbEnter += OnStartClimb.Invoke;
        character.climbStatus.OnClimbExit += OnEndClimb.Invoke;
        
    }
}

