using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject owner;

    Timer lifeTime = new Timer(5);
    void Start()
    {
        //if (!init) Init(transform.rotation.z, 20, gameObject); 
    }

    bool init = false; 
    public void Init(float angle, float speed, GameObject _owner)
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 vector = new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad), Mathf.Sin(angle*Mathf.Deg2Rad));
        rb.velocity = vector * speed;
        
        init = true;

        owner = _owner;

        lifeTime.ResetTimer();
    }

    public void FixedUpdate()
    {
        if (lifeTime.IsTimerUp()) Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == owner) return;

        Destroy(gameObject);
    }
}
