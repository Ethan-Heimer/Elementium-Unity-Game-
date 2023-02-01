using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class RayPushable : RayAffectable
{
    [SerializeField] float pushSpeed; 
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }


    public override void OnHit(Vector2 point)
    {
        float direction = point.x > transform.position.x? -1: 1; 
        rb.velocity = Vector2.right * direction * pushSpeed;
    }
}
