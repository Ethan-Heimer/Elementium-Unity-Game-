using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterGroundStatusProvider : CharacterClass, ICharacterGroundStatusProvider
{
   [SerializeField] Vector2 checkBoxSize;
   [SerializeField] Vector3 checkBoxOffset;

    Transform transform; 
   public override void Constructer(Character character)
    {
        base.Constructer(character);
        transform = character.transform; 
    }

   public bool IsOnGround()
   {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(transform.position-checkBoxOffset, checkBoxSize, 0f, Vector2.down, 0, LayerMask.GetMask("Enviorment"));

        foreach(RaycastHit2D o in hit)
        {
            if (o.collider.isTrigger) continue;
            return true; 
        }

        return false; 
   }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position-checkBoxOffset, checkBoxSize); 
    }
}
