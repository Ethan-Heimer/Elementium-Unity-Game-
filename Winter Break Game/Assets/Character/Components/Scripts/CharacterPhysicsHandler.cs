using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Physics Handler", menuName = "Character Components/Physics Handlers/Standard Physics Handler")]
public class StandardCharacterPhysicsHandler : CharacterPhysicsHandler
{
    public float AccelerationSpeed;

    float accelerationStepCap = 1;

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


    public override void Accelerate(Character character, Rigidbody2D rigidbody, float direction, float speed)
    {
        if (direction > .2f || direction < -.2f)
        {
            accelerationStep += AccelerationSpeed * Time.deltaTime * direction;
        }
        else
        {
            accelerationStep = accelerationStep > 0 ? accelerationStep - AccelerationSpeed * Time.deltaTime : accelerationStep + AccelerationSpeed * Time.deltaTime;
        }

        rigidbody.velocity = new Vector2(accelerationStep * speed, rigidbody.velocity.y);
    }

    public override void AddForce(Character character, Rigidbody2D rigidbody, Vector2 force) => rigidbody.velocity += force;

    public override void SetMaxAcceleration(Character character, Rigidbody2D rigidbody, float max) => accelerationStepCap = max;
    public override void SetAcceleration(Character character, Rigidbody2D rigidbody, float value) => accelerationStep = value;
    public override void FreezeGravity(Character character, Rigidbody2D rigidbody, float baseGravity, bool freeze)
    {
        rigidbody.gravityScale = freeze ? 0 : baseGravity;
    }

    public override Vector2 GetVelocity(Character character, Rigidbody2D rigidbody) => rigidbody.velocity;
    public override void SetVelocity(Character character, Rigidbody2D rigidbody, Vector2 velocity) => rigidbody.velocity = velocity;

    public override float GetAcceleration(Character character, Rigidbody2D rigidbody) => accelerationStep;

}

