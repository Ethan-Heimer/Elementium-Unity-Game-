using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallStatusProvider : MonoBehaviour, IChararacterWallStatusProvider
{
    [SerializeField] float checkDistance;

    ICharacterDirectionHandler directionHandler;

    void Awake() => directionHandler = GetComponent<ICharacterDirectionHandler>(); 
  
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
}
