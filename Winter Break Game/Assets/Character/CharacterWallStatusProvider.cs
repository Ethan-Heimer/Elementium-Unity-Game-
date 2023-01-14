using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterWallStatusProvider : CharacterClass, IChararacterWallStatusProvider
{
    
    [SerializeField] float checkDistance;

    ICharacterDirectionHandler directionHandler;
    Transform transform;
    
    public  override void Constructer(Character character)
    {
        base.Constructer(character);
        directionHandler = character.movement.directionHandler;
        
        transform = character.transform;
    }


    public bool IsOnWall()
    {
        if (directionHandler is null) return false; 

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * directionHandler.GetCurrentDirection(), checkDistance, LayerMask.GetMask("Enviorment"));
        Collider2D collider = hit.collider;
        if (collider is null) return false;
        return !collider.isTrigger;
    }

    public void OnDrawGizmos()
    {
        if (directionHandler is null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (checkDistance * directionHandler.GetCurrentDirection()), transform.position.y, 0));
    }

    public object Clone() => MemberwiseClone(); 
}
