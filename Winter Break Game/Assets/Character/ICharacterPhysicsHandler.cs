using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class CharacterPhysicsHandler : CharacterComponent
{
    public abstract void Accelerate(Character character, Rigidbody2D rigidbody, float direction, float speed);
    public abstract void AddForce(Character Character, Rigidbody2D rigidbody, Vector2 force);
    public abstract void SetMaxAcceleration(Character character, Rigidbody2D rigidbody, float max);
    public abstract void FreezeGravity(Character character, Rigidbody2D rigidbody, float baseGravity, bool freeze);
    public abstract void SetAcceleration(Character character, Rigidbody2D rigidbody, float value);
    public abstract Vector2 GetVelocity(Character character, Rigidbody2D rigidbody);
    public abstract float GetAcceleration(Character character, Rigidbody2D rigidbody);
    public abstract void SetVelocity(Character character, Rigidbody2D rigidbody, Vector2 velocity);
}
