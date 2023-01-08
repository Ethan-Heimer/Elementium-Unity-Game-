using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;

public class OverlapCircleBasedMeleeCollisionHandler : MonoBehaviour, IMeleeCollisonHandler
{
    [Header("Collision")]
    public float weaponSize = 1;
    public Vector3 collisionOffset;

    public IDamageable[] CheckCollision(GameObject _owner)
    {
        Collider2D[] possableCollisions = Physics2D.OverlapCircleAll(transform.position + collisionOffset, weaponSize);
        Collider2D[] collisions = possableCollisions.Where(x => x.gameObject != _owner).ToArray();

        Collider2D[] realCollisions = collisions.Where(x => x.GetComponent<IDamageable>() is not null).ToArray();
        return realCollisions.Select(x => x.GetComponent<IDamageable>()).ToArray();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + collisionOffset, weaponSize);
    }
}


