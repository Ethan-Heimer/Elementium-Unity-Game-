using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class CharacterPhysicsHandlerInterfacer : CharacterComponentInterfacer<CharacterPhysicsHandler>
{
    float baseGravity;
    Rigidbody2D rigidbody;
    public CharacterPhysicsHandlerInterfacer(Character character, CharacterConfigManager config) : base(character, config)
    {
        rigidbody = character.GetComponent<Rigidbody2D>();
        baseGravity = rigidbody.gravityScale;
    }

    public void Accelerate(float direction, float speed) => Component.Accelerate(character, rigidbody, direction, speed);
    public void AddForce(Vector2 force) => Component.AddForce(character, rigidbody, force);
    public void SetMaxAcceleration(float max) => Component.SetMaxAcceleration(character, rigidbody, max);
    public void FreezeGravity(bool freeze) => Component.FreezeGravity(character, rigidbody, baseGravity, freeze);
    public void SetAcceleration(float value) => Component.SetAcceleration(character, rigidbody, value);
    public Vector2 GetVelocity() => Component.GetVelocity(character, rigidbody);
    public float GetAcceleration() => Component.GetAcceleration(character, rigidbody);
    public void SetVelocity(Vector2 velocity) => Component.SetVelocity(character, rigidbody, velocity);


    
}
