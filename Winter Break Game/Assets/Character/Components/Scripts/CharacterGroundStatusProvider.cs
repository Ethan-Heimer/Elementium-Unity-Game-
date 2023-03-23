using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Ground Status Provider", menuName = "Character Components/Ground Status Providers/Basic Ground Status Provder")]
public class CharacterGroundStatusProvider : GroundStatusProvider
{
   [SerializeField] Vector2 checkBoxSize;
   [SerializeField] Vector3 checkBoxOffset;

   public override bool CheckForGround(Character character)
   {
        RaycastHit2D hit = Physics2D.BoxCast(character.transform.position-checkBoxOffset, checkBoxSize, 0f, Vector2.down, 0, LayerMask.GetMask("Enviorment"));

        if (hit.collider is null) return false;
        if (hit.collider.isTrigger) return false;

        return true; 
   }

    public override void DrawGizmos(Character character)
    {
        Gizmos.DrawWireCube(character.transform.position - checkBoxOffset, checkBoxSize);
    }
}
