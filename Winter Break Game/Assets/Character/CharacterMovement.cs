using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    Character character; 

    public CharacterMovement(Character _character)
    {
        character = _character;
    }

    bool _isWalking; 
    public void Move(float direction, float speed)
    {
        character.directionHandler.FlipCharacter(direction);
        character.physicsHandler.Accelerate(direction, speed);

        if (character.groundStatus.IsOnGround())
        {
            if (direction is not 0 && !_isWalking)
            {
                _isWalking = true;
                character.eventManager.OnStartMove.Invoke();
            }
            else if (direction is 0 && _isWalking)
            {
                _isWalking = false;
                character.eventManager.OnEndMove.Invoke();
            }
        }
        else
        {
            _isWalking = false; 
        }

    }

    bool _isClimbing; 
    public void Climb(Vector2 direction, float speed, bool invokeClimbEvents)
    {
        character.physicsHandler.SetVelocity(direction * speed);

        if (!invokeClimbEvents) return;

        if (direction == Vector2.zero && _isClimbing)
        {
            _isClimbing = false;
            character.eventManager.OnEndClimb.Invoke();
        }
        else if (direction != Vector2.zero && !_isClimbing)
        {
            _isClimbing = true;
            character.eventManager.OnClimb.Invoke();
        }
    }

    public void Jump(float jumpHeight)
    {
        character.physicsHandler.AddForce(Vector2.up * jumpHeight);

        character.eventManager.OnJump.Invoke();
    }
}

