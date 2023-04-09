using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;

public class CharacterMovement
{
    Character character;

    event Action<Character> OnStartMove;
    event Action<Character> OnEndMove;
   
    event Action<Character> OnAxisMove;
    event Action<Character> OnAxisMoveEnd;
    event Action<Character> OnJump; 

    public CharacterMovement(Character _character)
    {
        character = _character;

        character.eventManager.AddEventListener("GroundOnTrue", checkForWalkEvent);
    }

    bool _isMoveing; 
    public void Move(float direction, float speed)
    {
        character.directionHandler.FlipCharacter(direction);
        character.physicsHandler.Accelerate(direction, speed);

        if (character.enviormentStatuses.GetStatus("Ground"))
        {
            if (direction is not 0 && !_isMoveing)
            {
                _isMoveing = true;
                OnStartMove?.Invoke(character);
            }
            else if (direction is 0 && _isMoveing)
            {
                _isMoveing = false;
                OnEndMove?.Invoke(character);
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
            OnAxisMoveEnd?.Invoke(character);
        }
        else if (direction != Vector2.zero && !_isMoveing)
        {
            _isMoveing = true;
            OnAxisMove?.Invoke(character);
        }
    }

    public void Jump(float jumpHeight)
    {
        character.physicsHandler.AddForce(Vector2.up * jumpHeight);

        OnJump?.Invoke(character);
    }

    async void checkForWalkEvent()
    {
        await Task.Yield();
        if (_isMoveing) OnStartMove?.Invoke(character);
    }

    public CharacterEvent[] GetEvents()
    {
        EventInfo[] events = this.GetType().GetEvents(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.EventHandlerType == typeof(Action<Character>)).ToArray();
        List<CharacterEvent> cEvents = new List<CharacterEvent>();

        foreach(EventInfo e in events)
        {
            CharacterEvent cEvent = new CharacterEvent(e.Name);
            cEvents.Add(cEvent);

            MethodInfo invokeEvent = cEvent.GetType().GetMethod("Invoke", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            Delegate eventInvoker = Delegate.CreateDelegate(e.EventHandlerType, cEvent, invokeEvent);

            var addMethod = e.GetAddMethod(true);
            addMethod.Invoke(this, new[] { eventInvoker});
        }

        return cEvents.ToArray();
    }
}

