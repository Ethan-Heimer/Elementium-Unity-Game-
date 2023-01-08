using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundStatusProvider : MonoBehaviour, ICharacterGroundStatusProvider
{
   [SerializeField] Vector2 checkBoxSize;
    [SerializeField] Vector3 checkBoxOffset; 
   public bool IsOnGround()
   {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position-checkBoxOffset, checkBoxSize, 0f, Vector2.down, 0, LayerMask.GetMask("Enviorment"));
        Collider2D collider = hit.collider;
        if (collider is null) return false;
        return !collider.isTrigger; 

   }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position-checkBoxOffset, checkBoxSize); 
    }
}
