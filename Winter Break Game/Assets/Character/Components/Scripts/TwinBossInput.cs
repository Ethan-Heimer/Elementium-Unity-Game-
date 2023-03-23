using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Input Handler", menuName = "Character Components/Input Handlers/Twin Boss Input Handler")]
public class TwinBossInput : CharacterInputHandler
{
    public float HopInputDelay;
    public float ActionInputDelay;

    float PlayerSeekDistance = 0;

    Timer actionTime;

    Timer jumpTimer = new Timer(0);

    public override float GetHorizontalInput(Character character)
    {
        Collider2D player = Physics2D.OverlapCircle(character.transform.position, PlayerSeekDistance, LayerMask.GetMask("Player"));

        if (player is not null)
        {
            return Mathf.Clamp(player.transform.position.x - character.transform.position.x, -1, 1);
        }

        return Random.Range(-1, 2);
    }

    public override float GetVerticalInput(Character character) => 0;

    public override bool GetJumpInput(Character character)
    {
        bool canJump = false;
        if (jumpTimer.IsTimerUp())
        {
            canJump = true;
            jumpTimer.ResetTimer(1 / HopInputDelay);
        }

        return canJump;
    }
    public override bool GetClimbInput(Character character) => false;
    public override bool GetActionInput(Character character)
    {
        bool t = actionTime.IsTimerUp();

        if(t)
            actionTime.ResetTimer(ActionInputDelay);
        
        return t; 
    }
}
