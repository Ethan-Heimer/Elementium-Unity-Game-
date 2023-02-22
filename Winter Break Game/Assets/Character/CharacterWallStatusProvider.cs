using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterWallStatusProvider : CharacterClass, IChararacterWallStatusProvider
{
    
    [SerializeField] float checkDistance;

    Transform transform;
    
    public  override void Constructer(Character character)
    {
        base.Constructer(character);
        
        transform = character.transform;
    }


    public bool IsOnWall()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * directionHandler.GetCurrentDirection(), checkDistance, LayerMask.GetMask("Enviorment"));
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(transform.position.x+.5f*character.directionHandler.GetCurrentDirection(), transform.position.y), new Vector2(.2f, .8f), 0, Vector2.left, 0f, LayerMask.GetMask("Enviorment")); 
        Collider2D collider = hit.collider;
        if (collider is null) return false;
        return !collider.isTrigger;
    }

    public void OnDrawGizmos()
    {
        if (character.directionHandler is null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (checkDistance * character.directionHandler.GetCurrentDirection()), transform.position.y, 0));
    }
}
