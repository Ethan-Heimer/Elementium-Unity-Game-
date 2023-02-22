using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterPhysicsHandlerWithoutAcceleration : CharacterClass, ICharacterPhysicsHandler
{
    [SerializeField] Rigidbody2D rigidbody;


    public override void Constructer(Character character)
    {
        base.Constructer(character);

        rigidbody = character.GetComponent<Rigidbody2D>();
    }

    public void Accelerate(float direction, float speed)
    {
        rigidbody.velocity = new Vector2(speed * direction, rigidbody.velocity.y);
        Debug.Log(rigidbody.velocity);
    }

    public void AddForce(Vector2 force) => rigidbody.velocity += force;

    public void SetMaxAcceleration(float max) { }
    public void SetAcceleration(float value){}
    public void FreezeGravity(bool freeze) => rigidbody.gravityScale = freeze ? 0 : 3;
    public Vector2 GetVelocity() => rigidbody.velocity;
    public void SetVelocity(Vector2 velocity) => rigidbody.velocity = velocity;
}

