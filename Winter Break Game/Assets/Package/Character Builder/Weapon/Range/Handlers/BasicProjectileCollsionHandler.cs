using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BasicProjectileCollsionHandler : MonoBehaviour, IProjectileCollisonManager
{
    Vector3 previousPosition;
    void Start()
    {
        previousPosition = transform.position; 
    }

    void UpdatePreviousPos() => previousPosition = transform.position; 

    public IDamageable[] GetIntersectingDamageables(GameObject parentCharacter)
    {
        RaycastHit2D[] objs = Physics2D.RaycastAll(transform.position, transform.position - previousPosition, Vector2.Distance(transform.position, previousPosition));
        UpdatePreviousPos();

        return objs.Where(x => x.collider.gameObject != parentCharacter).Select(x => x.collider.gameObject.GetComponent<IDamageable>()).ToArray();
    }
}
