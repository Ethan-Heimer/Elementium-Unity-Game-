using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterPhysicsHandlerWithoutAcceleration : CharacterClass, ICharacterPhysicsHandler
{
    [SerializeField] Rigidbody2D rigidbody;
    

    public override void Constructer(Character character)
    {
        base.Constructer(character);

        rigidbody = character.GetComponent<Rigidbody2D>();
    }

    public void Move(float direction, float speed, bool jump, float jumpForce)
    {
        character.movement.directionHandler.FlipCharacter((int)direction);
        rigidbody.velocity = new Vector2(speed * direction, rigidbody.velocity.y + (jump ? jumpForce : 0));
    }

    public void Move(Vector2 direction, float speed, bool jump, float jumpForce)
    {
        float mult = speed * Time.deltaTime * 100;
        rigidbody.velocity = new Vector2(direction.x * mult / 2, direction.y * mult + (jump ? jumpForce : 0));
    }

    public float GetAcceleration() => 0;

    public void SetAccelerationStepCap(float val) { }

    public void SetVelocity(Vector2 velocity) => rigidbody.velocity = velocity;
    public Vector2 GetVelocity() => rigidbody.velocity;

    public void SetAccelerationStep(float val) {}

    public void FreezeGravity(bool freeze) => rigidbody.gravityScale = freeze ? 0 : 3;
}

