using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public interface ICharacterPhysicsHandler : ICharacterInterface
{

    public void Accelerate(float direction, float speed);
    public void AddForce(Vector2 force);

    public void SetMaxAcceleration(float max);
    public void FreezeGravity(bool freeze);
    public void SetAcceleration(float value);
    public Vector2 GetVelocity();
    public float GetAcceleration();
    public void SetVelocity(Vector2 velocity);
    /*
    public void Move(float direction, float speed);
    public void Move(Vector2 vector, float speed);

    public void Jump(bool jump, float jumpForce);

    public void SetVelocity(Vector2 velocity);
    public Vector2 GetVelocity();

    public float GetAcceleration();
    public void SetAccelerationStep(float val);
    public void SetAccelerationStepCap(float val);

   
    */
}
