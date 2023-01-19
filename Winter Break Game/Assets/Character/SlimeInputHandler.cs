using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeInputHandler : CharacterClass, ICharacterInputHandler
{
    public float playerSeekDistance; 

    Timer jumpTimer;

    public override void Constructer(Character _character)
    {
        base.Constructer(_character);
        jumpTimer = new Timer(1/character.statsHandler.GetStat("Hop Speed"));
    }

    public float GetHorizontalInput()
    {
        Collider2D player = Physics2D.OverlapCircle(character.transform.position, playerSeekDistance, LayerMask.GetMask("Player"));

        if(player is not null)
        {
            return Mathf.Clamp(player.transform.position.x - character.transform.position.x, -1, 1); 
        }

        return Random.Range(-1, 2); 
    }

    public float GetVerticalInput() => 0; 

    public bool GetJumpInput()
    {
        bool canJump = false;
        if(jumpTimer.IsTimerUp())
        {
            canJump = true;
            jumpTimer.ResetTimer();
        }

        return canJump; 
    }

    public bool GetActionInput() => false; 

}
