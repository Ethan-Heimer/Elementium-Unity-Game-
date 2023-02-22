using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterPhysicsHandler : CharacterClass, ICharacterPhysicsHandler
{
    [SerializeField] Rigidbody2D rigidbody;
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

        accelerationSpeed = character.statsHandler.GetStat("Acceleration Speed");
    }


    public void Accelerate(float direction, float speed)
    {
        if (direction > .2f || direction < -.2f)
        {
            accelerationStep += accelerationSpeed * Time.deltaTime * direction;
        }
        else
        {
            accelerationStep = accelerationStep > 0 ? accelerationStep - accelerationSpeed * Time.deltaTime : accelerationStep + accelerationSpeed * Time.deltaTime;
        }

        rigidbody.velocity = new Vector2(accelerationStep * speed, rigidbody.velocity.y);
    }

    public void AddForce(Vector2 force) => rigidbody.velocity += force;

    public void SetMaxAcceleration(float max) => accelerationStepCap = max;
    public void SetAcceleration(float value) => accelerationStep = value; 
    public void FreezeGravity(bool freeze) => rigidbody.gravityScale = freeze ? 0 : 3;

    public Vector2 GetVelocity() => rigidbody.velocity;
    public void SetVelocity(Vector2 velocity) => rigidbody.velocity = velocity;

}

