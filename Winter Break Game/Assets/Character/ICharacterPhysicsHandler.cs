using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public interface ICharacterPhysicsHandler : ICharacterInterface
{
    public void Move(float direction, float speed, bool jump, float jumpForce);
    public void Move(Vector2 vector, float speed, bool jump, float jumpForce); 

    public void SetVelocity(Vector2 velocity);
    public Vector2 GetVelocity();

    public float GetAcceleration();
    public void SetAccelerationStep(float val);
    public void SetAccelerationStepCap(float val);

    public void FreezeGravity(bool freeze); 
}
