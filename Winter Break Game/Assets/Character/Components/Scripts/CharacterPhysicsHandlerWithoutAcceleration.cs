using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Physics Handler", menuName = "Character Components/Physics Handlers/Physics Handler Without Acceleration")]
public class CharacterPhysicsHandlerWithoutAcceleration : CharacterPhysicsHandler
{
    public override void Accelerate(Character character, Rigidbody2D rigidbody, float direction, float speed)
    {
        rigidbody.velocity = new Vector2(speed * direction, rigidbody.velocity.y);
    }

    public override void AddForce(Character character, Rigidbody2D rigidbody, Vector2 force) => rigidbody.velocity += force;
    public override void SetMaxAcceleration(Character character, Rigidbody2D rigidbody, float max) { }
    public override void SetAcceleration(Character character, Rigidbody2D rigidbody, float value){}
    public override void FreezeGravity(Character character, Rigidbody2D rigidbody, float baseGravity, bool freeze) => rigidbody.gravityScale = freeze ? 0 : baseGravity;
    public override Vector2 GetVelocity(Character character, Rigidbody2D rigidbody) => rigidbody.velocity;
    public override void SetVelocity(Character character, Rigidbody2D rigidbody, Vector2 velocity) => rigidbody.velocity = velocity;
    public override float GetAcceleration(Character character, Rigidbody2D rigidbody) => 1;
}

