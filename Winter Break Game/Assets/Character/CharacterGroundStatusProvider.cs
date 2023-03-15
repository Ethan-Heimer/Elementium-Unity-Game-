using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CharacterGroundStatusProvider : GroundStatusProvider
{
   [SerializeField] Vector2 checkBoxSize;
   [SerializeField] Vector3 checkBoxOffset;


   public override bool IsOnGround()
   {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(character.transform.position-checkBoxOffset, checkBoxSize, 0f, Vector2.down, 0, LayerMask.GetMask("Enviorment"));

        foreach(RaycastHit2D o in hit)
        {
            if (o.collider.isTrigger) continue;
            return true; 
        }

        return false; 
   }

    public override void DrawGizmos()
    {
        Gizmos.DrawWireCube(character.transform.position - checkBoxOffset, checkBoxSize);
    }
}
