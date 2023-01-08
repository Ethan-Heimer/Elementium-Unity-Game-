using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeTime;
    Timer t_lifeTime;

    Rigidbody2D rb;

    IProjectileCollisonManager collisonManager;
    IWeaponDamageHandler damageHandler;

    float damage = 1;
    GameObject parentCharacter;

    float angle; 
    float speed;

    public void InitProjectile(float _angle, float _speed, float _damage, GameObject _parentCharacter)
    {
        angle = _angle; 

        speed = _speed; 

        damage = _damage;

        parentCharacter = _parentCharacter;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        t_lifeTime = new Timer(lifeTime);
        t_lifeTime.ResetTimer();

        collisonManager = GetComponent<IProjectileCollisonManager>();
        damageHandler = GetComponent<IWeaponDamageHandler>();

        parentCharacter = parentCharacter is null ? gameObject : parentCharacter;

        SetVelocity();
    }
    public void Update()
    {
        if (t_lifeTime.IsTimerUp()) Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        damageHandler.DamageObjects(collisonManager.GetIntersectingDamageables(parentCharacter), damage, parentCharacter);
    }

    void SetVelocity()
    {
        Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        rb.velocity = direction * speed; 
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
