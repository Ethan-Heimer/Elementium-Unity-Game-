using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovemenrHandler : CharacterClass, ICharacterMovementHandler
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void FixedUpdate()
    {
        bool move = character.input.GetJumpInput();

        if (move)
        {
            character.movement.Move(character.input.GetHorizontalInput(), character.statsHandler.GetStat("Speed"));
            character.movement.Jump(character.statsHandler.GetStat("Jump Height"));
        }
    }
}
