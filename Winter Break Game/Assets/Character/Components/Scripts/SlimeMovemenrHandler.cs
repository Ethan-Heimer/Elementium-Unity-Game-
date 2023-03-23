using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Movement Handler", menuName = "Character Components/Movement Handlers/Slime Movement Handler")]
public class SlimeMovemenrHandler : CharacterMovementHandler
{
    public float Speed;
    public float JumpHeight;

    public override void OnStart(Character character)
    {
        
    }

    public override void OnUpdate(Character character)
    {
        
    }

    public override void OnFixedUpdate(Character character)
    {
        bool move = character.input.GetJumpInput();

        if (move)
        {
            character.movement.Move(character.input.GetHorizontalInput(), Speed);
            character.movement.Jump(JumpHeight);
        }
    }
}
