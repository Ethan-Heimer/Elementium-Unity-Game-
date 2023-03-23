using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wall Status Provider", menuName = "Character Components/Wall Status Providers/Basic Wall Status Provder")]
public class CharacterWallStatusProvider : WallStatusProvider
{
    public override bool CheckForWall(Character character)
    {
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(character.transform.position.x + .3f * character.directionHandler.GetCurrentDirection(), character.transform.position.y), new Vector2(.1f, .5f), 0, Vector2.left, 0f, LayerMask.GetMask("Enviorment")); 
        Collider2D collider = hit.collider;
        if (collider is null) return false;
        return !collider.isTrigger;
    }

    public override bool CheckForBackTowordsWall(Character character)
    {
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(character.transform.position.x + .3f * -character.directionHandler.GetCurrentDirection(), character.transform.position.y), new Vector2(.1f, .5f), 0, Vector2.left, 0f, LayerMask.GetMask("Enviorment"));
        Collider2D collider = hit.collider;
        if (collider is null) return false;
        return !collider.isTrigger;
    }

    public override void DrawGizmos(Character character)
    {
        Gizmos.DrawWireCube(new Vector2(character.transform.position.x + .3f * character.directionHandler.GetCurrentDirection(), character.transform.position.y), new Vector2(.1f, .8f));
    }
}
