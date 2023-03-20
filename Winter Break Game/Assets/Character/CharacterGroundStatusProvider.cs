using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CharacterGroundStatusProvider : GroundStatusProvider
{
   [SerializeField] Vector2 checkBoxSize;
   [SerializeField] Vector3 checkBoxOffset;

   protected override bool CheckForGround()
   {
        RaycastHit2D hit = Physics2D.BoxCast(character.transform.position-checkBoxOffset, checkBoxSize, 0f, Vector2.down, 0, LayerMask.GetMask("Enviorment"));

        if (hit.collider is null) return false;
        if (hit.collider.isTrigger) return false;

        return true; 
   }

    public override void DrawGizmos()
    {
        Gizmos.DrawWireCube(character.transform.position - checkBoxOffset, checkBoxSize);
    }
}
