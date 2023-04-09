using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Ground Status Provider", menuName = "Character Components/Ground Status Providers/Basic Ground Status Provder")]
public class CharacterGroundStatusProvider : CharacterEnviormentStatusProvider
{
    [SerializeField] Vector2 checkBoxSize;
    [SerializeField] Vector3 checkBoxOffset;

    public override string GetStatusName() => "Ground";

    protected override bool GetEnviormentStatus(Character character)
    {
        if (character.enviormentStatuses.GetStatus("Climb")) return false;

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
