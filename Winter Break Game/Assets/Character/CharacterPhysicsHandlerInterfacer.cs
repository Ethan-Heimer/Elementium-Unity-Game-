using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class CharacterPhysicsHandlerInterfacer : CharacterComponentInterfacer<CharacterPhysicsHandler>
{
    float baseGravity;
    Rigidbody2D rigidbody;
    public CharacterPhysicsHandlerInterfacer(Character character, CharacterConfig config) : base(character, config)
    {
        rigidbody = character.GetComponent<Rigidbody2D>();
        baseGravity = rigidbody.gravityScale;
    }

    public void Accelerate(float direction, float speed) => GetCharacterComponent().Accelerate(character, rigidbody, direction, speed);
    public void AddForce(Vector2 force) => GetCharacterComponent().AddForce(character, rigidbody, force);
    public void SetMaxAcceleration(float max) => GetCharacterComponent().SetMaxAcceleration(character, rigidbody, max);
    public void FreezeGravity(bool freeze) => GetCharacterComponent().FreezeGravity(character, rigidbody, baseGravity, freeze);
    public void SetAcceleration(float value) => GetCharacterComponent().SetAcceleration(character, rigidbody, value);
    public Vector2 GetVelocity() => GetCharacterComponent().GetVelocity(character, rigidbody);
    public float GetAcceleration() => GetCharacterComponent().GetAcceleration(character, rigidbody);
    public void SetVelocity(Vector2 velocity) => GetCharacterComponent().SetVelocity(character, rigidbody, velocity);


    
}
