using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterPhysicsHandler
{
    public void Move(float direction, bool jump);
    public void Move(Vector2 vector, bool jump); 

    public void SetVelocity(Vector2 velocity);
    public Vector2 GetVelocity();

    public float GetAcceleration();
    public void SetAccelerationStep(float val);
    public void SetAccelerationStepCap(float val);

    public float GetSpeed();

    public void FreezeGravity(bool freeze); 
}
