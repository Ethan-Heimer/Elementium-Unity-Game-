using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class CharacterMovement
{
    public event Action OnStartMove;
    public event Action OnEndMove;
   
    public event Action OnAxisMove;
    public event Action OnAxisMoveEnd;
    public event Action OnJump; 


    Character character; 

    public CharacterMovement(Character _character)
    {
        character = _character;

        character.groundStatus.OnHitGround += checkForWalkEvent;
    }

    bool _isMoveing; 
    public void Move(float direction, float speed)
    {
        character.directionHandler.FlipCharacter(direction);
        character.physicsHandler.Accelerate(direction, speed);

        if (character.groundStatus.IsOnGround())
        {
            if (direction is not 0 && !_isMoveing)
            {
                _isMoveing = true;
                OnStartMove?.Invoke();
            }
            else if (direction is 0 && _isMoveing)
            {
                _isMoveing = false;
                OnEndMove?.Invoke();
            }
        }
        else
        {
            _isMoveing = false;
        }
    }

    public void AxisMove(Vector2 direction, float speed, bool invokeEvents)
    {
        character.physicsHandler.SetVelocity(direction * speed);

        if (!invokeEvents) return;

        if (direction == Vector2.zero && _isMoveing)
        {
            _isMoveing = false;
            OnAxisMoveEnd?.Invoke();
        }
        else if (direction != Vector2.zero && !_isMoveing)
        {
            _isMoveing = true;
            OnAxisMove?.Invoke();
        }
    }

    public void Jump(float jumpHeight)
    {
        character.physicsHandler.AddForce(Vector2.up * jumpHeight);

        OnJump?.Invoke();
    }

    async void checkForWalkEvent()
    {
        await Task.Yield();
        if (_isMoveing) OnStartMove?.Invoke();
    }
}

