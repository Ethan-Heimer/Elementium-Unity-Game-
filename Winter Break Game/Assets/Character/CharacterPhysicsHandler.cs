using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPhysicsHandler : MonoBehaviour, ICharacterPhysicsHandler
{
    public float accelerationSpeed = 0;
    public float speed;
    public float jumpForce;
    public AnimationCurve accelerationCurve;

    [SerializeField] Rigidbody2D rigidbody;
    ICharacterDirectionHandler directionHandler;
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

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        directionHandler = GetComponent<ICharacterDirectionHandler>();
    }

    public void Move(float direction, bool jump)
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

        rigidbody.velocity = new Vector2(GetAcceleration() * speed, rigidbody.velocity.y + (jump ? jumpForce : 0));
    }

    public void Move(Vector2 direction, bool jump)
    {
        float mult = speed * Time.deltaTime * 100;
        rigidbody.velocity = new Vector2(direction.x * mult/2, direction.y * mult + (jump ? jumpForce : 0));
    }

    public float GetAcceleration() => accelerationCurve.Evaluate(accelerationStep);

    public void SetAccelerationStepCap(float val) => accelerationStepCap = val;

    public void SetVelocity(Vector2 velocity) => rigidbody.velocity = velocity;
    public Vector2 GetVelocity() => rigidbody.velocity;

    public void SetAccelerationStep(float val) => accelerationStep = val;

    public float GetSpeed() => speed;

    public void FreezeGravity(bool freeze) => rigidbody.gravityScale = freeze ? 0 : 3; 
}

