using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterPhysicsHandler : CharacterClass, ICharacterPhysicsHandler
{
    public AnimationCurve accelerationCurve;

    [SerializeField] Rigidbody2D rigidbody;
    ICharacterDirectionHandler directionHandler;
    float accelerationStepCap = 1;
    float accelerationSpeed;

    float _step = 0;
    float accelerationStep
    {
        get
        {
            return _step;
        }

        set
        {
            _step = Mathf.Clamp(value, -accelerationStepCap, accelerationStepCap);
        }
    }

    public override void Constructer(Character character)
    {
        base.Constructer(character);

        rigidbody = character.GetComponent<Rigidbody2D>();
        directionHandler = character.movement.directionHandler;

        accelerationSpeed = character.statsHandler.GetStat("Acceleration Speed");
    }

    public void Move(float direction, float speed)
    {
        directionHandler?.FlipCharacter((int)direction);
        if (direction != 0)
        {
            accelerationStep += accelerationSpeed * Time.deltaTime * direction;
        }
        else
        {
            accelerationStep = accelerationStep > 0 ? accelerationStep - accelerationSpeed * Time.deltaTime : accelerationStep + accelerationSpeed * Time.deltaTime;
        }

        rigidbody.velocity = new Vector2(GetAcceleration() * speed, rigidbody.velocity.y);
        // rigidbody.velocity.y + (jump ? jumpForce : 0)
    }

    public void Move(Vector2 direction, float speed)
    {
        float mult = speed;
        rigidbody.velocity = new Vector2(direction.x * mult/2, direction.y * mult);
    }

    public void Jump(bool jump, float jumpHeight)
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y + (jump ? jumpHeight : 0));
    }

    public float GetAcceleration() => accelerationCurve.Evaluate(accelerationStep);

    public void SetAccelerationStepCap(float val) => accelerationStepCap = val;

    public void SetVelocity(Vector2 velocity) => rigidbody.velocity = velocity;
    public Vector2 GetVelocity() => rigidbody.velocity;

    public void SetAccelerationStep(float val) => accelerationStep = val;

    public void FreezeGravity(bool freeze) => rigidbody.gravityScale = freeze ? 0 : 3;
}

